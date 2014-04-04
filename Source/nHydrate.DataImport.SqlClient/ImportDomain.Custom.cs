using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace nHydrate.DataImport.SqlClient
{
    partial class ImportDomain
    {

        public Database Import(string connectionString, IEnumerable<string> sqlScript, SqlServerObject sqlServerObject)
        {
            try
            {
                var database = new Database();
                database.Collate = DatabaseHelper.GetDatabaseCollation(connectionString);

                #region Load user defined types

                LoadUdts(database, connectionString);

                #endregion

                var strObjectDbs = sqlScript as IList<string> ?? sqlScript.ToList();
                if (sqlServerObject == SqlServerObject.Table)
                {
                    #region Load Entities
                    
                    this.ProgressText = "Loading Entities...";

                    foreach (var strObjectDb in strObjectDbs)
                    {
                        using (
                            var tableReader = DatabaseHelper.ExecuteReader(connectionString, CommandType.Text,
                                 SchemaModelHelper.GetSqlColumnsForTable(strObjectDb)))
                        {
                            while (tableReader.Read())
                            {
                                var newEntity = new Entity();
                                newEntity.Name = tableReader["name"].ToString();
                                database.EntityList.Add(newEntity);
                                newEntity.Schema = tableReader["schema"].ToString();
                            }
                        }
                    }


                    #endregion

                    #region Load Entity Fields

                    foreach (var strObjectDb in strObjectDbs)
                    {

                        using (
                            var columnReader = DatabaseHelper.ExecuteReader(connectionString, CommandType.Text,
                                SchemaModelHelper.GetSqlColumnsForTable(strObjectDb)))
                        {
                            while (columnReader.Read())
                            {
                                var columnName = columnReader["columnName"].ToString();
                                var tableName = columnReader["tableName"].ToString();

                                var entity = database.EntityList.FirstOrDefault(x => x.Name == tableName);
                                //Ensure the field name is not an Audit field
                                if (entity != null)
                                {
                                    var maxSortOrder = 0;
                                    if (entity.FieldList.Count > 0)
                                        maxSortOrder = entity.FieldList.Max(x => x.SortOrder);
                                    var newColumn = new Field() {Name = columnName, SortOrder = ++maxSortOrder};
                                    entity.FieldList.Add(newColumn);

                                    newColumn.Nullable = bool.Parse(columnReader["allowNull"].ToString());
                                    if (bool.Parse(columnReader["isIdentity"].ToString()))
                                        newColumn.Identity = true;

                                    if (columnReader["isPrimaryKey"] != System.DBNull.Value)
                                        newColumn.PrimaryKey = true;

                                    try
                                    {
                                        newColumn.DataType = DatabaseHelper.GetSQLDataType(
                                            columnReader["xtype"].ToString(), database.UserDefinedTypes);
                                    }
                                    catch
                                    {
                                    }

                                    var defaultvalue = columnReader["defaultValue"].ToString();
                                    SetupDefault(newColumn, defaultvalue);
                                    //newColumn.ImportedDefaultName = "";

                                    newColumn.Length = (int) columnReader["length"];

                                    //Decimals are a little different
                                    if (newColumn.DataType == SqlDbType.Decimal)
                                    {
                                        newColumn.Length = (byte) columnReader["precision"];
                                        newColumn.Scale = (int) columnReader["scale"];
                                    }

                                    if (columnReader["collation"] != System.DBNull.Value)
                                    {
                                        if (database.Collate != (string) columnReader["collation"])
                                            newColumn.Collate = (string) columnReader["collation"];
                                    }

                                }
                            }
                        }
                    }

                    foreach (var strObjectDb in strObjectDbs)
                    {
                        using (
                            var columnReader = DatabaseHelper.ExecuteReader(connectionString, CommandType.Text,
                                SchemaModelHelper.GetSqlColumnsForComputed(strObjectDb)))
                        {
                            while (columnReader.Read())
                            {
                                var tableName = columnReader["tableName"].ToString();
                                var columnName = columnReader["columnName"].ToString();
                                var entity = database.EntityList.FirstOrDefault(x => x.Name == tableName);
                                if (entity != null)
                                {
                                    var column =
                                        entity.FieldList.FirstOrDefault(x => x.Name.ToLower() == columnName.ToLower());
                                    if (column != null)
                                    {
                                        column.IsComputed = true;
                                        column.Formula = columnReader["definition"].ToString();
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    #region Load Entity Indexes

                    using (
                        var indexReader = DatabaseHelper.ExecuteReader(connectionString, CommandType.Text,
                            SchemaModelHelper.GetSqlIndexesForTable()))
                    {
                        while (indexReader.Read())
                        {
                            var indexName = indexReader["indexname"].ToString();
                            var columnName = indexReader["columnname"].ToString();
                            var tableName = indexReader["tableName"].ToString();
                            var entity = database.EntityList.FirstOrDefault(x => x.Name == tableName);
                            if (entity != null)
                            {
                                var pk = bool.Parse(indexReader["is_primary_key"].ToString());
                                var column = entity.FieldList.FirstOrDefault(x => x.Name == columnName);
                                if (column != null && !pk)
                                    column.IsIndexed = true;
                            }
                        }
                    }

                    #endregion

                    #region Load Relations

                    var dsRelationship = DatabaseHelper.ExecuteDataset(connectionString,
                        SchemaModelHelper.GetSqlForRelationships());
                    foreach (DataRow rowRelationship in dsRelationship.Tables[0].Rows)
                    {
                        var constraintName = rowRelationship["FK_CONSTRAINT_NAME"].ToString();
                        var parentTableName = (string) rowRelationship["UQ_TABLE_NAME"];
                        var childTableName = (string) rowRelationship["FK_TABLE_NAME"];
                        var parentTable = database.EntityList.FirstOrDefault(x => x.Name == parentTableName);
                        var childTable = database.EntityList.FirstOrDefault(x => x.Name == childTableName);
                        if (parentTable != null && childTable != null)
                        {
                            Relationship newRelation = null;
                            var isAdd = false;
                            if (database.RelationshipList.Count(x => x.ConstraintName == constraintName) == 0)
                            {
                                newRelation = new Relationship();
                                if (rowRelationship["id"] != System.DBNull.Value)
                                    newRelation.ImportData = rowRelationship["id"].ToString();
                                newRelation.SourceEntity = parentTable;
                                newRelation.TargetEntity = childTable;
                                newRelation.ConstraintName = constraintName;
                                var search = ("_" + childTable.Name + "_" + parentTable.Name).ToLower();
                                var roleName = constraintName.ToLower().Replace(search, string.Empty);
                                if (roleName.Length >= 3) roleName = roleName.Remove(0, 3);
                                var v = roleName.ToLower();
                                if (v != "fk") newRelation.RoleName = v;
                                isAdd = true;
                            }
                            else
                            {
                                newRelation = database.RelationshipList.First(x => x.ConstraintName == constraintName);
                            }

                            //add the column relationship to the relation
                            var columnRelationship = new RelationshipDetail();
                            var parentColumnName = (string) rowRelationship["UQ_COLUMN_NAME"];
                            var childColumnName = (string) rowRelationship["FK_COLUMN_NAME"];
                            if (parentTable.FieldList.Count(x => x.Name == parentColumnName) == 1 &&
                                (childTable.FieldList.Count(x => x.Name == childColumnName) == 1))
                            {
                                columnRelationship.ParentField =
                                    parentTable.FieldList.First(x => x.Name == parentColumnName);
                                columnRelationship.ChildField =
                                    childTable.FieldList.First(x => x.Name == childColumnName);
                                newRelation.RelationshipColumnList.Add(columnRelationship);

                                //ONLY ADD THIS RELATION IF ALL WENT WELL
                                if (isAdd)
                                    parentTable.RelationshipList.Add(newRelation);
                            }
                            else
                            {
                                System.Diagnostics.Debug.Write(string.Empty);
                            }

                        }

                    }

                    #endregion

                }

                if (sqlServerObject == SqlServerObject.StoredProcedure)
                {

                    #region Load StoredProcs
                    
                    foreach (var strObjectDb in strObjectDbs)
                    {
                        var procName = strObjectDb.IndexOf(" ") > -1
                            ? strObjectDb.Split(Convert.ToChar(" "))[0]
                            : strObjectDb;

                        LoadStoredProcedures(database, procName, connectionString, strObjectDb);
                    }

                    #endregion
                }

               #region Load Indexes

                this.ProgressText = "Loading Indexes...";
                LoadIndexes(database, connectionString);

                #endregion

                LoadUniqueFields(database, connectionString);

                return database;

            }
            catch (Exception /*ignored*/)
            {
                throw;
            }
            finally
            {
                this.ProgressText = string.Empty;
                this.ProgressValue = 0;
            }
        }
    }
}

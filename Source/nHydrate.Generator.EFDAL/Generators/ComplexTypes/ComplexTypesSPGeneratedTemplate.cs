#region Copyright (c) 2006-2013 nHydrate.org, All Rights Reserved
// -------------------------------------------------------------------------- *
//                           NHYDRATE.ORG                                     *
//              Copyright (c) 2006-2013 All Rights reserved                   *
//                                                                            *
//                                                                            *
// Permission is hereby granted, free of charge, to any person obtaining a    *
// copy of this software and associated documentation files (the "Software"), *
// to deal in the Software without restriction, including without limitation  *
// the rights to use, copy, modify, merge, publish, distribute, sublicense,   *
// and/or sell copies of the Software, and to permit persons to whom the      *
// Software is furnished to do so, subject to the following conditions:       *
//                                                                            *
// The above copyright notice and this permission notice shall be included    *
// in all copies or substantial portions of the Software.                     *
//                                                                            *
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,            *
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES            *
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  *
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY       *
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,       *
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE          *
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                     *
// -------------------------------------------------------------------------- *
#endregion
using System;
using System.Linq;
using System.Text;
using nHydrate.Generator.Models;
using nHydrate.Generator.Common.GeneratorFramework;

namespace nHydrate.Generator.EFDAL.Generators.ComplexTypes
{
	public class ComplexTypesSPGeneratedTemplate : EFDALBaseTemplate
	{
		private readonly StringBuilder sb = new StringBuilder();
		private readonly CustomStoredProcedure _item = null;

		public ComplexTypesSPGeneratedTemplate(ModelRoot model, CustomStoredProcedure item)
			: base(model)
		{
			_item = item;
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return _item.PascalName + ".Generated.cs"; }
		}

		public string ParentItemName
		{
			get { return _item.PascalName + ".cs"; }
		}

		public override string FileContent
		{
			get
			{
				GenerateContent();
				return sb.ToString();
			}
		}
		#endregion

		#region GenerateContent

		private void GenerateContent()
		{
			try
			{
				nHydrate.Generator.GenerationHelper.AppendCopyrightInCode(sb, _model);
				this.AppendUsingStatements();
				sb.AppendLine("namespace " + this.GetLocalNamespace() + ".Entity");
				sb.AppendLine("{");

				var doubleDerivedClassName = _item.PascalName;
				if (_item.GeneratesDoubleDerived)
				{
					doubleDerivedClassName = _item.PascalName + "Base";

					sb.AppendLine("	/// <summary>");
					sb.AppendLine("	/// Executes an action based on a stored procedure");
					sb.AppendLine("	/// </summary>");
					sb.AppendLine("	public partial class " + _item.PascalName + " : " + doubleDerivedClassName);
					sb.AppendLine("	{");
					sb.AppendLine("	}");
					sb.AppendLine();
				}

				sb.AppendLine("	/// <summary>");
				sb.AppendLine("	/// An object based on a stored procedure");
				sb.AppendLine("	/// </summary>");
				sb.AppendLine("	[EdmComplexTypeAttribute(NamespaceName = \"" + this.GetLocalNamespace() + ".Entity\", Name = \"" + _item.PascalName + "\")]");
				sb.AppendLine("	[DataContractAttribute(IsReference = true)]");
				sb.AppendLine("	[Serializable]");
				sb.AppendLine("	[System.CodeDom.Compiler.GeneratedCode(\"nHydrateModelGenerator\", \"" + _model.ModelToolVersion + "\")]");
				sb.AppendLine("	public partial class " + doubleDerivedClassName + " : nHydrate.EFCore.DataAccess.NHComplexObject, nHydrate.EFCore.DataAccess.IReadOnlyBusinessObject, " + GetLocalNamespace() + ".Interfaces.Entity.I" + _item.PascalName + ", System.ICloneable, System.IEquatable<" + GetLocalNamespace() + ".Interfaces.Entity.I" + _item.PascalName + ">");
				sb.AppendLine("	{");
				this.AppendedFieldEnum();
				this.AppendProperties();
				this.AppendRegionGetValue();
				this.AppendClone();
				this.AppendRegionGetMaxLength();
				this.AppendIsEquivalent();
				this.AppendIEquatable();
				sb.AppendLine("	}");

				sb.AppendLine("}");
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private void AppendUsingStatements()
		{
			sb.AppendLine("using System;");
			sb.AppendLine("using System.Linq;");
			sb.AppendLine("using System.Data.Objects;");
			sb.AppendLine("using System.Data.Objects.DataClasses;");
			sb.AppendLine("using System.ComponentModel;");
			sb.AppendLine("using System.Runtime.Serialization;");
			sb.AppendLine("using System.Collections.Generic;");
			sb.AppendLine("using " + this.GetLocalNamespace() + ".Entity;");
			sb.AppendLine("using System.Linq.Expressions;");
			sb.AppendLine("using nHydrate.EFCore.DataAccess;");
			sb.AppendLine();
		}

		private void AppendedFieldEnum()
		{
			var imageColumnList = _item.GetColumnsByType(System.Data.SqlDbType.Image);
			if (imageColumnList.Count() != 0)
			{
				sb.AppendLine("		#region FieldImageConstants Enumeration");
				sb.AppendLine();
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// An enumeration of this object's image type fields");
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		public enum FieldImageConstants");
				sb.AppendLine("		{");
				foreach (var column in imageColumnList.OrderBy(x => x.Name))
				{
					sb.AppendLine("			/// <summary>");
					sb.AppendLine("			/// Field mapping for the image parameter '" + column.PascalName + "' property");
					sb.AppendLine("			/// </summary>");
					sb.AppendLine("			[System.ComponentModel.Description(\"Field mapping for the image parameter '" + column.PascalName + "' property\")]");
					sb.AppendLine("			" + column.PascalName + ",");
				}
				sb.AppendLine("		}");
				sb.AppendLine();
				sb.AppendLine("		#endregion");
				sb.AppendLine();
			}

			sb.AppendLine("		#region FieldNameConstants Enumeration");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Enumeration to define each property that maps to a database field for the '" + _item.PascalName + "' table.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public enum FieldNameConstants");
			sb.AppendLine("		{");
			foreach (var column in _item.GeneratedColumns)
			{
				sb.AppendLine("			/// <summary>");
				sb.AppendLine("			/// Field mapping for the '" + column.PascalName + "' property" + (column.PascalName != column.DatabaseName ? " (Database column: " + column.DatabaseName + ")" : string.Empty));
				sb.AppendLine("			/// </summary>");
				sb.AppendLine("			[System.ComponentModel.ReadOnlyAttribute(true)]");
				sb.AppendLine("			[System.ComponentModel.Description(\"Field mapping for the '" + column.PascalName + "' property\")]");
				sb.AppendLine("			" + column.PascalName + ",");
			}

			sb.AppendLine("		}");
			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendProperties()
		{
			sb.AppendLine("		#region Primitive Properties");
			sb.AppendLine();

			foreach (var column in _item.GetColumns())
			{
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// ");
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		[EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]");
				sb.AppendLine("		[DataMemberAttribute()]");
				sb.AppendLine("		public " + column.GetCodeType() + " " + column.PascalName);
				sb.AppendLine("		{");
				sb.AppendLine("			get { return _" + column.CamelName + "; }");
				sb.AppendLine("			protected set");
				sb.AppendLine("			{");
				//sb.AppendLine("				On" + column.PascalName + "Changing(value);");
				//sb.AppendLine("				ReportPropertyChanging(\"" + column.PascalName + "\");");

				if (column.IsTextType || column.IsBinaryType || column.DataType == System.Data.SqlDbType.Timestamp)
					sb.AppendLine("				_" + column.CamelName + " = StructuralObject.SetValidValue(value, true);");
				else
					sb.AppendLine("				_" + column.CamelName + " = StructuralObject.SetValidValue(value);");

				//sb.AppendLine("				ReportPropertyChanged(\"" + column.PascalName + "\");");
				//sb.AppendLine("				On" + column.PascalName + "Changed();");
				sb.AppendLine("			}");
				sb.AppendLine("		}");
				sb.AppendLine("		private " + column.GetCodeType() + " _" + column.CamelName + ";");
				//sb.AppendLine("		partial void On" + column.PascalName + "Changing(" + column.GetCodeType() + " value);");
				//sb.AppendLine("		partial void On" + column.PascalName + "Changed();");
				sb.AppendLine();
			}

			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendRegionGetValue()
		{
			sb.AppendLine("		#region GetValue");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Gets the value of one of this object's properties.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public object GetValue(FieldNameConstants field)");
			sb.AppendLine("		{");
			sb.AppendLine("			return GetValue(field, null);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Gets the value of one of this object's properties.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public object GetValue(FieldNameConstants field, object defaultValue)");
			sb.AppendLine("		{");
			var allColumns = _item.GetColumns().Where(x => x.Generated).ToList();
			foreach (var column in allColumns.OrderBy(x => x.Name))
			{
				sb.AppendLine("			if (field == FieldNameConstants." + column.PascalName + ")");
				if (column.AllowNull)
					sb.AppendLine("				return ((this." + column.PascalName + " == null) ? defaultValue : this." + column.PascalName + ");");
				else
					sb.AppendLine("				return this." + column.PascalName + ";");
			}

			sb.AppendLine("			throw new Exception(\"Field '\" + field.ToString() + \"' not found!\");");
			sb.AppendLine("		}");
			sb.AppendLine();

			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendClone()
		{
			sb.AppendLine("		#region Clone");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Creates a shallow copy of this object of all simple properties");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		/// <returns></returns>");
			sb.AppendLine("		public virtual object Clone()");
			sb.AppendLine("		{");
			sb.AppendLine("			var newItem = new " + _item.PascalName + "();");
			foreach (var column in _item.GetColumns().Where(x => x.Generated).OrderBy(x => x.Name))
			{
				sb.AppendLine("			newItem._" + column.CamelName + " = this._" + column.CamelName + ";");
			}
			sb.AppendLine("			return newItem;");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendRegionGetMaxLength()
		{
			sb.AppendLine("		#region GetMaxLength");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Gets the maximum size of the field value.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public static int GetMaxLength(FieldNameConstants field)");
			sb.AppendLine("		{");
			sb.AppendLine("			switch (field)");
			sb.AppendLine("			{");
			foreach (var column in _item.GetColumns().Where(x => x.Generated).OrderBy(x => x.Name))
			{
				sb.AppendLine("				case FieldNameConstants." + column.PascalName + ":");
				if (_item.GeneratedColumns.Contains(column))
				{
					//This is an actual column in this table
					switch (column.DataType)
					{
						case System.Data.SqlDbType.Text:
							sb.AppendLine("					return int.MaxValue;");
							break;
						case System.Data.SqlDbType.NText:
							sb.AppendLine("					return int.MaxValue;");
							break;
						case System.Data.SqlDbType.Image:
							sb.AppendLine("					return int.MaxValue;");
							break;
						case System.Data.SqlDbType.Xml:
							sb.AppendLine("					return int.MaxValue;");
							break;
						case System.Data.SqlDbType.Char:
						case System.Data.SqlDbType.NChar:
						case System.Data.SqlDbType.NVarChar:
						case System.Data.SqlDbType.VarChar:
							if ((column.Length == 0) && (ModelHelper.SupportsMax(column.DataType)))
								sb.AppendLine("					return int.MaxValue;");
							else
								sb.AppendLine("					return " + column.Length + ";");
							break;
						default:
							sb.AppendLine("					return 0;");
							break;
					}
				}
				else
				{
					//This is an inherited column so check the base
					sb.AppendLine("					return " + _item.PascalName + ".GetMaxLength(" + _item.PascalName + ".FieldNameConstants." + column.PascalName + ");");
				}
			}
			sb.AppendLine("			}");
			sb.AppendLine("			return 0;");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		int nHydrate.EFCore.DataAccess.IReadOnlyBusinessObject.GetMaxLength(Enum field)");
			sb.AppendLine("		{");
			sb.AppendLine("			return GetMaxLength((FieldNameConstants)field);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();

			sb.AppendLine("		#region GetFieldNameConstants");
			sb.AppendLine();
			sb.AppendLine("		System.Type nHydrate.EFCore.DataAccess.IReadOnlyBusinessObject.GetFieldNameConstants()");
			sb.AppendLine("		{");
			sb.AppendLine("			return typeof(FieldNameConstants);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();

			//GetFieldType
			sb.AppendLine("		#region GetFieldType");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Gets the system type of a field on this object");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public static System.Type GetFieldType(FieldNameConstants field)");
			sb.AppendLine("		{");
			sb.AppendLine("			if (field.GetType() != typeof(FieldNameConstants))");
			sb.AppendLine("				throw new Exception(\"The '\" + field.GetType().ReflectedType.ToString() + \".FieldNameConstants' value is not valid. The field parameter must be of type '" + this.GetLocalNamespace() + ".Entity." + _item.PascalName + ".FieldNameConstants'.\");");
			sb.AppendLine();
			sb.AppendLine("			switch ((FieldNameConstants)field)");
			sb.AppendLine("			{");
			foreach (var column in _item.GeneratedColumns)
			{
				sb.AppendLine("				case FieldNameConstants." + column.PascalName + ": return typeof(" + column.GetCodeType() + ");");
			}
			sb.AppendLine("			}");
			sb.AppendLine("			return null;");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		System.Type nHydrate.EFCore.DataAccess.IReadOnlyBusinessObject.GetFieldType(Enum field)");
			sb.AppendLine("		{");
			sb.AppendLine("			if (field.GetType() != typeof(FieldNameConstants))");
			sb.AppendLine("				throw new Exception(\"The '\" + field.GetType().ReflectedType.ToString() + \".FieldNameConstants' value is not valid. The field parameter must be of type '" + this.GetLocalNamespace() + ".Entity." + _item.PascalName + ".FieldNameConstants'.\");");
			sb.AppendLine();
			sb.AppendLine("			return GetFieldType((" + this.GetLocalNamespace() + ".Entity." + _item.PascalName + ".FieldNameConstants)field);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();

			//GetValue
			sb.AppendLine("		#region Get/Set Value");
			sb.AppendLine();
			sb.AppendLine("		object nHydrate.EFCore.DataAccess.IReadOnlyBusinessObject.GetValue(System.Enum field)");
			sb.AppendLine("		{");
			sb.AppendLine("			return ((nHydrate.EFCore.DataAccess.IReadOnlyBusinessObject)this).GetValue(field, null);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		object nHydrate.EFCore.DataAccess.IReadOnlyBusinessObject.GetValue(System.Enum field, object defaultValue)");
			sb.AppendLine("		{");
			sb.AppendLine("			if (field.GetType() != typeof(FieldNameConstants))");
			sb.AppendLine("				throw new Exception(\"The '\" + field.GetType().ReflectedType.ToString() + \".FieldNameConstants' value is not valid. The field parameter must be of type '\" + this.GetType().ToString() + \".FieldNameConstants'.\");");
			sb.AppendLine("			return this.GetValue((FieldNameConstants)field, defaultValue);");
			sb.AppendLine("		}");
			sb.AppendLine();

			sb.AppendLine("		#endregion");
			sb.AppendLine();

				sb.AppendLine("		#region PrimaryKey");
				sb.AppendLine();
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// Hold the primary key for this object");
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		protected nHydrate.EFCore.DataAccess.IPrimaryKey _primaryKey = null;");
				sb.AppendLine("		nHydrate.EFCore.DataAccess.IPrimaryKey nHydrate.EFCore.DataAccess.IReadOnlyBusinessObject.PrimaryKey");
				sb.AppendLine("		{");
				sb.AppendLine("			get { return null; }");
				sb.AppendLine("		}");
				sb.AppendLine();
				sb.AppendLine("		#endregion");
				sb.AppendLine();

		}

		private void AppendIsEquivalent()
		{
			sb.AppendLine("		#region IsEquivalent");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Determines if all of the fields for the specified object exactly matches the current object.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		/// <param name=\"item\">The object to compare</param>");
			sb.AppendLine("		public override bool IsEquivalent(nHydrate.EFCore.DataAccess.INHEntityObject item)");
			sb.AppendLine("		{");
			sb.AppendLine("			return ((System.IEquatable<" + this.GetLocalNamespace() + ".Interfaces.Entity.I" + _item.PascalName + ">)this).Equals(item as " + this.GetLocalNamespace() + ".Interfaces.Entity.I" + _item.PascalName + ");");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendIEquatable()
		{
			sb.AppendLine("		#region Equals");
			sb.AppendLine("		bool System.IEquatable<" + this.GetLocalNamespace() + ".Interfaces.Entity.I" + _item.PascalName + ">.Equals(" + this.GetLocalNamespace() + ".Interfaces.Entity.I" + _item.PascalName + " other)");
			sb.AppendLine("		{");
			sb.AppendLine("			return this.Equals(other);");
			sb.AppendLine("		}");
			sb.AppendLine();

			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Determines whether the specified object is equal to the current object.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public override bool Equals(object obj)");
			sb.AppendLine("		{");
			sb.AppendLine("			var other = obj as " + this.GetLocalNamespace() + ".Entity." + _item.PascalName + ";");
			sb.AppendLine("			if (other == null) return false;");
			sb.AppendLine("			return (");

			var allColumns = _item.GeneratedColumns.ToList();
			var index = 0;
			foreach (var column in allColumns)
			{
				sb.Append("				other." + column.PascalName + " == this." + column.PascalName);
				if (index < allColumns.Count - 1) sb.Append(" &&");
				sb.AppendLine();
				index++;
			}

			sb.AppendLine("				);");
			sb.AppendLine("		}");
			sb.AppendLine();

			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Serves as a hash function for a particular type.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public override int GetHashCode()");
			sb.AppendLine("		{");
			sb.AppendLine("			return base.GetHashCode();");
			sb.AppendLine("		}");
			sb.AppendLine();
			
			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		#endregion

	}
}

#region Copyright (c) 2006-2011 Widgetsphere LLC, All Rights Reserved
//--------------------------------------------------------------------- *
//                          Widgetsphere  LLC                           *
//             Copyright (c) 2006-2011 All Rights reserved              *
//                                                                      *
//                                                                      *
//This file and its contents are protected by United States and         *
//International copyright laws.  Unauthorized reproduction and/or       *
//distribution of all or any portion of the code contained herein       *
//is strictly prohibited and will result in severe civil and criminal   *
//penalties.  Any violations of this copyright will be prosecuted       *
//to the fullest extent possible under law.                             *
//                                                                      *
//THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
//TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
//TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
//CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
//THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF WIDGETSPHERE LLC   *
//                                                                      *
//UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
//PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
//SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY WIDGETSPHERE PRODUCT.    *
//                                                                      *
//THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
//CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF WIDGETSPHERE,      *
//INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
//INSURE ITS CONFIDENTIALITY.                                           *
//                                                                      *
//THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
//PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
//EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
//THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
//SOURCE CODE CONTAINED HEREIN.                                         *
//                                                                      *
//THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
//--------------------------------------------------------------------- *
#endregion
using System;
using System.Linq;
using Widgetsphere.Generator.Common.GeneratorFramework;
using Widgetsphere.Generator.Models;
using System.Text;
using Widgetsphere.Generator.Common.Util;
using System.Collections.Generic;

namespace Widgetsphere.Generator.EFCodeFirst.Generators.EFCSDL
{
	public class ViewEntityGeneratedTemplate : EFCodeFirstBaseTemplate
	{
		private StringBuilder sb = new StringBuilder();
		private CustomView _currentView;

		public ViewEntityGeneratedTemplate(ModelRoot model, CustomView currentTable)
		{
			_model = model;
			_currentView = currentTable;
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return string.Format("{0}.Generated.cs", _currentView.PascalName); }
		}

		public string ParentItemName
		{
			get { return string.Format("{0}.cs", _currentView.PascalName); }
		}

		public override string FileContent
		{
			get
			{
				try
				{
					sb = new StringBuilder();
					this.GenerateContent();
					return sb.ToString();
				}
				catch (Exception ex)
				{
					throw;
				}
			}
		}
		#endregion

		#region GenerateContent

		private void GenerateContent()
		{
			try
			{
				ValidationHelper.AppendCopyrightInCode(sb, _model);
				this.AppendUsingStatements();
				sb.AppendLine("namespace " + this.GetLocalNamespace() + ".Entity");
				sb.AppendLine("{");
				this.AppendEntityClass();
				this.AppendPagingClass();
				sb.AppendLine("}");
				sb.AppendLine();
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
			sb.AppendLine("using System.Runtime.Serialization;");
			sb.AppendLine("using System.Data.Objects.DataClasses;");
			sb.AppendLine("using System.Xml.Serialization;");
			sb.AppendLine("using System.ComponentModel;");
			sb.AppendLine("using System.Collections.Generic;");
			sb.AppendLine("using System.Data.Objects;");
			sb.AppendLine("using System.Text;");
			sb.AppendLine("using " + this.GetLocalNamespace() + ";");
			sb.AppendLine("using System.Text.RegularExpressions;");
			sb.AppendLine("using System.Linq.Expressions;");
			sb.AppendLine("using System.Data.Linq;");
			sb.AppendLine();
		}

		private void AppendEntityClass()
		{
			sb.AppendLine("	/// <summary>");
			sb.AppendLine("	/// The collection to hold '" + _currentView.PascalName + "' entities");
			if (!string.IsNullOrEmpty(_currentView.Description))
				sb.AppendLine("	/// " + _currentView.Description);
			sb.AppendLine("	/// </summary>");
			sb.AppendLine("	[EdmEntityTypeAttribute(NamespaceName = \"" + this.GetLocalNamespace() + ".Entity" + "\", Name = \"" + _currentView.PascalName + "\")]");
			sb.AppendLine("	[Serializable()]");
			sb.AppendLine("	[DataContractAttribute(IsReference = true)]");
			//sb.AppendLine("	[Widgetsphere.EFCore.Attributes.FieldNameConstantsAttribute(typeof(" + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + ".FieldNameConstants))]");

			if (!string.IsNullOrEmpty(_currentView.Description))
				sb.AppendLine("	[System.ComponentModel.Description(\"" + _currentView.Description + "\")]");

			sb.AppendLine("	[System.ComponentModel.ImmutableObject(true)]");

			//sb.AppendLine("	public partial class " + _currentView.PascalName + " : Widgetsphere.EFCore.DataAccess.NHEntityObject, Widgetsphere.EFCore.DataAccess.IBusinessObject");

			sb.AppendLine("	{");
			this.AppendedFieldEnum();
			this.AppendConstructors();
			this.AppendProperties();
			this.AppendGenerateEvents();
			this.AppendRegionGetMaxLength();
			this.AppendParented();
			this.AppendIsEquivalent();
			this.AppendRegionGetDatabaseFieldName();
			sb.AppendLine("	}");
			sb.AppendLine();
		}

		private void AppendConstructors()
		{
			string scope = "protected internal";

			sb.AppendLine("		#region Constructors");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Initializes a new instance of the " + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + " class");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		" + scope + " " + _currentView.PascalName + "()");
			sb.AppendLine("		{");
			if (_currentView.PrimaryKeyColumns.Count == 1 && _currentView.PrimaryKeyColumns[0].DataType == System.Data.SqlDbType.UniqueIdentifier)
				sb.AppendLine("			this." + _currentView.PrimaryKeyColumns[0].PascalName + " = Guid.NewGuid();");
			sb.AppendLine("		}");
			sb.AppendLine();

				sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendParented()
		{
			sb.AppendLine("		#region IsParented");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Determines if this object is part of a collection or is detached");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		[System.ComponentModel.Browsable(false)]");

			sb.AppendLine("		public virtual bool IsParented");

			sb.AppendLine("		{");
			sb.AppendLine("		  get { return (this.EntityState != System.Data.EntityState.Detached); }");
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
			//sb.AppendLine("		public override bool IsEquivalent(Widgetsphere.EFCore.DataAccess.NHEntityObject item)");
			sb.AppendLine("		{");
			sb.AppendLine("			if (item == null) return false;");
			sb.AppendLine("			if (!(item is " + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + ")) return false;");
			sb.AppendLine("			" + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + " o = item as " + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + ";");
			sb.AppendLine("			return (");

			IEnumerable<CustomViewColumn> allColumns = _currentView.GetColumns().Where(x => x.Generated);
			int index = 0;
			foreach (CustomViewColumn column in allColumns)
			{
#if notimplementedyet
				Table typeTable = _currentView.GetRelatedTypeTableByColumn(column, true);
				if (typeTable != null)
				{
					sb.Append("				o." + typeTable.PascalName + " == this." + typeTable.PascalName);
				}
				else
				{
					sb.Append("				o." + column.PascalName + " == this." + column.PascalName);
				}
#else
				sb.Append("				o." + column.PascalName + " == this." + column.PascalName);
#endif
				if (index < allColumns.Count() - 1) sb.Append(" &&");
				sb.AppendLine();
				index++;
			}

			sb.AppendLine("				);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendedFieldEnum()
		{
			IEnumerable<CustomViewColumn> imageColumnList = _currentView.GetColumns().Where(x => x.DataType == System.Data.SqlDbType.Image).OrderBy(x=>x.Name);
			if (imageColumnList.Count() != 0)
			{
				sb.AppendLine("		#region FieldNameConstants Enumeration");
				sb.AppendLine();
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// An enumeration of this object's image type fields");
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		public enum FieldImageConstants");
				sb.AppendLine("		{");

				foreach (var column in imageColumnList)
				{
					sb.AppendLine("			/// <summary>");
					sb.AppendLine("			/// Field mapping for the image column '" + column.PascalName + "' property");
					sb.AppendLine("			/// </summary>");
					sb.AppendLine("			[System.ComponentModel.Description(\"Field mapping for the image column '" + column.PascalName + "' property\")]");
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
			sb.AppendLine("		/// Enumeration to define each property that maps to a database field for the '" + _currentView.PascalName + "' customView.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public enum FieldNameConstants");
			sb.AppendLine("		{");

			foreach (var column in _currentView.GetColumns().OrderBy(x=>x.Name))
			{
				sb.AppendLine("			/// <summary>");
				sb.AppendLine("			/// Field mapping for the '" + column.PascalName + "' property");
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
			sb.AppendLine("		#region Properties");
			sb.AppendLine();

			//Fake Primary Key
			sb.AppendLine("		[System.ComponentModel.Browsable(true)]");
			sb.AppendLine("		[EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]");
			sb.AppendLine("		[DataMemberAttribute()]");
			sb.AppendLine("		[System.ComponentModel.DisplayName(\"pk\")]");
			sb.AppendLine("		[System.ComponentModel.ReadOnly(true)]");
			sb.AppendLine("		private Guid pk");
			sb.AppendLine("		{");
			sb.AppendLine("			get { return _pk; }");
			sb.AppendLine("			set { _pk = value; }");
			sb.AppendLine("		}");
			sb.AppendLine("		private Guid _pk;");

			foreach (var column in _currentView.GetColumns().Where(x => x.Generated).OrderBy(x => x.Name))
			{
#if notimplementedtyet
				if (_currentView.IsColumnRelatedToTypeTable(column))
				{
					Table typeTable = _currentView.GetRelatedTypeTableByColumn(column);

					//If this column is a type table column then generate a special property
					sb.AppendLine("		/// <summary>");
					if (!string.IsNullOrEmpty(column.Description))
						sb.AppendLine("		/// " + column.Description + "");
					else
						sb.AppendLine("		/// The property that maps back to the database '" + (column.ParentTableRef.Object as Table).DatabaseName + "." + column.DatabaseName + "' field");
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		/// <remarks>" + column.GetIntellisenseRemarks() + "</remarks>");
					sb.AppendLine("		[EdmComplexPropertyAttribute()]");
					//sb.AppendLine("		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]");
					//sb.AppendLine("		[XmlElement(IsNullable=" + column.AllowNull.ToString().ToLower() + ")]");
					//sb.AppendLine("		[SoapElement(IsNullable=" + column.AllowNull.ToString().ToLower() + ")]");
					sb.AppendLine("		[DataMemberAttribute()]");
					if (column.PrimaryKey)
						sb.AppendLine("		[System.ComponentModel.DataAnnotations.Key()]");
					if (column.PrimaryKey || _currentView.Immutable || column.ComputedColumn)
						sb.AppendLine("		[System.ComponentModel.ReadOnly(true)]");

					if (!string.IsNullOrEmpty(column.Description))
						sb.AppendLine("		[System.ComponentModel.Description(\"" + StringHelper.ConvertTextToSingleLineCodeString(column.Description) + "\")]");

					sb.AppendLine("		[Widgetsphere.EFCore.Attributes.EntityFieldMetadata(\"" + column.PascalName + "\", " + column.SortOrder + ", " + column.UIVisible.ToString().ToLower() + ", " + column.Length + ", \"" + column.Mask + "\", \"" + column.GetFriendlyName() + "\", \"" + column.Default + "\", " + column.AllowNull.ToString().ToLower() + ", \"" + column.Description + "\", " + column.ComputedColumn.ToString().ToLower() + ", " + column.IsUnique.ToString().ToLower() + ", " + (double.IsNaN(column.Min) ? "double.NaN" : column.Min.ToString()) + ", " + (double.IsNaN(column.Max) ? "double.NaN" : column.Max.ToString()) + ", " + column.PrimaryKey.ToString().ToLower() + ")]");

					sb.AppendLine("		public virtual " + typeTable.PascalName + "Wrapper " + typeTable.PascalName);
					sb.AppendLine("		{");
					sb.AppendLine("			get { return _" + column.CamelName + "; }");
					
					//OLD CODE - we tried to hide the setter but serialization hates this
					//sb.AppendLine("			" + (column.PrimaryKey || _currentTable.Immutable ? "protected " : "") + "set");
					sb.AppendLine("			set");

					sb.AppendLine("			{");
					if (column.PrimaryKey)
					{
						sb.AppendLine("				ReportPropertyChanging(\"" + column.PascalName + "\");");
						sb.AppendLine("				this.OnPropertyChanging(\"" + column.PascalName + "\");");
						//sb.AppendLine("				_" + column.CamelName + " = StructuralObject.SetValidValue(value);");
						sb.AppendLine("				_" + column.CamelName + " = value;");
						sb.AppendLine("				ReportPropertyChanged(\"" + column.PascalName + "\");");
						sb.AppendLine("				this.OnPropertyChanged(\"" + column.PascalName + "\");");
					}
					else
					{
						sb.AppendLine("				Widgetsphere.EFCore.EventArgs.ChangingEventArgs<" + typeTable.PascalName + "Constants> eventArg = new Widgetsphere.EFCore.EventArgs.ChangingEventArgs<" + typeTable.PascalName + "Constants>(value, \"" + typeTable.PascalName + "\");");
						if (_model.EnableCustomChangeEvents)
							sb.AppendLine("				this.On" + typeTable.PascalName + "Changing(eventArg);");
						sb.AppendLine("				if (eventArg.Cancel) return;");
						sb.AppendLine("				ReportPropertyChanging(\"" + typeTable.PascalName + "\");");
						sb.AppendLine("				this.OnPropertyChanging(\"" + column.PascalName + "\");");
						//sb.AppendLine("				_" + column.CamelName + " = StructuralObject.SetValidValue(value);");
						sb.AppendLine("				_" + column.CamelName + " = eventArg.Value;");
						sb.AppendLine("				ReportPropertyChanged(\"" + typeTable.PascalName + "\");");
						sb.AppendLine("				this.OnPropertyChanged(\"" + column.PascalName + "\");");
						if (_model.EnableCustomChangeEvents)
							sb.AppendLine("				this.On" + typeTable.PascalName + "Changed(eventArg);");
					}
					sb.AppendLine("			}");
					sb.AppendLine("		}");
					sb.AppendLine();
				}
				else
				{
#endif
					sb.AppendLine("		/// <summary>");
					if (!string.IsNullOrEmpty(column.Description))
						sb.AppendLine("		/// " + column.Description + "");
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		[System.ComponentModel.Browsable(true)]");
					//sb.AppendLine("		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]");
					//sb.AppendLine("		[XmlElement(IsNullable=" + column.AllowNull.ToString().ToLower() + ")]");
					//sb.AppendLine("		[SoapElement(IsNullable=" + column.AllowNull.ToString().ToLower() + ")]");
					sb.AppendLine("		[EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = " + (column.AllowNull ? "true" : "false") + ")]");
					sb.AppendLine("		[DataMemberAttribute()]");
					sb.AppendLine("		[System.ComponentModel.DisplayName(\"" + column.GetFriendlyName() + "\")]");
					
					sb.AppendLine("		[System.ComponentModel.ReadOnly(true)]");

					if (!string.IsNullOrEmpty(column.Description))
						sb.AppendLine("		[System.ComponentModel.Description(\"" + StringHelper.ConvertTextToSingleLineCodeString(column.Description) + "\")]");

					sb.AppendLine("		public virtual " + column.GetCodeType() + " " + column.PascalName);
					sb.AppendLine("		{");
					sb.AppendLine("			get { return _" + column.CamelName + "; }");

					//OLD CODE - we tried to hide the setter but serialization hates this
					//sb.AppendLine("			" + (column.PrimaryKey || _currentTable.Immutable ? "protected " : "") + "set");
					sb.AppendLine("			set");

					sb.AppendLine("			{");

					//Error Check for field size
					if (ModelHelper.IsTextType(column.DataType))
					{
						sb.Append("				if ((value != null) && (value.Length > GetMaxLength(FieldNameConstants." + column.PascalName + ")))");
						sb.AppendLine(" throw new Exception(string.Format(GlobalValues.ERROR_DATA_TOO_BIG, value, \"" + _currentView.PascalName + "." + column.PascalName + "\", GetMaxLength(FieldNameConstants." + column.PascalName + ")));");
					}
					else if (column.DataType == System.Data.SqlDbType.DateTime)
					{
						//Error check date value
						sb.AppendLine("				if (" + (column.AllowNull ? "(value != null) && " : "") + "(value < GlobalValues.MIN_DATETIME)) throw new Exception(\"The DateTime value '" + column.PascalName + "' (\" + value" + (column.AllowNull ? ".Value" : "") + ".ToString(\"yyyy-MM-dd HH:mm:ss\") + \") cannot be less than \" + GlobalValues.MIN_DATETIME.ToString());");
						sb.AppendLine("				if (" + (column.AllowNull ? "(value != null) && " : "") + "(value > GlobalValues.MAX_DATETIME)) throw new Exception(\"The DateTime value '" + column.PascalName + "' (\" + value" + (column.AllowNull ? ".Value" : "") + ".ToString(\"yyyy-MM-dd HH:mm:ss\") + \") cannot be greater than \" + GlobalValues.MAX_DATETIME.ToString());");
					}

#if notdone
					if (column.PrimaryKey)
					{
						sb.AppendLine("				ReportPropertyChanging(\"" + column.PascalName + "\");");
						sb.AppendLine("				this.OnPropertyChanging(\"" + column.PascalName + "\");");
						//sb.AppendLine("				_" + column.CamelName + " = StructuralObject.SetValidValue(value);");
						sb.AppendLine("				_" + column.CamelName + " = value;");
						sb.AppendLine("				ReportPropertyChanged(\"" + column.PascalName + "\");");
						sb.AppendLine("				this.OnPropertyChanged(\"" + column.PascalName + "\");");
					}
					else
					{
#endif
						sb.AppendLine("				Widgetsphere.EFCore.EventArgs.ChangingEventArgs<" + column.GetCodeType() + "> eventArg = new Widgetsphere.EFCore.EventArgs.ChangingEventArgs<" + column.GetCodeType() + ">(, \"" + column.PascalName + "\");");
						if (_model.EnableCustomChangeEvents)
							sb.AppendLine("				this.On" + column.PascalName + "Changing(eventArg);");
						sb.AppendLine("				if (eventArg.Cancel) return;");
						sb.AppendLine("				ReportPropertyChanging(\"" + column.PascalName + "\");");
						sb.AppendLine("				this.OnPropertyChanging(\"" + column.PascalName + "\");");
						//sb.AppendLine("				_" + column.CamelName + " = StructuralObject.SetValidValue(value);");
						sb.AppendLine("				_" + column.CamelName + " = eventArg.Value;");
						sb.AppendLine("				ReportPropertyChanged(\"" + column.PascalName + "\");");
						sb.AppendLine("				this.OnPropertyChanged(\"" + column.PascalName + "\");");
						if (_model.EnableCustomChangeEvents)
							sb.AppendLine("				this.On" + column.PascalName + "Changed(eventArg);");
#if notdone
					}
#endif
					sb.AppendLine("			}");
					sb.AppendLine("		}");
					sb.AppendLine();
				}
#if notimplementedyet
			}
#endif

			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendGenerateEvents()
		{
			sb.AppendLine("		#region Events");
			sb.AppendLine();

			foreach (var column in _currentView.GetColumns().Where(x => x.Generated).OrderBy(x => x.Name))
			{
#if notdone
				if (_currentView.IsColumnRelatedToTypeTable(column))
				{
					Table typeTable = _currentView.GetRelatedTypeTableByColumn(column);

					//If this column is a type table column then generate a special property
					sb.AppendLine("		/// <summary>");
					sb.AppendLine("		/// The internal reference variable for the '" + column.PascalName + "' property");
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		protected " + typeTable.PascalName + "Wrapper _" + column.CamelName + ";");
					sb.AppendLine();
					this.AppendPropertyEventDeclarations(column, typeTable.PascalName + "Constants");
				}
				else
				{
#endif
					sb.AppendLine("		/// <summary>");
					sb.AppendLine("		/// The internal reference variable for the '" + column.PascalName + "' property");
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		protected " + column.GetCodeType() + " _" + column.CamelName + ";");
					sb.AppendLine();
					this.AppendPropertyEventDeclarations(column, column.GetCodeType());
				}
#if notdone
			}
#endif

			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendPropertyEventDeclarations(CustomViewColumn column, string codeType)
		{
#if notdone
			CustomView typetable = _currentView.GetRelatedTypeTableByColumn(column);
			if (typetable != null)
			{
				this.AppendPropertyEventDeclarations(typetable.PascalName, codeType);
			}
			else
			{
#endif
				this.AppendPropertyEventDeclarations(column.PascalName, codeType);
#if notdone
			}
#endif
		}

		private void AppendPropertyEventDeclarations(string columnName, string codeType)
		{
			//Do not support custom events
			if (!_model.EnableCustomChangeEvents) return;

			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Occurs when the '" + columnName + "' property value change is a pending.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public event EventHandler<Widgetsphere.EFCore.EventArgs.ChangingEventArgs<" + codeType + ">> " + columnName + "Changing;");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Raises the On" + columnName + "Changing event.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		protected virtual void On" + columnName + "Changing(Widgetsphere.EFCore.EventArgs.ChangingEventArgs<" + codeType + "> e)");
			sb.AppendLine("		{");
			sb.AppendLine("			if (this." + columnName + "Changing != null)");
			sb.AppendLine("				this." + columnName + "Changing(this, e);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Occurs when the '" + columnName + "' property value has changed.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public event EventHandler<ChangedEventArgs<" + codeType + ">> " + columnName + "Changed;");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Raises the On" + columnName + "Changed event.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		protected virtual void On" + columnName + "Changed(ChangedEventArgs<" + codeType + "> e)");
			sb.AppendLine("		{");
			sb.AppendLine("			if (this." + columnName + "Changed != null)");
			sb.AppendLine("				this." + columnName + "Changed(this, e);");
			sb.AppendLine("		}");
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
			foreach (var column in _currentView.GetColumns().Where(x => x.Generated).OrderBy(x => x.Name))
			{
				sb.AppendLine("				case FieldNameConstants." + column.PascalName + ":");
				if (_currentView.GeneratedColumns.Contains(column))
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
			}
			sb.AppendLine("			}");
			sb.AppendLine("			return 0;");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		int Widgetsphere.EFCore.DataAccess.IBusinessObject.GetMaxLength(Enum field)");
			sb.AppendLine("		{");
			sb.AppendLine("			return GetMaxLength((FieldNameConstants)field);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		System.Type Widgetsphere.EFCore.DataAccess.IBusinessObject.GetFieldNameConstants()");
			sb.AppendLine("		{");
			sb.AppendLine("			return typeof(FieldNameConstants);");
			sb.AppendLine("		}");
			sb.AppendLine();

			//If this is not derived then add the Primary key stuff
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Hold the primary key for this object");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		protected Widgetsphere.EFCore.DataAccess.IPrimaryKey _primaryKey = null;");
			sb.AppendLine("		Widgetsphere.EFCore.DataAccess.IPrimaryKey Widgetsphere.EFCore.DataAccess.IBusinessObject.PrimaryKey");
			sb.AppendLine("		{");
			sb.AppendLine("			get");
			sb.AppendLine("			{");
			sb.AppendLine("				return null;");
			sb.AppendLine("			}");
			sb.AppendLine("		}");
			sb.AppendLine();

			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void GenerateAuditField(string columnName, string codeType, string description, string propertyScope)
		{
			if (!string.IsNullOrEmpty(description))
			{
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// " + description);
				sb.AppendLine("		/// </summary>");
			}
			sb.AppendLine("		[EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]");
			sb.AppendLine("		[DataMemberAttribute()]");
			sb.AppendLine("		" + propertyScope + " virtual " + codeType + " " + columnName);
			sb.AppendLine("		{");
			sb.AppendLine("			get { return _" + StringHelper.DatabaseNameToCamelCase(columnName) + "; }");
			if (propertyScope == "public")
			{
				//OLD CODE - we tried to hide the setter but serialization hates this
				//sb.AppendLine("			protected internal set");
				sb.AppendLine("			set");
			}
			else
			{
				sb.AppendLine("			set");
			}

			sb.AppendLine("			{");
			sb.AppendLine("				Widgetsphere.EFCore.EventArgs.ChangingEventArgs<" + codeType + "> eventArg = new Widgetsphere.EFCore.EventArgs.ChangingEventArgs<" + codeType + ">(value, \"" + columnName + "\");");
			if (_model.EnableCustomChangeEvents)
				sb.AppendLine("				On" + columnName + "Changing(eventArg);");
			sb.AppendLine("				if (eventArg.Cancel) return;");
			sb.AppendLine("				ReportPropertyChanging(\"" + columnName + "\");");
			sb.AppendLine("				this.OnPropertyChanging(\"" + columnName + "\");");
			sb.AppendLine("				_" + StringHelper.DatabaseNameToCamelCase(columnName) + " = eventArg.Value;");
			sb.AppendLine("				ReportPropertyChanged(\"" + columnName + "\");");
			sb.AppendLine("				this.OnPropertyChanged(\"" + columnName + "\");");
			if (_model.EnableCustomChangeEvents)
				sb.AppendLine("				On" + columnName + "Changed(eventArg);");
			sb.AppendLine("			}");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// The internal reference variable for the '" + StringHelper.DatabaseNameToCamelCase(columnName) + "' property");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		protected " + codeType + " _" + StringHelper.DatabaseNameToCamelCase(columnName) + ";");
			sb.AppendLine();

		}

		private void AppendPagingClass()
		{
			sb.AppendLine("	#region " + _currentView.PascalName + "Paging");
			sb.AppendLine();
			sb.AppendLine("	/// <summary>");
			sb.AppendLine("	/// A field sort object for the " + _currentView.PascalName + "Paging object.");
			sb.AppendLine("	/// </summary>");
			sb.AppendLine("	[Serializable]");
			sb.AppendLine("	internal class " + _currentView.PascalName + "PagingFieldItem : IPagingFieldItem");
			sb.AppendLine("	{");
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Determines the direction of the sort.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public bool Ascending { get; set; }");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Determines the field on which to sort.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public " + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + ".FieldNameConstants Field { get; set; }");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Create a sorting field object for the " + _currentView.PascalName + "Paging object.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		/// <param name=\"field\">The field on which to sort.</param>");
			sb.AppendLine("		public " + _currentView.PascalName + "PagingFieldItem(" + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + ".FieldNameConstants field)");
			sb.AppendLine("		{");
			sb.AppendLine("			this.Field = field;");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Create a sorting field object for the " + _currentView.PascalName + "Paging object.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		/// <param name=\"field\">The field on which to sort.</param>");
			sb.AppendLine("		/// <param name=\"ascending\">Determines the direction of the sort.</param>");
			sb.AppendLine("		public " + _currentView.PascalName + "PagingFieldItem(" + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + ".FieldNameConstants field, bool ascending)");
			sb.AppendLine("			: this(field)");
			sb.AppendLine("		{");
			sb.AppendLine("			this.Ascending = ascending;");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#region IPagingFieldItem Members");
			sb.AppendLine();
			sb.AppendLine("		Enum IPagingFieldItem.GetField()");
			sb.AppendLine("		{");
			sb.AppendLine("			return this.Field;");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();
			sb.AppendLine("	}");
			sb.AppendLine();
			sb.AppendLine("	/// <summary>");
			sb.AppendLine("	/// The paging object for the " + _currentView.PascalName + " collection");
			sb.AppendLine("	/// </summary>");
			sb.AppendLine("	[Serializable]");
			sb.AppendLine("	internal class " + _currentView.PascalName + "Paging : Widgetsphere.EFCore.DataAccess.PagingBase<" + _currentView.PascalName + "PagingFieldItem>");
			sb.AppendLine("	{");
			sb.AppendLine();
			sb.AppendLine("		#region Constructors");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Creates a paging object");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public " + _currentView.PascalName + "Paging()");
			sb.AppendLine("			: this(1, 10, null)");
			sb.AppendLine("		{");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Creates a paging object");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		/// <param name=\"pageIndex\">The page number to load</param>");
			sb.AppendLine("		/// <param name=\"recordsperPage\">The number of records per page.</param>");
			sb.AppendLine("		public " + _currentView.PascalName + "Paging(int pageIndex, int recordsperPage)");
			sb.AppendLine("			: this(pageIndex, recordsperPage, null)");
			sb.AppendLine("		{");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Creates a paging object");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		/// <param name=\"pageIndex\">The page number to load</param>");
			sb.AppendLine("		/// <param name=\"recordsperPage\">The number of records per page.</param>");
			sb.AppendLine("		/// <param name=\"field\">The field on which to sort.</param>");
			sb.AppendLine("		/// <param name=\"ascending\">Determines the sorted direction.</param>");
			sb.AppendLine("		public " + _currentView.PascalName + "Paging(int pageIndex, int recordsperPage, " + this.GetLocalNamespace() + ".Entity." + _currentView.PascalName + ".FieldNameConstants field, bool ascending)");
			sb.AppendLine("			: this(pageIndex, recordsperPage, new " + _currentView.PascalName + "PagingFieldItem(field, ascending))");
			sb.AppendLine("		{");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Creates a paging object");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		/// <param name=\"pageIndex\">The page number to load</param>");
			sb.AppendLine("		/// <param name=\"recordsperPage\">The number of items per page.</param>");
			sb.AppendLine("		/// <param name=\"orderByField\">The field on which to sort.</param>");
			sb.AppendLine("		public " + _currentView.PascalName + "Paging(int pageIndex, int recordsperPage, " + _currentView.PascalName + "PagingFieldItem orderByField)");
			sb.AppendLine("			: base(pageIndex, recordsperPage, orderByField)");
			sb.AppendLine("		{");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();
			sb.AppendLine("	}");
			sb.AppendLine();
			sb.AppendLine("	#endregion");
			sb.AppendLine();
		}

		private void AppendRegionGetDatabaseFieldName()
		{
			sb.AppendLine("		#region GetDatabaseFieldName");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Returns the actual database name of the specified field.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		internal static string GetDatabaseFieldName(" + _currentView.PascalName + ".FieldNameConstants field)");
			sb.AppendLine("		{");
			sb.AppendLine("			return GetDatabaseFieldName(field.ToString());");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Returns the actual database name of the specified field.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		internal static string GetDatabaseFieldName(string field)");
			sb.AppendLine("		{");
			sb.AppendLine("			switch (field)");
			sb.AppendLine("			{");
			foreach (var column in _currentView.GeneratedColumns)
			{
				if (column.Generated)
					sb.AppendLine("				case \"" + column.PascalName + "\": return \"" + column.Name + "\";");
			}

			sb.AppendLine("			}");
			sb.AppendLine("			return string.Empty;");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		#endregion

	}
}
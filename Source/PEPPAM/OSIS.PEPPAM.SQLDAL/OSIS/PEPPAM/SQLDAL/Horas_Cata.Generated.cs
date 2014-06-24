//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Creador : Administrator
//    Dominio : OSISPC
//    Pc      : OSISPC
//    Fecha   : 6/19/2014 1:29:30 PM
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//     Autor: Francisco
//     Fecha: 6/19/2014 1:29:30 PM
// </auto-generated>
//------------------------------------------------------------------------------

 using System;
 using CodeFluent.Runtime;
 using CodeFluent.Runtime.Utilities;
  using System.Text.RegularExpressions;
  using System.Collections.Generic;
namespace OSIS.PEPPAM.BOM
{
	/// <summary>
	/// The collection to hold 'Horas_Cata' entities
	/// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MyWorkGenerators", "0.0.0.00000")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DataObjectAttribute()]
    [System.Diagnostics.DebuggerDisplayAttribute("EK={EntityKey},Hora_Desde={Hora_Desde}")]
    [System.ComponentModel.TypeConverterAttribute(typeof(CodeFluent.Runtime.Design.NameTypeConverter))]
	public partial class Horas_Cata :  System.ICloneable, System.IComparable, System.IComparable<OSIS.PEPPAM.BOM.Horas_Cata>, CodeFluent.Runtime.ICodeFluentEntity, System.ComponentModel.IDataErrorInfo, CodeFluent.Runtime.ICodeFluentMemberValidator, CodeFluent.Runtime.ICodeFluentSummaryValidator, System.IEquatable<OSIS.PEPPAM.BOM.Horas_Cata>

	{
		#region FieldNameConstants Enumeration

		/// <summary>
		/// Enumeration to define each property that maps to a database field for the 'Horas_Cata' table.
		/// </summary>
		public enum FieldNameConstants
		{
			/// <summary>
			/// Field mapping for the 'Hora_Desde' property
			/// </summary>
			[System.ComponentModel.Description("Field mapping for the 'Hora_Desde' property")]
			Hora_Desde,
			/// <summary>
			/// Field mapping for the 'Hora_Hasta' property
			/// </summary>
			[System.ComponentModel.Description("Field mapping for the 'Hora_Hasta' property")]
			Hora_Hasta,
			/// <summary>
			/// Field mapping for the 'Hora_Secuencia' property
			/// </summary>
			[System.ComponentModel.Description("Field mapping for the 'Hora_Secuencia' property")]
			Hora_Secuencia,
			/// <summary>
			/// Field mapping for the 'Registro_Estado' property
			/// </summary>
			[System.ComponentModel.Description("Field mapping for the 'Registro_Estado' property")]
			Registro_Estado,
			/// <summary>
			/// Field mapping for the 'Registro_Fecha' property
			/// </summary>
			[System.ComponentModel.Description("Field mapping for the 'Registro_Fecha' property")]
			Registro_Fecha,
			/// <summary>
			/// Field mapping for the 'Registro_Usuario' property
			/// </summary>
			[System.ComponentModel.Description("Field mapping for the 'Registro_Usuario' property")]
			Registro_Usuario,
		}
		#endregion

        private bool _raisePropertyChangedEvents = true;
        
        private CodeFluent.Runtime.CodeFluentEntityState _entityState;
        
		#region Property Holders

		/// <summary />
		protected string _hora_Desde = string.Empty;
		/// <summary />
		protected string _hora_Hasta = string.Empty;
		/// <summary />
		protected int _hora_Secuencia = -1;
		/// <summary />
		protected string _registro_Estado = string.Empty;
		/// <summary />
		protected DateTime _registro_Fecha = System.DateTime.MinValue;
		/// <summary />
		protected string _registro_Usuario = string.Empty;

		#endregion

		#region Property Navigation Holders

		/// <summary>
		/// The back navigation definition for walking [Horas_Cata]->[Personas_Diponibilidad]
		/// Relationship Links: 
		/// [Horas_Cata.Hora_Secuencia = Personas_Diponibilidad.Hora_Secuencia] (Required)
		/// <summary />
		protected Personas_DiponibilidadCollection _personas_Diponibilidad =  null;


		#endregion

		#region GetMaxLength

		/// <summary>
		/// Gets the maximum size of the field value.
		/// </summary>
		public static int GetMaxLength(FieldNameConstants field)
		{
			switch (field)
			{
				case FieldNameConstants.Hora_Desde:
					return 50;
				case FieldNameConstants.Hora_Hasta:
					return 50;
				case FieldNameConstants.Hora_Secuencia:
					return 0;
				case FieldNameConstants.Registro_Estado:
					return 1;
				case FieldNameConstants.Registro_Fecha:
					return 0;
				case FieldNameConstants.Registro_Usuario:
					return 50;
			}
			return 0;
		}


		#endregion

		#region GetFieldType

		/// <summary>
		/// Gets the system type of a field on this object
		/// </summary>
		public static System.Type GetFieldType(FieldNameConstants field)
		{
			if (field.GetType() != typeof(FieldNameConstants))
				throw new Exception("The '" + field.GetType().ReflectedType.ToString() + ".FieldNameConstants' value is not valid. The field parameter must be of type 'OSIS.PEPPAM.BOM.Entity.Horas_Cata.FieldNameConstants'.");

			switch ((FieldNameConstants)field)
			{
				case FieldNameConstants.Hora_Desde: return typeof(string);
				case FieldNameConstants.Hora_Hasta: return typeof(string);
				case FieldNameConstants.Hora_Secuencia: return typeof(int);
				case FieldNameConstants.Registro_Estado: return typeof(string);
				case FieldNameConstants.Registro_Fecha: return typeof(DateTime);
				case FieldNameConstants.Registro_Usuario: return typeof(string);
			}
			return null;
		}


		#endregion

		#region Get/Set Value


		#endregion

        public Horas_Cata()
        {
            this._entityState = CodeFluent.Runtime.CodeFluentEntityState.Created;
        }
        
		#region Properties

        [System.ComponentModel.BrowsableAttribute(false)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool RaisePropertyChangedEvents
        {
            get
            {
                return this._raisePropertyChangedEvents;
            }
            set
            {
                this._raisePropertyChangedEvents = value;
            }
        }
        
		/// <summary>
		/// The property that maps back to the database 'Horas_Cata.Hora_Secuencia' field.
		/// </summary>
		/// <remarks>Field: [Horas_Cata].[Hora_Secuencia], Not Nullable, Primary Key, Unique, Indexed</remarks>
		[System.ComponentModel.Browsable(true)]
		[System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Type=typeof(int))]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[System.ComponentModel.DisplayName("Hora_Secuencia")]
		public virtual int Hora_Secuencia
		{
			get { 
			return _hora_Secuencia; }
			set
			{
				if (value == _hora_Secuencia) return;
                this._hora_Secuencia = value;
                this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Hora_Secuencia"));
			}
		}

		/// <summary>
		/// The property that maps back to the database 'Horas_Cata.Hora_Desde' field.
		/// </summary>
		/// <remarks>Field: [Horas_Cata].[Hora_Desde], Field Length: 50, Not Nullable</remarks>
		[System.ComponentModel.Browsable(true)]
		[System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Type=typeof(string))]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[System.ComponentModel.DisplayName("Hora_Desde")]
		public virtual string Hora_Desde
		{
			get { 
			return _hora_Desde; }
			set
			{
				if ((value != null) && (value.Length > GetMaxLength(FieldNameConstants.Hora_Desde))) throw new Exception(string.Format(GlobalValues.ERROR_DATA_TOO_BIG, value, "Horas_Cata.Hora_Desde", GetMaxLength(FieldNameConstants.Hora_Desde)));
				if (value == _hora_Desde) return;
                this._hora_Desde = value;
                this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Hora_Desde"));
			}
		}

		/// <summary>
		/// The property that maps back to the database 'Horas_Cata.Hora_Hasta' field.
		/// </summary>
		/// <remarks>Field: [Horas_Cata].[Hora_Hasta], Field Length: 50, Not Nullable</remarks>
		[System.ComponentModel.Browsable(true)]
		[System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Type=typeof(string))]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[System.ComponentModel.DisplayName("Hora_Hasta")]
		public virtual string Hora_Hasta
		{
			get { 
			return _hora_Hasta; }
			set
			{
				if ((value != null) && (value.Length > GetMaxLength(FieldNameConstants.Hora_Hasta))) throw new Exception(string.Format(GlobalValues.ERROR_DATA_TOO_BIG, value, "Horas_Cata.Hora_Hasta", GetMaxLength(FieldNameConstants.Hora_Hasta)));
				if (value == _hora_Hasta) return;
                this._hora_Hasta = value;
                this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Hora_Hasta"));
			}
		}

		/// <summary>
		/// The property that maps back to the database 'Horas_Cata.Registro_Estado' field.
		/// </summary>
		/// <remarks>Field: [Horas_Cata].[Registro_Estado], Field Length: 1, Not Nullable</remarks>
		[System.ComponentModel.Browsable(true)]
		[System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Type=typeof(string))]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[System.ComponentModel.DisplayName("Registro_Estado")]
		public virtual string Registro_Estado
		{
			get { 
			return _registro_Estado; }
			set
			{
				if ((value != null) && (value.Length > GetMaxLength(FieldNameConstants.Registro_Estado))) throw new Exception(string.Format(GlobalValues.ERROR_DATA_TOO_BIG, value, "Horas_Cata.Registro_Estado", GetMaxLength(FieldNameConstants.Registro_Estado)));
				if (value == _registro_Estado) return;
                this._registro_Estado = value;
                this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Registro_Estado"));
			}
		}

		/// <summary>
		/// The property that maps back to the database 'Horas_Cata.Registro_Fecha' field.
		/// </summary>
		/// <remarks>Field: [Horas_Cata].[Registro_Fecha], Not Nullable</remarks>
		[System.ComponentModel.Browsable(true)]
		[System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Type=typeof(DateTime))]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[System.ComponentModel.DisplayName("Registro_Fecha")]
		public virtual DateTime Registro_Fecha
		{
			get { 
			return _registro_Fecha; }
			set
			{
				if ((value < GlobalValues.MIN_DATETIME)) throw new Exception("The DateTime value 'Registro_Fecha' (" + value.ToString("yyyy-MM-dd HH:mm:ss") + ") cannot be less than " + GlobalValues.MIN_DATETIME.ToString());
				if ((value > GlobalValues.MAX_DATETIME)) throw new Exception("The DateTime value 'Registro_Fecha' (" + value.ToString("yyyy-MM-dd HH:mm:ss") + ") cannot be greater than " + GlobalValues.MAX_DATETIME.ToString());
				if (value == _registro_Fecha) return;
                this._registro_Fecha = value;
                this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Registro_Fecha"));
			}
		}

		/// <summary>
		/// The property that maps back to the database 'Horas_Cata.Registro_Usuario' field.
		/// </summary>
		/// <remarks>Field: [Horas_Cata].[Registro_Usuario], Field Length: 50, Not Nullable</remarks>
		[System.ComponentModel.Browsable(true)]
		[System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Type=typeof(string))]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[System.ComponentModel.DisplayName("Registro_Usuario")]
		public virtual string Registro_Usuario
		{
			get { 
			return _registro_Usuario; }
			set
			{
				if ((value != null) && (value.Length > GetMaxLength(FieldNameConstants.Registro_Usuario))) throw new Exception(string.Format(GlobalValues.ERROR_DATA_TOO_BIG, value, "Horas_Cata.Registro_Usuario", GetMaxLength(FieldNameConstants.Registro_Usuario)));
				if (value == _registro_Usuario) return;
                this._registro_Usuario = value;
                this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Registro_Usuario"));
			}
		}


		#endregion

		#region Navigation Properties

		/// <summary>
		/// The back navigation definition for walking [Horas_Cata]->[Personas_Diponibilidad]
		/// Relationship Links: 
		/// [Horas_Cata.Hora_Secuencia = Personas_Diponibilidad.Hora_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual OSIS.PEPPAM.BOM.Personas_DiponibilidadCollection PersonasDiponibilidad
        {
            get
            {
                if ((this._personas_Diponibilidad == null))
                {
                    if ((
                    (this.Hora_Secuencia == -1)
                       )
                         || (this.EntityState.Equals(CodeFluent.Runtime.CodeFluentEntityState.Created) == true))
                    {
                        this._personas_Diponibilidad = new OSIS.PEPPAM.BOM.Personas_DiponibilidadCollection(null,this,null);
                        return this._personas_Diponibilidad;
                    }
                    this._personas_Diponibilidad = OSIS.PEPPAM.BOM.Personas_DiponibilidadCollection.LoadByHorasCata(this);
                }
                return this._personas_Diponibilidad;
            }
        }

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Hora_Secuencia.ToString();
            }
            set
            {
               this.Hora_Secuencia = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Hora_Desde.ToString();
            }
        }
        
        [field:System.NonSerializedAttribute()]
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        [field:System.NonSerializedAttribute()]
        public event CodeFluent.Runtime.CodeFluentEntityActionEventHandler EntityAction;

        protected virtual void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((this.RaisePropertyChangedEvents == false))
            {
                return;
            }
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, e);
            }
        }

        protected virtual void OnEntityAction(CodeFluent.Runtime.CodeFluentEntityActionEventArgs e)
        {
            if ((this.EntityAction != null))
            {
                this.EntityAction(this, e);
            }
        }

        string System.ComponentModel.IDataErrorInfo.Error
        {
            get
            {
                return this.Validate(System.Globalization.CultureInfo.CurrentCulture);
            }
        }
        
        string System.ComponentModel.IDataErrorInfo.this[string columnName]
        {
            get
            {
                return CodeFluentPersistence.ValidateMember(System.Globalization.CultureInfo.CurrentCulture, this, columnName, null);
            }
        }
        
        public virtual CodeFluent.Runtime.CodeFluentEntityState EntityState
        {
            get
            {
                return this._entityState;
            }
            set
            {
                if ((System.Collections.Generic.EqualityComparer<CodeFluent.Runtime.CodeFluentEntityState>.Default.Equals(value, this.EntityState) == true))
                {
                    return;
                }
                this._entityState = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("EntityState"));
            }
        }
        
        public virtual bool Equals(OSIS.PEPPAM.BOM.Horas_Cata horasCata)
        {
            if ((horasCata == null))
            {
                return false;
            }

            if (
                    (this.Hora_Secuencia == -1)
            )
            {
                return base.Equals(horasCata);
            }

 return ((
                    (this.Hora_Secuencia.Equals(horasCata.Hora_Secuencia))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.BOM.Horas_Cata horasCata = null;
			 horasCata = obj as OSIS.PEPPAM.BOM.Horas_Cata;
            return this.Equals( horasCata);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        int System.IComparable.CompareTo(object value)
        {
            OSIS.PEPPAM.BOM.Horas_Cata horasCata = null;
             horasCata = value as OSIS.PEPPAM.BOM.Horas_Cata;
            if ((horasCata == null))
            {
                throw new System.ArgumentException("value");
            }
            int localCompareTo = this.CompareTo(horasCata);
            return localCompareTo;
        }

        public virtual int CompareTo(OSIS.PEPPAM.BOM.Horas_Cata horasCata)
        {
            if ((horasCata == null))
            {
                throw new System.ArgumentNullException("horasCata");
            }
            int localCompareTo = this.Hora_Secuencia.CompareTo(horasCata.Hora_Secuencia);
            return localCompareTo;
        }

        public virtual string Validate(System.Globalization.CultureInfo culture)
        {
            return CodeFluentPersistence.Validate(culture, this, null);
        }
        
        public virtual void Validate(System.Globalization.CultureInfo culture, System.Collections.Generic.IList<CodeFluent.Runtime.CodeFluentValidationException> results)
        {
            CodeFluent.Runtime.CodeFluentEntityActionEventArgs evt = new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.Validating, true, results);
            evt.Culture = culture;
            this.OnEntityAction(evt);
            if ((evt.Cancel == true))
            {
                string externalValidate;
                if ((evt.Argument != null))
                {
                    externalValidate = evt.Argument.ToString();
                }
                else
                {
                    externalValidate = OSIS.PEPPAM.BOM.Resources.Manager.GetStringWithDefault(culture, "OSIS.PEPPAM.BOM.Horas_Cata.ExternalValidate", "Type 'OSIS.PEPPAM.BOM.Horas_Cata' cannot be validated.", null);
                }
                CodeFluentPersistence.AddValidationError(results, externalValidate);
            }
            CodeFluentPersistence.ValidateMember(culture, results, this, null);
            this.OnEntityAction(new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.Validated, false, results));
        }
        
        public void Validate()
        {
            string var = this.Validate(System.Globalization.CultureInfo.CurrentCulture);
            if ((var != null))
            {
                throw new CodeFluent.Runtime.CodeFluentValidationException(var);
            }
        }
        
        string CodeFluent.Runtime.ICodeFluentValidator.Validate(System.Globalization.CultureInfo culture)
        {
            string localValidate = this.Validate(culture);
            return localValidate;
        }
        
        void CodeFluent.Runtime.ICodeFluentMemberValidator.Validate(System.Globalization.CultureInfo culture, string memberName, System.Collections.Generic.IList<CodeFluent.Runtime.CodeFluentValidationException> results)
        {
            this.ValidateMember(culture, memberName, results);
        }
        
        protected virtual void ValidateMember(System.Globalization.CultureInfo culture, string memberName, System.Collections.Generic.IList<CodeFluent.Runtime.CodeFluentValidationException> results)
        {
        }
        
        protected virtual void ReadRecord(System.Data.IDataReader reader, CodeFluent.Runtime.CodeFluentReloadOptions options)
        {
            if ((reader == null))
            {
                throw new System.ArgumentNullException("reader");
            }
            if ((((options & CodeFluent.Runtime.CodeFluentReloadOptions.Properties) 
                        == 0) 
                        == false))
            {
                this._hora_Desde = CodeFluentPersistence.GetReaderValue(reader, "Hora_Desde", (default(string)));
                this._hora_Hasta = CodeFluentPersistence.GetReaderValue(reader, "Hora_Hasta", (default(string)));
                this._hora_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Hora_Secuencia", (default(int)));
                this._registro_Estado = CodeFluentPersistence.GetReaderValue(reader, "Registro_Estado", (default(string)));
                this._registro_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Registro_Fecha", (default(DateTime)));
                this._registro_Usuario = CodeFluentPersistence.GetReaderValue(reader, "Registro_Usuario", (default(string)));
            }
            this.OnEntityAction(new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.ReadRecord, false, false));
        }

        void CodeFluent.Runtime.ICodeFluentEntity.ReadRecord(System.Data.IDataReader reader)
        {
            this.ReadRecord(reader, CodeFluent.Runtime.CodeFluentReloadOptions.Default);
        }

        protected virtual void ReadRecordOnSave(System.Data.IDataReader reader)
        {
            if ((reader == null))
            {
                throw new System.ArgumentNullException("reader");
            }
            //TODO: Puede ser que solo sean los Identity y no todo los primary keys
            this._hora_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Hora_Secuencia", ((int)(-1)));
            this.OnEntityAction(new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.ReadRecordOnSave, false, false));
        }

        void CodeFluent.Runtime.ICodeFluentEntity.ReadRecordOnSave(System.Data.IDataReader reader)
        {
            this.ReadRecordOnSave(reader);
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static OSIS.PEPPAM.BOM.Horas_Cata Load(int hora_Secuencia)
        {
            if ((hora_Secuencia == default(int)))
            {
                return null;
            }
            OSIS.PEPPAM.BOM.Horas_Cata horasCata = new OSIS.PEPPAM.BOM.Horas_Cata();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horas_Cata", null,  "Proc_Horas_Cata");
            persistence.AddRawParameter("@Hora_Secuencia", hora_Secuencia);
            System.Data.IDataReader reader = null;
            try
            {
                reader = persistence.ExecuteReader();
                if ((reader.Read() == true))
                {
                    horasCata.ReadRecord(reader, CodeFluent.Runtime.CodeFluentReloadOptions.Default);
                    horasCata.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Unchanged;
                    return horasCata;
                }
            }
            finally
            {
                if ((reader != null))
                {
                    reader.Dispose();
                }
                persistence.CompleteCommand();
            }
            return null;
        }

        public virtual bool Reload(CodeFluent.Runtime.CodeFluentReloadOptions options)
        {
            bool ret = false;
            if (
            (this.Hora_Secuencia == -1) 
              )
            {
                return ret;
            }
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horas_Cata", null,  "Proc_Horas_Cata");
            persistence.AddRawParameter("@Hora_Secuencia", this.Hora_Secuencia);
            System.Data.IDataReader reader = null;
            try
            {
                reader = persistence.ExecuteReader();
                if ((reader.Read() == true))
                {
                    this.ReadRecord(reader, options);
                    this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Unchanged;
                    ret = true;
                }
                else
                {
                    this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Deleted;
                }
            }
            finally
            {
                if ((reader != null))
                {
                    reader.Dispose();
                }
                persistence.CompleteCommand();
            }
            return ret;
        }

        protected virtual bool BaseSave(bool force)
        {
            if ((this.EntityState == CodeFluent.Runtime.CodeFluentEntityState.ToBeDeleted))
            {
                this.Delete();
                return false;
            }
            CodeFluent.Runtime.CodeFluentEntityActionEventArgs evt = new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.Saving, true);
            this.OnEntityAction(evt);
            if ((evt.Cancel == true))
            {
                return false;
            }
            CodeFluentPersistence.ThrowIfDeleted(this);
            this.Validate();
            if (((force == false) 
                        && (this.EntityState == CodeFluent.Runtime.CodeFluentEntityState.Unchanged)))
            {
                return false;
            }
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horas_Cata", "Editar");
            persistence.AddRawParameter("@Hora_Secuencia", Hora_Secuencia);
            persistence.AddRawParameter("@Hora_Desde", Hora_Desde);
            persistence.AddRawParameter("@Hora_Hasta", Hora_Hasta);
            persistence.AddRawParameter("@Registro_Estado", Registro_Estado);
            persistence.AddRawParameter("@Registro_Fecha", Registro_Fecha);
            persistence.AddRawParameter("@Registro_Usuario", Registro_Usuario);
            System.Data.IDataReader reader = null;
            try
            {
                reader = persistence.ExecuteReader();
                if ((reader.Read() == true))
                {
                    this.ReadRecordOnSave(reader);
                }
                CodeFluentPersistence.NextResults(reader);
            }
            finally
            {
                if ((reader != null))
                {
                    reader.Dispose();
                }
                persistence.CompleteCommand();
            }
            this.OnEntityAction(new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.Saved, false, false));
            this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Unchanged;
            return true;
        }
        
        public virtual bool Save()
        {
            bool localSave = this.BaseSave(false);
            return localSave;
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool Save(OSIS.PEPPAM.BOM.Horas_Cata horasCata)
        {
            if ((horasCata == null))
            {
                return false;
            }
            bool ret = horasCata.Save();
            return ret;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool Insert(OSIS.PEPPAM.BOM.Horas_Cata horasCata)
        {
            bool ret = OSIS.PEPPAM.BOM.Horas_Cata.Save(horasCata);
            return ret;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static bool Delete(OSIS.PEPPAM.BOM.Horas_Cata horasCata)
        {
            if ((horasCata == null))
            {
                return false;
            }
            bool ret = horasCata.Delete();
            return ret;
        }

        public virtual bool Delete()
        {
            bool ret = false;
            CodeFluent.Runtime.CodeFluentEntityActionEventArgs evt = new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.Deleting, true);
            this.OnEntityAction(evt);
            if ((evt.Cancel == true))
            {
                return ret;
            }
            if ((this.EntityState == CodeFluent.Runtime.CodeFluentEntityState.Deleted))
            {
                return ret;
            }
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horas_Cata", "Borrar");
            persistence.AddRawParameter("@Hora_Secuencia", this.Hora_Secuencia);
            persistence.ExecuteNonQuery();
            this.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Deleted;
            this.OnEntityAction(new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.Deleted, false, false));
            ret = true;
            return ret;
        }

        public string Trace()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(stringBuilder, System.Globalization.CultureInfo.CurrentCulture);
            System.CodeDom.Compiler.IndentedTextWriter writer = new System.CodeDom.Compiler.IndentedTextWriter(stringWriter);
            this.BaseTrace(writer);
            writer.Flush();
            ((System.IDisposable)(writer)).Dispose();
            ((System.IDisposable)(stringWriter)).Dispose();
            string sr = stringBuilder.ToString();
            return sr;
        }

        void CodeFluent.Runtime.ICodeFluentObject.Trace(System.CodeDom.Compiler.IndentedTextWriter writer)
        {
            this.BaseTrace(writer);
        }

        protected virtual void BaseTrace(System.CodeDom.Compiler.IndentedTextWriter writer)
        {
            writer.Write("[");
            writer.Write("Hora_Desde=");
            writer.Write(this.Hora_Desde);
            writer.Write(",");
            writer.WriteLine("");
            writer.Write("Hora_Hasta=");
            writer.Write(this.Hora_Hasta);
            writer.Write(",");
            writer.WriteLine("");
            writer.Write("Hora_Secuencia=");
            writer.Write(this.Hora_Secuencia);
            writer.Write(",");
            writer.WriteLine("");
            writer.Write("Registro_Estado=");
            writer.Write(this.Registro_Estado);
            writer.Write(",");
            writer.WriteLine("");
            writer.Write("Registro_Fecha=");
            writer.Write(this.Registro_Fecha);
            writer.Write(",");
            writer.WriteLine("");
            writer.Write("Registro_Usuario=");
            writer.Write(this.Registro_Usuario);
            writer.Write(",");
            writer.WriteLine("");
            writer.Write(" PersonasDiponibilidad=");
            if ((this._personas_Diponibilidad != null))
            {
                ((CodeFluent.Runtime.ICodeFluentObject)(this._personas_Diponibilidad)).Trace(writer);
            }
            else
            {
                writer.Write("<null>");
            }
            writer.Write(",");
            writer.Write(", EntityState=");
            writer.Write(this.EntityState);
            writer.Write("]");
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static OSIS.PEPPAM.BOM.Horas_Cata LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.BOM.Horas_Cata horasCata;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            horasCata = OSIS.PEPPAM.BOM.Horas_Cata.Load( var0);
            return horasCata;
        }

        public  OSIS.PEPPAM.BOM.Horas_Cata Clone(bool deep)
        {
             OSIS.PEPPAM.BOM.Horas_Cata  horasCata = new  OSIS.PEPPAM.BOM.Horas_Cata();
            this.CopyTo(horasCata , deep);
            return horasCata ;
        }

        public OSIS.PEPPAM.BOM.Horas_Cata Clone()
        {
            OSIS.PEPPAM.BOM.Horas_Cata localClone = this.Clone(true);
            return localClone;
        }

        object System.ICloneable.Clone()
        {
            object localClone = this.Clone();
            return localClone;
        }

        public virtual void CopyFrom(System.Collections.IDictionary dict, bool deep)
        {
            if ((dict == null))
            {
                throw new System.ArgumentNullException("dict");
            }
            if ((dict.Contains("Hora_Desde") == true))
            {
                this.Hora_Desde = ((string)(ConvertUtilities.ChangeType(dict["Hora_Desde"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Hora_Hasta") == true))
            {
                this.Hora_Hasta = ((string)(ConvertUtilities.ChangeType(dict["Hora_Hasta"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Hora_Secuencia") == true))
            {
                this.Hora_Secuencia = ((int)(ConvertUtilities.ChangeType(dict["Hora_Secuencia"], typeof(int), -1)));
            }
            if ((dict.Contains("Registro_Estado") == true))
            {
                this.Registro_Estado = ((string)(ConvertUtilities.ChangeType(dict["Registro_Estado"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Registro_Fecha") == true))
            {
                this.Registro_Fecha = ((DateTime)(ConvertUtilities.ChangeType(dict["Registro_Fecha"], typeof(DateTime), System.DateTime.MinValue)));
            }
            if ((dict.Contains("Registro_Usuario") == true))
            {
                this.Registro_Usuario = ((string)(ConvertUtilities.ChangeType(dict["Registro_Usuario"], typeof(string), string.Empty)));
            }
            this.OnEntityAction(new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.CopyFrom, false, dict));
        }

        public virtual void CopyTo( OSIS.PEPPAM.BOM.Horas_Cata  horasCata, bool deep)
        {
            if ((horasCata == null))
            {
                throw new System.ArgumentNullException("horasCata");
            }
            horasCata.Hora_Desde = this.Hora_Desde;
            horasCata.Hora_Hasta = this.Hora_Hasta;
            horasCata.Hora_Secuencia = this.Hora_Secuencia;
            horasCata.Registro_Estado = this.Registro_Estado;
            horasCata.Registro_Fecha = this.Registro_Fecha;
            horasCata.Registro_Usuario = this.Registro_Usuario;
            this.OnEntityAction(new CodeFluent.Runtime.CodeFluentEntityActionEventArgs(this, CodeFluent.Runtime.CodeFluentEntityAction.CopyTo, false, horasCata));
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
		#region Static SQL Methods

		internal static string GetFieldAliasFromFieldNameSqlMapping(string alias)
		{
			alias = alias.Replace("[", string.Empty).Replace("]", string.Empty);
			switch (alias.ToLower())
			{
				case "hora_desde": return "hora_desde";
				case "hora_hasta": return "hora_hasta";
				case "hora_secuencia": return "hora_secuencia";
				case "registro_estado": return "registro_estado";
				case "registro_fecha": return "registro_fecha";
				case "registro_usuario": return "registro_usuario";
				default: throw new Exception("The select clause is not valid.");
			}
		}

		internal static string GetTableFromFieldAliasSqlMapping(string alias)
		{
			switch (alias.ToLower())
			{
				case "hora_desde": return "Horas_Cata";
				case "hora_hasta": return "Horas_Cata";
				case "hora_secuencia": return "Horas_Cata";
				case "registro_estado": return "Horas_Cata";
				case "registro_fecha": return "Horas_Cata";
				case "registro_usuario": return "Horas_Cata";
				default: throw new Exception("The select clause is not valid.");
			}
		}

		internal static string GetTableFromFieldNameSqlMapping(string field)
		{
			switch (field.ToLower())
			{
				case "hora_desde": return "Horas_Cata";
				case "hora_hasta": return "Horas_Cata";
				case "hora_secuencia": return "Horas_Cata";
				case "registro_estado": return "Horas_Cata";
				case "registro_fecha": return "Horas_Cata";
				case "registro_usuario": return "Horas_Cata";
				default: throw new Exception("The select clause is not valid.");
			}
		}

		internal static string GetRemappedLinqSql(string sql, string parentAlias, LinqSQLFromClauseCollection childTables)
		{
			sql = System.Text.RegularExpressions.Regex.Replace(sql, "\\[" + parentAlias + "\\]\\.\\[hora_desde\\]", "[" + childTables.GetBaseAliasTable(parentAlias, "Horas_Cata") + "].[hora_desde]", RegexOptions.IgnoreCase);
			sql = System.Text.RegularExpressions.Regex.Replace(sql, "\\[" + parentAlias + "\\]\\.\\[hora_hasta\\]", "[" + childTables.GetBaseAliasTable(parentAlias, "Horas_Cata") + "].[hora_hasta]", RegexOptions.IgnoreCase);
			sql = System.Text.RegularExpressions.Regex.Replace(sql, "\\[" + parentAlias + "\\]\\.\\[hora_secuencia\\]", "[" + childTables.GetBaseAliasTable(parentAlias, "Horas_Cata") + "].[hora_secuencia]", RegexOptions.IgnoreCase);
			sql = System.Text.RegularExpressions.Regex.Replace(sql, "\\[" + parentAlias + "\\]\\.\\[registro_estado\\]", "[" + childTables.GetBaseAliasTable(parentAlias, "Horas_Cata") + "].[registro_estado]", RegexOptions.IgnoreCase);
			sql = System.Text.RegularExpressions.Regex.Replace(sql, "\\[" + parentAlias + "\\]\\.\\[registro_fecha\\]", "[" + childTables.GetBaseAliasTable(parentAlias, "Horas_Cata") + "].[registro_fecha]", RegexOptions.IgnoreCase);
			sql = System.Text.RegularExpressions.Regex.Replace(sql, "\\[" + parentAlias + "\\]\\.\\[registro_usuario\\]", "[" + childTables.GetBaseAliasTable(parentAlias, "Horas_Cata") + "].[registro_usuario]", RegexOptions.IgnoreCase);
			return sql;
		}

		#endregion


	}

}

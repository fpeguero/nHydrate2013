//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Creador : Administrator
//    Dominio : OSISPC
//    Pc      : OSISPC
//    Fecha   : 6/19/2014 1:29:31 PM
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
//     Fecha: 6/19/2014 1:29:31 PM
// </auto-generated>
//------------------------------------------------------------------------------

 using System;
 using System.Runtime.Serialization;
 using CodeFluent.Runtime;
 using CodeFluent.Runtime.Utilities;
 using System.Collections.Generic;
namespace OSIS.PEPPAM.BOM
{
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DataObjectAttribute()]
    public partial class Proc_Puesto_Horarios_Pesonas : CodeFluent.Runtime.ICodeFluentLightEntity, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool _raisePropertyChangedEvents = true;

        
		#region Property Holders


		#endregion



        
        public Proc_Puesto_Horarios_Pesonas()
        {
        }

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
        
		#region Primitive Properties

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Congregacion_Nombre
		{
			get { return _congregacion_Nombre; }
			protected set
			{
				_congregacion_Nombre = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Congregacion_Nombre"));
			}
		}
		protected string _congregacion_Nombre = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Congregacion_Secuencia
		{
			get { return _congregacion_Secuencia; }
			protected set
			{
				_congregacion_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Congregacion_Secuencia"));
			}
		}
		protected int? _congregacion_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Dia_Secuencia
		{
			get { return _dia_Secuencia; }
			protected set
			{
				_dia_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Dia_Secuencia"));
			}
		}
		protected int? _dia_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Dia_Secuencia1
		{
			get { return _dia_Secuencia1; }
			protected set
			{
				_dia_Secuencia1 = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Dia_Secuencia1"));
			}
		}
		protected int? _dia_Secuencia1 = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Horario_Turno_Secuencia
		{
			get { return _horario_Turno_Secuencia; }
			protected set
			{
				_horario_Turno_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Turno_Secuencia"));
			}
		}
		protected int? _horario_Turno_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Persona_Apellidos
		{
			get { return _persona_Apellidos; }
			protected set
			{
				_persona_Apellidos = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Persona_Apellidos"));
			}
		}
		protected string _persona_Apellidos = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Persona_Conyuge_Apellido
		{
			get { return _persona_Conyuge_Apellido; }
			protected set
			{
				_persona_Conyuge_Apellido = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Persona_Conyuge_Apellido"));
			}
		}
		protected string _persona_Conyuge_Apellido = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Persona_Nombres
		{
			get { return _persona_Nombres; }
			protected set
			{
				_persona_Nombres = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Persona_Nombres"));
			}
		}
		protected string _persona_Nombres = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Persona_Secuencia
		{
			get { return _persona_Secuencia; }
			protected set
			{
				_persona_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Persona_Secuencia"));
			}
		}
		protected int? _persona_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Persona_Sexo
		{
			get { return _persona_Sexo; }
			protected set
			{
				_persona_Sexo = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Persona_Sexo"));
			}
		}
		protected string _persona_Sexo = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Persona_Turno_HC
		{
			get { return _persona_Turno_HC; }
			protected set
			{
				_persona_Turno_HC = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Persona_Turno_HC"));
			}
		}
		protected string _persona_Turno_HC = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Registro_Estado
		{
			get { return _registro_Estado; }
			protected set
			{
				_registro_Estado = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Registro_Estado"));
			}
		}
		protected string _registro_Estado = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(DateTime?))]
		[DataMemberAttribute()]
		public DateTime? Registro_Fecha
		{
			get { return _registro_Fecha; }
			protected set
			{
				_registro_Fecha = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Registro_Fecha"));
			}
		}
		protected DateTime? _registro_Fecha = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(DateTime?))]
		[DataMemberAttribute()]
		public DateTime? Registro_Fecha1
		{
			get { return _registro_Fecha1; }
			protected set
			{
				_registro_Fecha1 = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Registro_Fecha1"));
			}
		}
		protected DateTime? _registro_Fecha1 = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Registro_Usuario
		{
			get { return _registro_Usuario; }
			protected set
			{
				_registro_Usuario = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Registro_Usuario"));
			}
		}
		protected string _registro_Usuario = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Turno_Estado
		{
			get { return _turno_Estado; }
			protected set
			{
				_turno_Estado = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Estado"));
			}
		}
		protected string _turno_Estado = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Turno_Estudios_Iniciado_Cantidad
		{
			get { return _turno_Estudios_Iniciado_Cantidad; }
			protected set
			{
				_turno_Estudios_Iniciado_Cantidad = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Estudios_Iniciado_Cantidad"));
			}
		}
		protected int? _turno_Estudios_Iniciado_Cantidad = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(DateTime?))]
		[DataMemberAttribute()]
		public DateTime? Turno_Fecha
		{
			get { return _turno_Fecha; }
			protected set
			{
				_turno_Fecha = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Fecha"));
			}
		}
		protected DateTime? _turno_Fecha = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Turno_Razon_Inactivo
		{
			get { return _turno_Razon_Inactivo; }
			protected set
			{
				_turno_Razon_Inactivo = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Razon_Inactivo"));
			}
		}
		protected string _turno_Razon_Inactivo = string.Empty;

		#endregion

        [field:System.NonSerializedAttribute()]
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
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
                this._congregacion_Nombre = CodeFluentPersistence.GetReaderValue(reader, "Congregacion_Nombre", ((string)(string.Empty)));
                this._congregacion_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Congregacion_Secuencia", ((int?)(-1)));
                this._dia_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Dia_Secuencia", ((int?)(-1)));
                this._dia_Secuencia1 = CodeFluentPersistence.GetReaderValue(reader, "Dia_Secuencia1", ((int?)(-1)));
                this._horario_Turno_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Turno_Secuencia", ((int?)(-1)));
                this._persona_Apellidos = CodeFluentPersistence.GetReaderValue(reader, "Persona_Apellidos", ((string)(string.Empty)));
                this._persona_Conyuge_Apellido = CodeFluentPersistence.GetReaderValue(reader, "Persona_Conyuge_Apellido", ((string)(string.Empty)));
                this._persona_Nombres = CodeFluentPersistence.GetReaderValue(reader, "Persona_Nombres", ((string)(string.Empty)));
                this._persona_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Persona_Secuencia", ((int?)(-1)));
                this._persona_Sexo = CodeFluentPersistence.GetReaderValue(reader, "Persona_Sexo", ((string)(string.Empty)));
                this._persona_Turno_HC = CodeFluentPersistence.GetReaderValue(reader, "Persona_Turno_HC", ((string)(string.Empty)));
                this._registro_Estado = CodeFluentPersistence.GetReaderValue(reader, "Registro_Estado", ((string)(string.Empty)));
                this._registro_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Registro_Fecha", ((DateTime?)(System.DateTime.MinValue)));
                this._registro_Fecha1 = CodeFluentPersistence.GetReaderValue(reader, "Registro_Fecha1", ((DateTime?)(System.DateTime.MinValue)));
                this._registro_Usuario = CodeFluentPersistence.GetReaderValue(reader, "Registro_Usuario", ((string)(string.Empty)));
                this._turno_Estado = CodeFluentPersistence.GetReaderValue(reader, "Turno_Estado", ((string)(string.Empty)));
                this._turno_Estudios_Iniciado_Cantidad = CodeFluentPersistence.GetReaderValue(reader, "Turno_Estudios_Iniciado_Cantidad", ((int?)(-1)));
                this._turno_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Turno_Fecha", ((DateTime?)(System.DateTime.MinValue)));
                this._turno_Razon_Inactivo = CodeFluentPersistence.GetReaderValue(reader, "Turno_Razon_Inactivo", ((string)(string.Empty)));
                this._totalRowCount = CodeFluentPersistence.GetReaderValue(reader, "TotalRowCount", ((int)(-1)));
            }
        }
        
        void CodeFluent.Runtime.ICodeFluentLightEntity.ReadRecord(System.Data.IDataReader reader)
        {
            this.ReadRecord(reader, CodeFluent.Runtime.CodeFluentReloadOptions.Default);
        }
        private int _totalRowCount = 0;
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false)]
        public virtual int TotalRowCount
        {
            get
            {
                return this._totalRowCount;
            }
            set
            {
                this._totalRowCount = value;
            }
        }
        

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static OSIS.PEPPAM.BOM.Proc_Puesto_Horarios_Pesonas LoadOne(int? diaSecuencia,int? horarioTurnoSecuencia)
        {
            OSIS.PEPPAM.BOM.Proc_Puesto_Horarios_Pesonas  result = new OSIS.PEPPAM.BOM.Proc_Puesto_Horarios_Pesonas();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Puesto_Horarios_Pesonas", null, "Proc_Puesto_Horarios_Pesonas");
            if (diaSecuencia.HasValue)
            persistence.AddRawParameter("@Dia_Secuencia", diaSecuencia.Value);
            if (horarioTurnoSecuencia.HasValue)
            persistence.AddRawParameter("@Horario_Turno_Secuencia", horarioTurnoSecuencia.Value);
            System.Data.IDataReader reader = null;
            try
            {
                reader = persistence.ExecuteReader();
                if ((reader.Read() == true))
                {
                    CodeFluent.Runtime.CodeFluentLightWeightPersistence.ReadRecord(reader, ((CodeFluent.Runtime.ICodeFluentLightEntity)(result)), null);
                    return result;
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


         public static System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Puesto_Horarios_Pesonas> Load(int? diaSecuencia,int? horarioTurnoSecuencia)
        {
            System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Puesto_Horarios_Pesonas> load = new System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Puesto_Horarios_Pesonas>();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Puesto_Horarios_Pesonas", null, "Proc_Puesto_Horarios_Pesonas");
            persistence.AddParameter("@Dia_Secuencia", diaSecuencia);
            persistence.AddParameter("@Horario_Turno_Secuencia", horarioTurnoSecuencia);
            System.Data.IDataReader reader = null;
            bool readerRead;
            try
            {
                reader = persistence.ExecuteReader();
                for (readerRead = reader.Read(); (readerRead == true); readerRead = reader.Read())
                {
                    OSIS.PEPPAM.BOM.Proc_Puesto_Horarios_Pesonas _load = new OSIS.PEPPAM.BOM.Proc_Puesto_Horarios_Pesonas();
                    CodeFluent.Runtime.CodeFluentLightWeightPersistence.ReadRecord(reader, ((CodeFluent.Runtime.ICodeFluentLightEntity)(_load)), null);
                    load.Add(_load);
                }
                return load;
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

    }
}

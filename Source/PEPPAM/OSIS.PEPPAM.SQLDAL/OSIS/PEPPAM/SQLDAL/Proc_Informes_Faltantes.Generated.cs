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
    public partial class Proc_Informes_Faltantes : CodeFluent.Runtime.ICodeFluentLightEntity, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool _raisePropertyChangedEvents = true;

        
		#region Property Holders


		#endregion



        
        public Proc_Informes_Faltantes()
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
		public string Auxiliar_Persona_Apellidos
		{
			get { return _auxiliar_Persona_Apellidos; }
			protected set
			{
				_auxiliar_Persona_Apellidos = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Auxiliar_Persona_Apellidos"));
			}
		}
		protected string _auxiliar_Persona_Apellidos = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Auxiliar_Persona_Correo
		{
			get { return _auxiliar_Persona_Correo; }
			protected set
			{
				_auxiliar_Persona_Correo = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Auxiliar_Persona_Correo"));
			}
		}
		protected string _auxiliar_Persona_Correo = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Auxiliar_Persona_Nombres
		{
			get { return _auxiliar_Persona_Nombres; }
			protected set
			{
				_auxiliar_Persona_Nombres = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Auxiliar_Persona_Nombres"));
			}
		}
		protected string _auxiliar_Persona_Nombres = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Auxiliar_Persona_Secuencia
		{
			get { return _auxiliar_Persona_Secuencia; }
			protected set
			{
				_auxiliar_Persona_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Auxiliar_Persona_Secuencia"));
			}
		}
		protected int? _auxiliar_Persona_Secuencia = -1;

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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Encargado_Persona_Apellidos
		{
			get { return _encargado_Persona_Apellidos; }
			protected set
			{
				_encargado_Persona_Apellidos = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Encargado_Persona_Apellidos"));
			}
		}
		protected string _encargado_Persona_Apellidos = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Encargado_Persona_Correo
		{
			get { return _encargado_Persona_Correo; }
			protected set
			{
				_encargado_Persona_Correo = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Encargado_Persona_Correo"));
			}
		}
		protected string _encargado_Persona_Correo = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Encargado_Persona_Nombres
		{
			get { return _encargado_Persona_Nombres; }
			protected set
			{
				_encargado_Persona_Nombres = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Encargado_Persona_Nombres"));
			}
		}
		protected string _encargado_Persona_Nombres = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Encargado_Persona_Secuencia
		{
			get { return _encargado_Persona_Secuencia; }
			protected set
			{
				_encargado_Persona_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Encargado_Persona_Secuencia"));
			}
		}
		protected int? _encargado_Persona_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(DateTime?))]
		[DataMemberAttribute()]
		public DateTime? Horario_Fecha_Desde
		{
			get { return _horario_Fecha_Desde; }
			protected set
			{
				_horario_Fecha_Desde = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Fecha_Desde"));
			}
		}
		protected DateTime? _horario_Fecha_Desde = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(DateTime?))]
		[DataMemberAttribute()]
		public DateTime? Horario_Fecha_Hasta
		{
			get { return _horario_Fecha_Hasta; }
			protected set
			{
				_horario_Fecha_Hasta = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Fecha_Hasta"));
			}
		}
		protected DateTime? _horario_Fecha_Hasta = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Horario_Secuencia
		{
			get { return _horario_Secuencia; }
			protected set
			{
				_horario_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Secuencia"));
			}
		}
		protected int? _horario_Secuencia = -1;

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
		public string Persona_Correo
		{
			get { return _persona_Correo; }
			protected set
			{
				_persona_Correo = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Persona_Correo"));
			}
		}
		protected string _persona_Correo = string.Empty;

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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Ruta_Descripcion
		{
			get { return _ruta_Descripcion; }
			protected set
			{
				_ruta_Descripcion = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Ruta_Descripcion"));
			}
		}
		protected string _ruta_Descripcion = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Ruta_Mapa_Url
		{
			get { return _ruta_Mapa_Url; }
			protected set
			{
				_ruta_Mapa_Url = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Ruta_Mapa_Url"));
			}
		}
		protected string _ruta_Mapa_Url = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Ruta_Persona_Auxiliar
		{
			get { return _ruta_Persona_Auxiliar; }
			protected set
			{
				_ruta_Persona_Auxiliar = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Ruta_Persona_Auxiliar"));
			}
		}
		protected int? _ruta_Persona_Auxiliar = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Ruta_Persona_Encargado
		{
			get { return _ruta_Persona_Encargado; }
			protected set
			{
				_ruta_Persona_Encargado = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Ruta_Persona_Encargado"));
			}
		}
		protected int? _ruta_Persona_Encargado = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Ruta_Secuencia
		{
			get { return _ruta_Secuencia; }
			protected set
			{
				_ruta_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Ruta_Secuencia"));
			}
		}
		protected int? _ruta_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Turno_Descripcion
		{
			get { return _turno_Descripcion; }
			protected set
			{
				_turno_Descripcion = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Descripcion"));
			}
		}
		protected string _turno_Descripcion = string.Empty;

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
		public string Turno_Hora_Desde
		{
			get { return _turno_Hora_Desde; }
			protected set
			{
				_turno_Hora_Desde = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Hora_Desde"));
			}
		}
		protected string _turno_Hora_Desde = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Turno_Hora_Hasta
		{
			get { return _turno_Hora_Hasta; }
			protected set
			{
				_turno_Hora_Hasta = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Hora_Hasta"));
			}
		}
		protected string _turno_Hora_Hasta = string.Empty;

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
                this._auxiliar_Persona_Apellidos = CodeFluentPersistence.GetReaderValue(reader, "Auxiliar_Persona_Apellidos", ((string)(string.Empty)));
                this._auxiliar_Persona_Correo = CodeFluentPersistence.GetReaderValue(reader, "Auxiliar_Persona_Correo", ((string)(string.Empty)));
                this._auxiliar_Persona_Nombres = CodeFluentPersistence.GetReaderValue(reader, "Auxiliar_Persona_Nombres", ((string)(string.Empty)));
                this._auxiliar_Persona_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Auxiliar_Persona_Secuencia", ((int?)(-1)));
                this._dia_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Dia_Secuencia", ((int?)(-1)));
                this._dia_Secuencia1 = CodeFluentPersistence.GetReaderValue(reader, "Dia_Secuencia1", ((int?)(-1)));
                this._encargado_Persona_Apellidos = CodeFluentPersistence.GetReaderValue(reader, "Encargado_Persona_Apellidos", ((string)(string.Empty)));
                this._encargado_Persona_Correo = CodeFluentPersistence.GetReaderValue(reader, "Encargado_Persona_Correo", ((string)(string.Empty)));
                this._encargado_Persona_Nombres = CodeFluentPersistence.GetReaderValue(reader, "Encargado_Persona_Nombres", ((string)(string.Empty)));
                this._encargado_Persona_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Encargado_Persona_Secuencia", ((int?)(-1)));
                this._horario_Fecha_Desde = CodeFluentPersistence.GetReaderValue(reader, "Horario_Fecha_Desde", ((DateTime?)(System.DateTime.MinValue)));
                this._horario_Fecha_Hasta = CodeFluentPersistence.GetReaderValue(reader, "Horario_Fecha_Hasta", ((DateTime?)(System.DateTime.MinValue)));
                this._horario_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Secuencia", ((int?)(-1)));
                this._horario_Turno_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Turno_Secuencia", ((int?)(-1)));
                this._persona_Apellidos = CodeFluentPersistence.GetReaderValue(reader, "Persona_Apellidos", ((string)(string.Empty)));
                this._persona_Correo = CodeFluentPersistence.GetReaderValue(reader, "Persona_Correo", ((string)(string.Empty)));
                this._persona_Nombres = CodeFluentPersistence.GetReaderValue(reader, "Persona_Nombres", ((string)(string.Empty)));
                this._ruta_Descripcion = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Descripcion", ((string)(string.Empty)));
                this._ruta_Mapa_Url = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Mapa_Url", ((string)(string.Empty)));
                this._ruta_Persona_Auxiliar = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Persona_Auxiliar", ((int?)(-1)));
                this._ruta_Persona_Encargado = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Persona_Encargado", ((int?)(-1)));
                this._ruta_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Secuencia", ((int?)(-1)));
                this._turno_Descripcion = CodeFluentPersistence.GetReaderValue(reader, "Turno_Descripcion", ((string)(string.Empty)));
                this._turno_Estado = CodeFluentPersistence.GetReaderValue(reader, "Turno_Estado", ((string)(string.Empty)));
                this._turno_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Turno_Fecha", ((DateTime?)(System.DateTime.MinValue)));
                this._turno_Hora_Desde = CodeFluentPersistence.GetReaderValue(reader, "Turno_Hora_Desde", ((string)(string.Empty)));
                this._turno_Hora_Hasta = CodeFluentPersistence.GetReaderValue(reader, "Turno_Hora_Hasta", ((string)(string.Empty)));
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
        public static OSIS.PEPPAM.BOM.Proc_Informes_Faltantes LoadOne()
        {
            OSIS.PEPPAM.BOM.Proc_Informes_Faltantes  result = new OSIS.PEPPAM.BOM.Proc_Informes_Faltantes();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Informes_Faltantes", null, "Proc_Informes_Faltantes");
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


         public static System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Informes_Faltantes> Load()
        {
            System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Informes_Faltantes> load = new System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Informes_Faltantes>();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Informes_Faltantes", null, "Proc_Informes_Faltantes");
            System.Data.IDataReader reader = null;
            bool readerRead;
            try
            {
                reader = persistence.ExecuteReader();
                for (readerRead = reader.Read(); (readerRead == true); readerRead = reader.Read())
                {
                    OSIS.PEPPAM.BOM.Proc_Informes_Faltantes _load = new OSIS.PEPPAM.BOM.Proc_Informes_Faltantes();
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

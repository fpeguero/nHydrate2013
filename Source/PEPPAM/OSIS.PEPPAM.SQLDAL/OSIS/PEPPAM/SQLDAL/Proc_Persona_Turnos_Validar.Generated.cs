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
    public partial class Proc_Persona_Turnos_Validar : CodeFluent.Runtime.ICodeFluentLightEntity, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool _raisePropertyChangedEvents = true;

        
		#region Property Holders


		#endregion



        
        public Proc_Persona_Turnos_Validar()
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
                this._dia_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Dia_Secuencia", ((int?)(-1)));
                this._horario_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Secuencia", ((int?)(-1)));
                this._horario_Turno_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Turno_Secuencia", ((int?)(-1)));
                this._persona_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Persona_Secuencia", ((int?)(-1)));
                this._ruta_Descripcion = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Descripcion", ((string)(string.Empty)));
                this._turno_Descripcion = CodeFluentPersistence.GetReaderValue(reader, "Turno_Descripcion", ((string)(string.Empty)));
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
        public static OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Validar LoadOne(string horaDesde,string horaHasta,int? personaSecuencia,DateTime? turnoFecha)
        {
            OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Validar  result = new OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Validar();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Persona_Turnos_Validar", null, "Proc_Persona_Turnos_Validar");
            persistence.AddRawParameter("@Hora_Desde", horaDesde);
            persistence.AddRawParameter("@Hora_Hasta", horaHasta);
            if (personaSecuencia.HasValue)
            persistence.AddRawParameter("@Persona_Secuencia", personaSecuencia.Value);
            if (turnoFecha.HasValue)
            persistence.AddRawParameter("@Turno_Fecha", turnoFecha.Value);
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


         public static System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Validar> Load(string horaDesde,string horaHasta,int? personaSecuencia,DateTime? turnoFecha)
        {
            System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Validar> load = new System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Validar>();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Persona_Turnos_Validar", null, "Proc_Persona_Turnos_Validar");
            persistence.AddParameter("@Hora_Desde", horaDesde);
            persistence.AddParameter("@Hora_Hasta", horaHasta);
            persistence.AddParameter("@Persona_Secuencia", personaSecuencia);
            persistence.AddParameter("@Turno_Fecha", turnoFecha);
            System.Data.IDataReader reader = null;
            bool readerRead;
            try
            {
                reader = persistence.ExecuteReader();
                for (readerRead = reader.Read(); (readerRead == true); readerRead = reader.Read())
                {
                    OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Validar _load = new OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Validar();
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


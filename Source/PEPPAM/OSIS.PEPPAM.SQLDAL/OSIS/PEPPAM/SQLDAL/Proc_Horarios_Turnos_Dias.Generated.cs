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
 using System.Runtime.Serialization;
 using CodeFluent.Runtime;
 using CodeFluent.Runtime.Utilities;
 using System.Collections.Generic;
namespace OSIS.PEPPAM.BOM
{
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DataObjectAttribute()]
    public partial class Proc_Horarios_Turnos_Dias : CodeFluent.Runtime.ICodeFluentLightEntity, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool _raisePropertyChangedEvents = true;

        
		#region Property Holders


		#endregion



        
        public Proc_Horarios_Turnos_Dias()
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Dias
		{
			get { return _dias; }
			protected set
			{
				_dias = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Dias"));
			}
		}
		protected string _dias = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(int))]
		[DataMemberAttribute()]
		public int Horario_Secuencia
		{
			get { return _horario_Secuencia; }
			protected set
			{
				_horario_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Secuencia"));
			}
		}
		protected int _horario_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(int))]
		[DataMemberAttribute()]
		public int Horario_Turno_Secuencia
		{
			get { return _horario_Turno_Secuencia; }
			protected set
			{
				_horario_Turno_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Turno_Secuencia"));
			}
		}
		protected int _horario_Turno_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(string))]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(DateTime))]
		[DataMemberAttribute()]
		public DateTime Registro_Fecha
		{
			get { return _registro_Fecha; }
			protected set
			{
				_registro_Fecha = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Registro_Fecha"));
			}
		}
		protected DateTime _registro_Fecha = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(string))]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(int))]
		[DataMemberAttribute()]
		public int Turno_Cantidad_Publicadores
		{
			get { return _turno_Cantidad_Publicadores; }
			protected set
			{
				_turno_Cantidad_Publicadores = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Cantidad_Publicadores"));
			}
		}
		protected int _turno_Cantidad_Publicadores = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(string))]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(string))]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(string))]
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

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(int))]
		[DataMemberAttribute()]
		public int Turno_Minutos_Cantidad
		{
			get { return _turno_Minutos_Cantidad; }
			protected set
			{
				_turno_Minutos_Cantidad = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Minutos_Cantidad"));
			}
		}
		protected int _turno_Minutos_Cantidad = -1;

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
                this._dias = CodeFluentPersistence.GetReaderValue(reader, "Dias", ((string)(string.Empty)));
                this._horario_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Secuencia", ((int)(-1)));
                this._horario_Turno_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Turno_Secuencia", ((int)(-1)));
                this._registro_Estado = CodeFluentPersistence.GetReaderValue(reader, "Registro_Estado", ((string)(string.Empty)));
                this._registro_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Registro_Fecha", ((DateTime)(System.DateTime.MinValue)));
                this._registro_Usuario = CodeFluentPersistence.GetReaderValue(reader, "Registro_Usuario", ((string)(string.Empty)));
                this._turno_Cantidad_Publicadores = CodeFluentPersistence.GetReaderValue(reader, "Turno_Cantidad_Publicadores", ((int)(-1)));
                this._turno_Descripcion = CodeFluentPersistence.GetReaderValue(reader, "Turno_Descripcion", ((string)(string.Empty)));
                this._turno_Hora_Desde = CodeFluentPersistence.GetReaderValue(reader, "Turno_Hora_Desde", ((string)(string.Empty)));
                this._turno_Hora_Hasta = CodeFluentPersistence.GetReaderValue(reader, "Turno_Hora_Hasta", ((string)(string.Empty)));
                this._turno_Minutos_Cantidad = CodeFluentPersistence.GetReaderValue(reader, "Turno_Minutos_Cantidad", ((int)(-1)));
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
        public static OSIS.PEPPAM.BOM.Proc_Horarios_Turnos_Dias LoadOne(int? horarioSecuencia)
        {
            OSIS.PEPPAM.BOM.Proc_Horarios_Turnos_Dias  result = new OSIS.PEPPAM.BOM.Proc_Horarios_Turnos_Dias();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horarios_Turnos_Dias", null, "Proc_Horarios_Turnos_Dias");
            if (horarioSecuencia.HasValue)
            persistence.AddRawParameter("@Horario_Secuencia", horarioSecuencia.Value);
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


         public static System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horarios_Turnos_Dias> Load(int? horarioSecuencia)
        {
            System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horarios_Turnos_Dias> load = new System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horarios_Turnos_Dias>();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horarios_Turnos_Dias", null, "Proc_Horarios_Turnos_Dias");
            persistence.AddParameter("@Horario_Secuencia", horarioSecuencia);
            System.Data.IDataReader reader = null;
            bool readerRead;
            try
            {
                reader = persistence.ExecuteReader();
                for (readerRead = reader.Read(); (readerRead == true); readerRead = reader.Read())
                {
                    OSIS.PEPPAM.BOM.Proc_Horarios_Turnos_Dias _load = new OSIS.PEPPAM.BOM.Proc_Horarios_Turnos_Dias();
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

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
    public partial class Proc_Turnos_Disponibles : CodeFluent.Runtime.ICodeFluentLightEntity, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool _raisePropertyChangedEvents = true;

        
		#region Property Holders


		#endregion



        
        public Proc_Turnos_Disponibles()
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
		public int? Cantidad_Dias
		{
			get { return _cantidad_Dias; }
			protected set
			{
				_cantidad_Dias = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Cantidad_Dias"));
			}
		}
		protected int? _cantidad_Dias = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Cantidad_Ocupado
		{
			get { return _cantidad_Ocupado; }
			protected set
			{
				_cantidad_Ocupado = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Cantidad_Ocupado"));
			}
		}
		protected int? _cantidad_Ocupado = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Cantidad_Restante
		{
			get { return _cantidad_Restante; }
			protected set
			{
				_cantidad_Restante = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Cantidad_Restante"));
			}
		}
		protected int? _cantidad_Restante = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Cantidad_Turnos
		{
			get { return _cantidad_Turnos; }
			protected set
			{
				_cantidad_Turnos = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Cantidad_Turnos"));
			}
		}
		protected int? _cantidad_Turnos = -1;

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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Turno_Cantidad_Publicadores
		{
			get { return _turno_Cantidad_Publicadores; }
			protected set
			{
				_turno_Cantidad_Publicadores = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Turno_Cantidad_Publicadores"));
			}
		}
		protected int? _turno_Cantidad_Publicadores = -1;

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
                this._cantidad_Dias = CodeFluentPersistence.GetReaderValue(reader, "Cantidad_Dias", ((int?)(-1)));
                this._cantidad_Ocupado = CodeFluentPersistence.GetReaderValue(reader, "Cantidad_Ocupado", ((int?)(-1)));
                this._cantidad_Restante = CodeFluentPersistence.GetReaderValue(reader, "Cantidad_Restante", ((int?)(-1)));
                this._cantidad_Turnos = CodeFluentPersistence.GetReaderValue(reader, "Cantidad_Turnos", ((int?)(-1)));
                this._dia_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Dia_Secuencia", ((int?)(-1)));
                this._horario_Fecha_Desde = CodeFluentPersistence.GetReaderValue(reader, "Horario_Fecha_Desde", ((DateTime?)(System.DateTime.MinValue)));
                this._horario_Fecha_Hasta = CodeFluentPersistence.GetReaderValue(reader, "Horario_Fecha_Hasta", ((DateTime?)(System.DateTime.MinValue)));
                this._horario_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Secuencia", ((int?)(-1)));
                this._horario_Turno_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Turno_Secuencia", ((int?)(-1)));
                this._ruta_Descripcion = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Descripcion", ((string)(string.Empty)));
                this._ruta_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Secuencia", ((int?)(-1)));
                this._turno_Cantidad_Publicadores = CodeFluentPersistence.GetReaderValue(reader, "Turno_Cantidad_Publicadores", ((int?)(-1)));
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
        public static OSIS.PEPPAM.BOM.Proc_Turnos_Disponibles LoadOne(int? usuarioNumero)
        {
            OSIS.PEPPAM.BOM.Proc_Turnos_Disponibles  result = new OSIS.PEPPAM.BOM.Proc_Turnos_Disponibles();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Turnos_Disponibles", null, "Proc_Turnos_Disponibles");
            if (usuarioNumero.HasValue)
            persistence.AddRawParameter("@Usuario_Numero", usuarioNumero.Value);
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


         public static System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Turnos_Disponibles> Load(int? usuarioNumero)
        {
            System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Turnos_Disponibles> load = new System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Turnos_Disponibles>();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Turnos_Disponibles", null, "Proc_Turnos_Disponibles");
            persistence.AddParameter("@Usuario_Numero", usuarioNumero);
            System.Data.IDataReader reader = null;
            bool readerRead;
            try
            {
                reader = persistence.ExecuteReader();
                for (readerRead = reader.Read(); (readerRead == true); readerRead = reader.Read())
                {
                    OSIS.PEPPAM.BOM.Proc_Turnos_Disponibles _load = new OSIS.PEPPAM.BOM.Proc_Turnos_Disponibles();
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


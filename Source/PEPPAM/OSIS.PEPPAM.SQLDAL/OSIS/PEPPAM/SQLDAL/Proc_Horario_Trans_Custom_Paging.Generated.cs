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
    public partial class Proc_Horario_Trans_Custom_Paging : CodeFluent.Runtime.ICodeFluentLightEntity, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool _raisePropertyChangedEvents = true;

        
		#region Property Holders


		#endregion



        
        public Proc_Horario_Trans_Custom_Paging()
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
		public int? Horario_Numero
		{
			get { return _horario_Numero; }
			protected set
			{
				_horario_Numero = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Numero"));
			}
		}
		protected int? _horario_Numero = -1;

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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(long?))]
		[DataMemberAttribute()]
		public long? RowNumber
		{
			get { return _rowNumber; }
			protected set
			{
				_rowNumber = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("RowNumber"));
			}
		}
		protected long? _rowNumber = long.MinValue;

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
		public int? Semana_Codigo
		{
			get { return _semana_Codigo; }
			protected set
			{
				_semana_Codigo = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Semana_Codigo"));
			}
		}
		protected int? _semana_Codigo = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(DateTime?))]
		[DataMemberAttribute()]
		public DateTime? Semana_Desde
		{
			get { return _semana_Desde; }
			protected set
			{
				_semana_Desde = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Semana_Desde"));
			}
		}
		protected DateTime? _semana_Desde = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(DateTime?))]
		[DataMemberAttribute()]
		public DateTime? Semana_Hasta
		{
			get { return _semana_Hasta; }
			protected set
			{
				_semana_Hasta = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Semana_Hasta"));
			}
		}
		protected DateTime? _semana_Hasta = System.DateTime.MinValue;

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
                this._horario_Fecha_Desde = CodeFluentPersistence.GetReaderValue(reader, "Horario_Fecha_Desde", ((DateTime?)(System.DateTime.MinValue)));
                this._horario_Fecha_Hasta = CodeFluentPersistence.GetReaderValue(reader, "Horario_Fecha_Hasta", ((DateTime?)(System.DateTime.MinValue)));
                this._horario_Numero = CodeFluentPersistence.GetReaderValue(reader, "Horario_Numero", ((int?)(-1)));
                this._horario_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Secuencia", ((int?)(-1)));
                this._registro_Estado = CodeFluentPersistence.GetReaderValue(reader, "Registro_Estado", ((string)(string.Empty)));
                this._registro_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Registro_Fecha", ((DateTime?)(System.DateTime.MinValue)));
                this._registro_Usuario = CodeFluentPersistence.GetReaderValue(reader, "Registro_Usuario", ((string)(string.Empty)));
                this._rowNumber = CodeFluentPersistence.GetReaderValue(reader, "RowNumber", ((long?)(long.MinValue)));
                this._ruta_Descripcion = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Descripcion", ((string)(string.Empty)));
                this._ruta_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Secuencia", ((int?)(-1)));
                this._semana_Codigo = CodeFluentPersistence.GetReaderValue(reader, "Semana_Codigo", ((int?)(-1)));
                this._semana_Desde = CodeFluentPersistence.GetReaderValue(reader, "Semana_Desde", ((DateTime?)(System.DateTime.MinValue)));
                this._semana_Hasta = CodeFluentPersistence.GetReaderValue(reader, "Semana_Hasta", ((DateTime?)(System.DateTime.MinValue)));
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
        public static OSIS.PEPPAM.BOM.Proc_Horario_Trans_Custom_Paging LoadOne(string orderby0,bool? orderbydirection0,int? pageindex,int? pagesize,int personaSecuencia,int? rutaSecuencia,string searchstring)
        {
            if ((personaSecuencia == default(int)))
            {
                return null;
            }
            OSIS.PEPPAM.BOM.Proc_Horario_Trans_Custom_Paging  result = new OSIS.PEPPAM.BOM.Proc_Horario_Trans_Custom_Paging();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horario_Trans_Custom_Paging", null, "Proc_Horario_Trans_Custom_Paging");
            persistence.AddRawParameter("@orderBy0", orderby0);
            if (orderbydirection0.HasValue)
            persistence.AddRawParameter("@orderByDirection0", orderbydirection0.Value);
            if (pageindex.HasValue)
            persistence.AddRawParameter("@PageIndex", pageindex.Value);
            if (pagesize.HasValue)
            persistence.AddRawParameter("@PageSize", pagesize.Value);
            persistence.AddRawParameter("@Persona_Secuencia", personaSecuencia);
            if (rutaSecuencia.HasValue)
            persistence.AddRawParameter("@Ruta_Secuencia", rutaSecuencia.Value);
            persistence.AddRawParameter("@SearchString", searchstring);
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


         public static System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horario_Trans_Custom_Paging> Load(string orderby0,bool? orderbydirection0,int? pageindex,int? pagesize,int personaSecuencia,int? rutaSecuencia,string searchstring)
        {
            System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horario_Trans_Custom_Paging> load = new System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horario_Trans_Custom_Paging>();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horario_Trans_Custom_Paging", null, "Proc_Horario_Trans_Custom_Paging");
            persistence.AddParameter("@orderBy0", orderby0);
            persistence.AddParameter("@orderByDirection0", orderbydirection0);
            persistence.AddParameter("@PageIndex", pageindex);
            persistence.AddParameter("@PageSize", pagesize);
            persistence.AddParameter("@Persona_Secuencia", personaSecuencia);
            persistence.AddParameter("@Ruta_Secuencia", rutaSecuencia);
            persistence.AddParameter("@SearchString", searchstring);
            System.Data.IDataReader reader = null;
            bool readerRead;
            try
            {
                reader = persistence.ExecuteReader();
                for (readerRead = reader.Read(); (readerRead == true); readerRead = reader.Read())
                {
                    OSIS.PEPPAM.BOM.Proc_Horario_Trans_Custom_Paging _load = new OSIS.PEPPAM.BOM.Proc_Horario_Trans_Custom_Paging();
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


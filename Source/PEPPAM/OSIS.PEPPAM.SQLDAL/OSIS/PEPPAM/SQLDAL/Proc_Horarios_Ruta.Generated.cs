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
    public partial class Proc_Horarios_Ruta : CodeFluent.Runtime.ICodeFluentLightEntity, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool _raisePropertyChangedEvents = true;

        
		#region Property Holders


		#endregion



        
        public Proc_Horarios_Ruta()
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(DateTime))]
		[DataMemberAttribute()]
		public DateTime Horario_Fecha_Desde
		{
			get { return _horario_Fecha_Desde; }
			protected set
			{
				_horario_Fecha_Desde = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Fecha_Desde"));
			}
		}
		protected DateTime _horario_Fecha_Desde = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(DateTime))]
		[DataMemberAttribute()]
		public DateTime Horario_Fecha_Hasta
		{
			get { return _horario_Fecha_Hasta; }
			protected set
			{
				_horario_Fecha_Hasta = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Fecha_Hasta"));
			}
		}
		protected DateTime _horario_Fecha_Hasta = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(int))]
		[DataMemberAttribute()]
		public int Horario_Numero
		{
			get { return _horario_Numero; }
			protected set
			{
				_horario_Numero = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Numero"));
			}
		}
		protected int _horario_Numero = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Horario_Publicar
		{
			get { return _horario_Publicar; }
			protected set
			{
				_horario_Publicar = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Horario_Publicar"));
			}
		}
		protected string _horario_Publicar = string.Empty;

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
		public int Ruta_Secuencia
		{
			get { return _ruta_Secuencia; }
			protected set
			{
				_ruta_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Ruta_Secuencia"));
			}
		}
		protected int _ruta_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=false, Type=typeof(int))]
		[DataMemberAttribute()]
		public int Semana_Codigo
		{
			get { return _semana_Codigo; }
			protected set
			{
				_semana_Codigo = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Semana_Codigo"));
			}
		}
		protected int _semana_Codigo = -1;

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
                this._horario_Fecha_Desde = CodeFluentPersistence.GetReaderValue(reader, "Horario_Fecha_Desde", ((DateTime)(System.DateTime.MinValue)));
                this._horario_Fecha_Hasta = CodeFluentPersistence.GetReaderValue(reader, "Horario_Fecha_Hasta", ((DateTime)(System.DateTime.MinValue)));
                this._horario_Numero = CodeFluentPersistence.GetReaderValue(reader, "Horario_Numero", ((int)(-1)));
                this._horario_Publicar = CodeFluentPersistence.GetReaderValue(reader, "Horario_Publicar", ((string)(string.Empty)));
                this._horario_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Horario_Secuencia", ((int)(-1)));
                this._registro_Estado = CodeFluentPersistence.GetReaderValue(reader, "Registro_Estado", ((string)(string.Empty)));
                this._registro_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Registro_Fecha", ((DateTime)(System.DateTime.MinValue)));
                this._registro_Usuario = CodeFluentPersistence.GetReaderValue(reader, "Registro_Usuario", ((string)(string.Empty)));
                this._ruta_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Ruta_Secuencia", ((int)(-1)));
                this._semana_Codigo = CodeFluentPersistence.GetReaderValue(reader, "Semana_Codigo", ((int)(-1)));
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
        public static OSIS.PEPPAM.BOM.Proc_Horarios_Ruta LoadOne(int? rutaSecuencia)
        {
            OSIS.PEPPAM.BOM.Proc_Horarios_Ruta  result = new OSIS.PEPPAM.BOM.Proc_Horarios_Ruta();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horarios_Ruta", null, "Proc_Horarios_Ruta");
            if (rutaSecuencia.HasValue)
            persistence.AddRawParameter("@Ruta_Secuencia", rutaSecuencia.Value);
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


         public static System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horarios_Ruta> Load(int? rutaSecuencia)
        {
            System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horarios_Ruta> load = new System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Horarios_Ruta>();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Horarios_Ruta", null, "Proc_Horarios_Ruta");
            persistence.AddParameter("@Ruta_Secuencia", rutaSecuencia);
            System.Data.IDataReader reader = null;
            bool readerRead;
            try
            {
                reader = persistence.ExecuteReader();
                for (readerRead = reader.Read(); (readerRead == true); readerRead = reader.Read())
                {
                    OSIS.PEPPAM.BOM.Proc_Horarios_Ruta _load = new OSIS.PEPPAM.BOM.Proc_Horarios_Ruta();
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


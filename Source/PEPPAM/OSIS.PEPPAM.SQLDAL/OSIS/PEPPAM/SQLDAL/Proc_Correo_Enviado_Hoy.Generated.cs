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
    public partial class Proc_Correo_Enviado_Hoy : CodeFluent.Runtime.ICodeFluentLightEntity, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool _raisePropertyChangedEvents = true;

        
		#region Property Holders


		#endregion



        
        public Proc_Correo_Enviado_Hoy()
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
		public DateTime? Correo_Enviado_Fecha
		{
			get { return _correo_Enviado_Fecha; }
			protected set
			{
				_correo_Enviado_Fecha = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Correo_Enviado_Fecha"));
			}
		}
		protected DateTime? _correo_Enviado_Fecha = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Correo_Enviado_Secuencia
		{
			get { return _correo_Enviado_Secuencia; }
			protected set
			{
				_correo_Enviado_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Correo_Enviado_Secuencia"));
			}
		}
		protected int? _correo_Enviado_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(string))]
		[DataMemberAttribute()]
		public string Correo_Enviado_Texto
		{
			get { return _correo_Enviado_Texto; }
			protected set
			{
				_correo_Enviado_Texto = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Correo_Enviado_Texto"));
			}
		}
		protected string _correo_Enviado_Texto = string.Empty;

		/// <summary>
		/// 
		/// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Type=typeof(int?))]
		[DataMemberAttribute()]
		public int? Correos_Secuencia
		{
			get { return _correos_Secuencia; }
			protected set
			{
				_correos_Secuencia = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Correos_Secuencia"));
			}
		}
		protected int? _correos_Secuencia = -1;

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
                this._correo_Enviado_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Correo_Enviado_Fecha", ((DateTime?)(System.DateTime.MinValue)));
                this._correo_Enviado_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Correo_Enviado_Secuencia", ((int?)(-1)));
                this._correo_Enviado_Texto = CodeFluentPersistence.GetReaderValue(reader, "Correo_Enviado_Texto", ((string)(string.Empty)));
                this._correos_Secuencia = CodeFluentPersistence.GetReaderValue(reader, "Correos_Secuencia", ((int?)(-1)));
                this._registro_Estado = CodeFluentPersistence.GetReaderValue(reader, "Registro_Estado", ((string)(string.Empty)));
                this._registro_Fecha = CodeFluentPersistence.GetReaderValue(reader, "Registro_Fecha", ((DateTime?)(System.DateTime.MinValue)));
                this._registro_Usuario = CodeFluentPersistence.GetReaderValue(reader, "Registro_Usuario", ((string)(string.Empty)));
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
        public static OSIS.PEPPAM.BOM.Proc_Correo_Enviado_Hoy LoadOne(int? correosSecuencia)
        {
            OSIS.PEPPAM.BOM.Proc_Correo_Enviado_Hoy  result = new OSIS.PEPPAM.BOM.Proc_Correo_Enviado_Hoy();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Correo_Enviado_Hoy", null, "Proc_Correo_Enviado_Hoy");
            if (correosSecuencia.HasValue)
            persistence.AddRawParameter("@Correos_Secuencia", correosSecuencia.Value);
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


         public static System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Correo_Enviado_Hoy> Load(int? correosSecuencia)
        {
            System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Correo_Enviado_Hoy> load = new System.Collections.Generic.List<OSIS.PEPPAM.BOM.Proc_Correo_Enviado_Hoy>();
            CodeFluent.Runtime.CodeFluentPersistence persistence = CodeFluentContext.Get(OSIS.PEPPAM.BOM.Constants.OSIS_PEPPAM_BOMStoreName).Persistence;
            persistence.CreateStoredProcedureCommand(null, "Proc_Correo_Enviado_Hoy", null, "Proc_Correo_Enviado_Hoy");
            persistence.AddParameter("@Correos_Secuencia", correosSecuencia);
            System.Data.IDataReader reader = null;
            bool readerRead;
            try
            {
                reader = persistence.ExecuteReader();
                for (readerRead = reader.Read(); (readerRead == true); readerRead = reader.Read())
                {
                    OSIS.PEPPAM.BOM.Proc_Correo_Enviado_Hoy _load = new OSIS.PEPPAM.BOM.Proc_Correo_Enviado_Hoy();
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


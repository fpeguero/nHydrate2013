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

using System; 
using System.Web; 
using System.Linq; 
using System.Collections.Generic; 
using CodeFluent.Runtime; 
using CodeFluent.Runtime.Utilities; 
using System.ComponentModel.DataAnnotations; 
using FluentValidation; 
using FluentValidation.Attributes; 
using OSIS.PEPPAM.Mvc.Models; 

namespace OSIS.PEPPAM.Mvc.Models 
{ 
	public partial class Zonas_MasterModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Master","Zona_Secuencia")]
		public int Zona_Secuencia { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Master","Zona_Descripcion")]
		public String Zona_Descripcion { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Master","Zona_Nota")]
		public String Zona_Nota { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Master","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Master","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Master","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        private List<OSIS.PEPPAM.Mvc.Models.Rutas_MasterModel> _rutas;
		/// <summary>
		/// The back navigation definition for walking [Zonas_Master]->[Rutas_Master]
		/// Relationship Links: 
		/// [Zonas_Master.Zona_Secuencia = Rutas_Master.Zona_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Rutas_MasterModel> Rutas
        {
            get
            {
                if ((this._rutas == null))
                {
                    this._rutas = OSIS.PEPPAM.Mvc.Models.Rutas_MasterModel.LoadByZonasMaster(this);
                }
                return this._rutas;
            }
        }

        private List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> _encargados;
		/// <summary>
		/// The back navigation definition for walking [Zonas_Master]->[Zonas_Encargados_Trans]
		/// Relationship Links: 
		/// [Zonas_Master.Zona_Secuencia = Zonas_Encargados_Trans.Zona_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> Encargados
        {
            get
            {
                if ((this._encargados == null))
                {
                    this._encargados = OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel.LoadByZona(this);
                }
                return this._encargados;
            }
        }

        private List<OSIS.PEPPAM.Mvc.Models.Congregaciones_MasterModel> _congregaciones;
		/// <summary>
		/// The back navigation definition for walking [Zonas_Master]->[Congregaciones_Master]
		/// Relationship Links: 
		/// [Zonas_Master.Zona_Secuencia = Congregaciones_Master.Zona_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Congregaciones_MasterModel> Congregaciones
        {
            get
            {
                if ((this._congregaciones == null))
                {
                    this._congregaciones = OSIS.PEPPAM.Mvc.Models.Congregaciones_MasterModel.LoadByZona(this);
                }
                return this._congregaciones;
            }
        }

        private List<OSIS.PEPPAM.Mvc.Models.Notificaciones_Objetivo_TransModel> _notificaciones_Objetivo_Trans;
		/// <summary>
		/// The back navigation definition for walking [Zonas_Master]->[Notificaciones_Objetivo_Trans]
		/// Relationship Links: 
		/// [Zonas_Master.Zona_Secuencia = Notificaciones_Objetivo_Trans.Zona_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Notificaciones_Objetivo_TransModel> NotificacionesObjetivoTrans
        {
            get
            {
                if ((this._notificaciones_Objetivo_Trans == null))
                {
                    this._notificaciones_Objetivo_Trans = OSIS.PEPPAM.Mvc.Models.Notificaciones_Objetivo_TransModel.LoadByZonasMaster(this);
                }
                return this._notificaciones_Objetivo_Trans;
            }
        }

        private List<OSIS.PEPPAM.Mvc.Models.Documentos_Objetivos_TransModel> _documentos_Objetivos_Trans;
		/// <summary>
		/// The back navigation definition for walking [Zonas_Master]->[Documentos_Objetivos_Trans]
		/// Relationship Links: 
		/// [Zonas_Master.Zona_Secuencia = Documentos_Objetivos_Trans.Zona_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Documentos_Objetivos_TransModel> DocumentosObjetivosTrans
        {
            get
            {
                if ((this._documentos_Objetivos_Trans == null))
                {
                    this._documentos_Objetivos_Trans = OSIS.PEPPAM.Mvc.Models.Documentos_Objetivos_TransModel.LoadByZonasMaster(this);
                }
                return this._documentos_Objetivos_Trans;
            }
        }

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Zona_Secuencia.ToString();
            }
            set
            {
               this.Zona_Secuencia = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Zona_Descripcion.ToString();
            }
        }
        

        public Zonas_MasterModel()
        {
            this.Zona_Secuencia = -1;
            this.Zona_Descripcion = string.Empty;
            this.Zona_Nota = string.Empty;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Zonas_MasterPartial();
        }

            partial void Zonas_MasterPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zonasMaster)
        {
            if ((zonasMaster == null))
            {
                return false;
            }

            if (
                    (this.Zona_Secuencia == -1)
            )
            {
                return base.Equals(zonasMaster);
            }

 return ((
                    (this.Zona_Secuencia.Equals(zonasMaster.Zona_Secuencia))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zonasMaster = null;
			 zonasMaster = obj as OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel;
            return this.Equals( zonasMaster);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zonasMaster)
        {
            if ((zonasMaster == null))
            {
                throw new System.ArgumentNullException("zonasMaster");
            }
            int localCompareTo = this.Zona_Secuencia.CompareTo(zonasMaster.Zona_Secuencia);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel Load(int zona_Secuencia)
        {
            var _zonasMasterDb = OSIS.PEPPAM.BOM.Zonas_Master.Load(zona_Secuencia);
	        if (_zonasMasterDb == null)
	        {
                return null;
	        }

	        var _zonasMaster = new OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel()
            {
                Zona_Secuencia = _zonasMasterDb.Zona_Secuencia,
                Zona_Descripcion = _zonasMasterDb.Zona_Descripcion,
                Zona_Nota = _zonasMasterDb.Zona_Nota,
                Registro_Estado = _zonasMasterDb.Registro_Estado,
                Registro_Fecha = _zonasMasterDb.Registro_Fecha,
                Registro_Usuario = _zonasMasterDb.Registro_Usuario,

            };

	        return _zonasMaster;
       }

     public virtual bool Save()
	        {
             var _zonasMasterDb = new OSIS.PEPPAM.BOM.Zonas_Master()
	            {
                Zona_Secuencia = this.Zona_Secuencia,
                Zona_Descripcion = this.Zona_Descripcion,
                Zona_Nota = this.Zona_Nota,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _zonasMasterDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Zona_Secuencia = _zonasMasterDb.Zona_Secuencia;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zonasMaster)
        {
            if ((zonasMaster == null))
            {
                return false;
            }
            bool ret = zonasMaster.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zonasMaster)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel.Save(zonasMaster);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel> zonasMaster)
        {
            int index;
            for (index = (zonasMaster.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel _zonasMaster = zonasMaster[index];
                _zonasMaster.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zonasMaster)
        {
            if ((zonasMaster == null))
            {
                return false;
            }
            bool ret = zonasMaster.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _zonasMasterDb = new OSIS.PEPPAM.BOM.Zonas_Master()
	            {
                Zona_Secuencia = this.Zona_Secuencia,

	            };

	            return _zonasMasterDb.Delete();

	        }

        public static bool Delete(int zona_Secuencia)
        {
            if ((zona_Secuencia == default(int)))
            {
                return false;
            }
             var _zonasMasterDb = OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel.Load(zona_Secuencia);
            return _zonasMasterDb.Delete();
        }

        public string Trace()
	        {
             var _zonasMasterDb = new OSIS.PEPPAM.BOM.Zonas_Master()
	            {
                Zona_Secuencia = this.Zona_Secuencia,
                Zona_Descripcion = this.Zona_Descripcion,
                Zona_Nota = this.Zona_Nota,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _zonasMasterDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zonasMaster;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            zonasMaster = OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel.Load( var0);
            return zonasMaster;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel  zonasMaster = new  OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel();
            this.CopyTo(zonasMaster , deep);
            return zonasMaster ;
        }

        public OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel localClone = this.Clone(true);
            return localClone;
        }

        public virtual void CopyFrom(System.Collections.IDictionary dict, bool deep)
        {
            if ((dict == null))
            {
                throw new System.ArgumentNullException("dict");
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
            if ((dict.Contains("Zona_Descripcion") == true))
            {
                this.Zona_Descripcion = ((string)(ConvertUtilities.ChangeType(dict["Zona_Descripcion"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Zona_Nota") == true))
            {
                this.Zona_Nota = ((string)(ConvertUtilities.ChangeType(dict["Zona_Nota"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Zona_Secuencia") == true))
            {
                this.Zona_Secuencia = ((int)(ConvertUtilities.ChangeType(dict["Zona_Secuencia"], typeof(int), -1)));
            }
        }

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel  zonasMaster, bool deep)
        {
            if ((zonasMaster == null))
            {
                throw new System.ArgumentNullException("zonasMaster");
            }
            zonasMaster.Registro_Estado = this.Registro_Estado;
            zonasMaster.Registro_Fecha = this.Registro_Fecha;
            zonasMaster.Registro_Usuario = this.Registro_Usuario;
            zonasMaster.Zona_Descripcion = this.Zona_Descripcion;
            zonasMaster.Zona_Nota = this.Zona_Nota;
            zonasMaster.Zona_Secuencia = this.Zona_Secuencia;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Zonas_MasterCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel>();
	        }

	        var result =  pageLoadAll.Select(
                _zonasMaster => 
                    new OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel()
	        {
                Zona_Secuencia = _zonasMaster.Zona_Secuencia,
                Zona_Descripcion = _zonasMaster.Zona_Descripcion,
                Zona_Nota = _zonasMaster.Zona_Nota,
                Registro_Estado = _zonasMaster.Registro_Estado,
                Registro_Fecha = _zonasMaster.Registro_Fecha,
                Registro_Usuario = _zonasMaster.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Zonas_MasterCollection ret = OSIS.PEPPAM.BOM.Zonas_MasterCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel>();
            }

            var result = ret.Select(
                _zonasMaster =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel()
                    {
                Zona_Secuencia = _zonasMaster.Zona_Secuencia,
                Zona_Descripcion = _zonasMaster.Zona_Descripcion,
                Zona_Nota = _zonasMaster.Zona_Nota,
                Registro_Estado = _zonasMaster.Registro_Estado,
                Registro_Fecha = _zonasMaster.Registro_Fecha,
                Registro_Usuario = _zonasMaster.Registro_Usuario,

                    }).ToList();

            return result;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Zonas_MasterCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel>();
	        }

	        var result =  pageLoadAll.Select(
                _zonasMaster => 
                    new OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel()
	        {
                Zona_Secuencia = _zonasMaster.Zona_Secuencia,
                Zona_Descripcion = _zonasMaster.Zona_Descripcion,
                Zona_Nota = _zonasMaster.Zona_Nota,
                Registro_Estado = _zonasMaster.Registro_Estado,
                Registro_Fecha = _zonasMaster.Registro_Fecha,
                Registro_Usuario = _zonasMaster.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Zonas_MasterCollection ret = OSIS.PEPPAM.BOM.Zonas_MasterCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel>();
            }

            var result = ret.Select(
                _zonasMaster =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel()
                    {
                Zona_Secuencia = _zonasMaster.Zona_Secuencia,
                Zona_Descripcion = _zonasMaster.Zona_Descripcion,
                Zona_Nota = _zonasMaster.Zona_Nota,
                Registro_Estado = _zonasMaster.Registro_Estado,
                Registro_Fecha = _zonasMaster.Registro_Fecha,
                Registro_Usuario = _zonasMaster.Registro_Usuario,

                    }).ToList();

            return result;
        }

	} 
} 


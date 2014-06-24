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
	public partial class Documentos_MasterModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Documentos_Master","Documento_Secuencia")]
		public int Documento_Secuencia { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Documentos_Master","Documento_Nombre")]
		public String Documento_Nombre { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Documentos_Master","Documento_Descripcion")]
		public String Documento_Descripcion { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Documentos_Master","Documento_Archivo_Nombre")]
		public String Documento_Archivo_Nombre { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Documentos_Master","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Documentos_Master","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Documentos_Master","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        private List<OSIS.PEPPAM.Mvc.Models.Documentos_Objetivos_TransModel> _documentos_Objetivos_Trans;
		/// <summary>
		/// The back navigation definition for walking [Documentos_Master]->[Documentos_Objetivos_Trans]
		/// Relationship Links: 
		/// [Documentos_Master.Documento_Secuencia = Documentos_Objetivos_Trans.Documento_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Documentos_Objetivos_TransModel> DocumentosObjetivosTrans
        {
            get
            {
                if ((this._documentos_Objetivos_Trans == null))
                {
                    this._documentos_Objetivos_Trans = OSIS.PEPPAM.Mvc.Models.Documentos_Objetivos_TransModel.LoadByDocumentosMaster(this);
                }
                return this._documentos_Objetivos_Trans;
            }
        }

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Documento_Secuencia.ToString();
            }
            set
            {
               this.Documento_Secuencia = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Documento_Nombre.ToString();
            }
        }
        

        public Documentos_MasterModel()
        {
            this.Documento_Secuencia = -1;
            this.Documento_Nombre = string.Empty;
            this.Documento_Descripcion = string.Empty;
            this.Documento_Archivo_Nombre = string.Empty;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Documentos_MasterPartial();
        }

            partial void Documentos_MasterPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel documentosMaster)
        {
            if ((documentosMaster == null))
            {
                return false;
            }

            if (
                    (this.Documento_Secuencia == -1)
            )
            {
                return base.Equals(documentosMaster);
            }

 return ((
                    (this.Documento_Secuencia.Equals(documentosMaster.Documento_Secuencia))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel documentosMaster = null;
			 documentosMaster = obj as OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel;
            return this.Equals( documentosMaster);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel documentosMaster)
        {
            if ((documentosMaster == null))
            {
                throw new System.ArgumentNullException("documentosMaster");
            }
            int localCompareTo = this.Documento_Secuencia.CompareTo(documentosMaster.Documento_Secuencia);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel Load(int documento_Secuencia)
        {
            var _documentosMasterDb = OSIS.PEPPAM.BOM.Documentos_Master.Load(documento_Secuencia);
	        if (_documentosMasterDb == null)
	        {
                return null;
	        }

	        var _documentosMaster = new OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel()
            {
                Documento_Secuencia = _documentosMasterDb.Documento_Secuencia,
                Documento_Nombre = _documentosMasterDb.Documento_Nombre,
                Documento_Descripcion = _documentosMasterDb.Documento_Descripcion,
                Documento_Archivo_Nombre = _documentosMasterDb.Documento_Archivo_Nombre,
                Registro_Estado = _documentosMasterDb.Registro_Estado,
                Registro_Fecha = _documentosMasterDb.Registro_Fecha,
                Registro_Usuario = _documentosMasterDb.Registro_Usuario,

            };

	        return _documentosMaster;
       }

     public virtual bool Save()
	        {
             var _documentosMasterDb = new OSIS.PEPPAM.BOM.Documentos_Master()
	            {
                Documento_Secuencia = this.Documento_Secuencia,
                Documento_Nombre = this.Documento_Nombre,
                Documento_Descripcion = this.Documento_Descripcion,
                Documento_Archivo_Nombre = this.Documento_Archivo_Nombre,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _documentosMasterDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Documento_Secuencia = _documentosMasterDb.Documento_Secuencia;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel documentosMaster)
        {
            if ((documentosMaster == null))
            {
                return false;
            }
            bool ret = documentosMaster.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel documentosMaster)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel.Save(documentosMaster);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel> documentosMaster)
        {
            int index;
            for (index = (documentosMaster.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel _documentosMaster = documentosMaster[index];
                _documentosMaster.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel documentosMaster)
        {
            if ((documentosMaster == null))
            {
                return false;
            }
            bool ret = documentosMaster.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _documentosMasterDb = new OSIS.PEPPAM.BOM.Documentos_Master()
	            {
                Documento_Secuencia = this.Documento_Secuencia,

	            };

	            return _documentosMasterDb.Delete();

	        }

        public static bool Delete(int documento_Secuencia)
        {
            if ((documento_Secuencia == default(int)))
            {
                return false;
            }
             var _documentosMasterDb = OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel.Load(documento_Secuencia);
            return _documentosMasterDb.Delete();
        }

        public string Trace()
	        {
             var _documentosMasterDb = new OSIS.PEPPAM.BOM.Documentos_Master()
	            {
                Documento_Secuencia = this.Documento_Secuencia,
                Documento_Nombre = this.Documento_Nombre,
                Documento_Descripcion = this.Documento_Descripcion,
                Documento_Archivo_Nombre = this.Documento_Archivo_Nombre,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _documentosMasterDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel documentosMaster;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            documentosMaster = OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel.Load( var0);
            return documentosMaster;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel  documentosMaster = new  OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel();
            this.CopyTo(documentosMaster , deep);
            return documentosMaster ;
        }

        public OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel localClone = this.Clone(true);
            return localClone;
        }

        public virtual void CopyFrom(System.Collections.IDictionary dict, bool deep)
        {
            if ((dict == null))
            {
                throw new System.ArgumentNullException("dict");
            }
            if ((dict.Contains("Documento_Archivo_Nombre") == true))
            {
                this.Documento_Archivo_Nombre = ((string)(ConvertUtilities.ChangeType(dict["Documento_Archivo_Nombre"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Documento_Descripcion") == true))
            {
                this.Documento_Descripcion = ((string)(ConvertUtilities.ChangeType(dict["Documento_Descripcion"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Documento_Nombre") == true))
            {
                this.Documento_Nombre = ((string)(ConvertUtilities.ChangeType(dict["Documento_Nombre"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Documento_Secuencia") == true))
            {
                this.Documento_Secuencia = ((int)(ConvertUtilities.ChangeType(dict["Documento_Secuencia"], typeof(int), -1)));
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
        }

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel  documentosMaster, bool deep)
        {
            if ((documentosMaster == null))
            {
                throw new System.ArgumentNullException("documentosMaster");
            }
            documentosMaster.Documento_Archivo_Nombre = this.Documento_Archivo_Nombre;
            documentosMaster.Documento_Descripcion = this.Documento_Descripcion;
            documentosMaster.Documento_Nombre = this.Documento_Nombre;
            documentosMaster.Documento_Secuencia = this.Documento_Secuencia;
            documentosMaster.Registro_Estado = this.Registro_Estado;
            documentosMaster.Registro_Fecha = this.Registro_Fecha;
            documentosMaster.Registro_Usuario = this.Registro_Usuario;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Documentos_MasterCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel>();
	        }

	        var result =  pageLoadAll.Select(
                _documentosMaster => 
                    new OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel()
	        {
                Documento_Secuencia = _documentosMaster.Documento_Secuencia,
                Documento_Nombre = _documentosMaster.Documento_Nombre,
                Documento_Descripcion = _documentosMaster.Documento_Descripcion,
                Documento_Archivo_Nombre = _documentosMaster.Documento_Archivo_Nombre,
                Registro_Estado = _documentosMaster.Registro_Estado,
                Registro_Fecha = _documentosMaster.Registro_Fecha,
                Registro_Usuario = _documentosMaster.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Documentos_MasterCollection ret = OSIS.PEPPAM.BOM.Documentos_MasterCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel>();
            }

            var result = ret.Select(
                _documentosMaster =>
                    new OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel()
                    {
                Documento_Secuencia = _documentosMaster.Documento_Secuencia,
                Documento_Nombre = _documentosMaster.Documento_Nombre,
                Documento_Descripcion = _documentosMaster.Documento_Descripcion,
                Documento_Archivo_Nombre = _documentosMaster.Documento_Archivo_Nombre,
                Registro_Estado = _documentosMaster.Registro_Estado,
                Registro_Fecha = _documentosMaster.Registro_Fecha,
                Registro_Usuario = _documentosMaster.Registro_Usuario,

                    }).ToList();

            return result;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Documentos_MasterCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel>();
	        }

	        var result =  pageLoadAll.Select(
                _documentosMaster => 
                    new OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel()
	        {
                Documento_Secuencia = _documentosMaster.Documento_Secuencia,
                Documento_Nombre = _documentosMaster.Documento_Nombre,
                Documento_Descripcion = _documentosMaster.Documento_Descripcion,
                Documento_Archivo_Nombre = _documentosMaster.Documento_Archivo_Nombre,
                Registro_Estado = _documentosMaster.Registro_Estado,
                Registro_Fecha = _documentosMaster.Registro_Fecha,
                Registro_Usuario = _documentosMaster.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Documentos_MasterCollection ret = OSIS.PEPPAM.BOM.Documentos_MasterCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel>();
            }

            var result = ret.Select(
                _documentosMaster =>
                    new OSIS.PEPPAM.Mvc.Models.Documentos_MasterModel()
                    {
                Documento_Secuencia = _documentosMaster.Documento_Secuencia,
                Documento_Nombre = _documentosMaster.Documento_Nombre,
                Documento_Descripcion = _documentosMaster.Documento_Descripcion,
                Documento_Archivo_Nombre = _documentosMaster.Documento_Archivo_Nombre,
                Registro_Estado = _documentosMaster.Registro_Estado,
                Registro_Fecha = _documentosMaster.Registro_Fecha,
                Registro_Usuario = _documentosMaster.Registro_Usuario,

                    }).ToList();

            return result;
        }


public static List<OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel> PersonaDocumentos(int? usuarioNumero)
        {
            var _persona_Documentos = OSIS.PEPPAM.BOM.Documentos_Master.PersonaDocumentos(
usuarioNumero);



            if ((_persona_Documentos == null))
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel>();
            }

            var result = _persona_Documentos.Select(
                x =>
                    new OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel()
                    {
                Documento_Archivo_Nombre = x.Documento_Archivo_Nombre,
                Documento_Descripcion = x.Documento_Descripcion,
                Documento_Nombre = x.Documento_Nombre,
                Documento_Secuencia = x.Documento_Secuencia.Value,
                Registro_Estado = x.Registro_Estado,
                Registro_Fecha = x.Registro_Fecha.Value,
                Registro_Usuario = x.Registro_Usuario                    }).ToList();

            return result;
        }
	} 
} 


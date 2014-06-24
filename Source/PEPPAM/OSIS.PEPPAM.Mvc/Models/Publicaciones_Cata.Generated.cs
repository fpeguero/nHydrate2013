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
	public partial class Publicaciones_CataModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Publicaciones_Cata","Publicacion_Numero")]
		public int Publicacion_Numero { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Publicaciones_Cata","Publicacion_Descripcion")]
		public String Publicacion_Descripcion { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Publicaciones_Cata","Publicacion_Simbolo")]
		public String Publicacion_Simbolo { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Publicaciones_Cata","Publicacion_Orden")]
		public int Publicacion_Orden { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Publicaciones_Cata","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Publicaciones_Cata","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Publicaciones_Cata","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        private List<OSIS.PEPPAM.Mvc.Models.Horario_Turno_Informe_TransModel> _horario_Turno_Informe_Trans;
		/// <summary>
		/// The back navigation definition for walking [Publicaciones_Cata]->[Horario_Turno_Informe_Trans]
		/// Relationship Links: 
		/// [Publicaciones_Cata.Publicacion_Numero = Horario_Turno_Informe_Trans.Publicacion_Numero] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Horario_Turno_Informe_TransModel> HorarioTurnoInformeTrans
        {
            get
            {
                if ((this._horario_Turno_Informe_Trans == null))
                {
                    this._horario_Turno_Informe_Trans = OSIS.PEPPAM.Mvc.Models.Horario_Turno_Informe_TransModel.LoadByPublicacionesCata(this);
                }
                return this._horario_Turno_Informe_Trans;
            }
        }

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Publicacion_Numero.ToString();
            }
            set
            {
               this.Publicacion_Numero = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Publicacion_Descripcion.ToString();
            }
        }
        

        public Publicaciones_CataModel()
        {
            this.Publicacion_Numero = -1;
            this.Publicacion_Descripcion = string.Empty;
            this.Publicacion_Simbolo = string.Empty;
            this.Publicacion_Orden = -1;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Publicaciones_CataPartial();
        }

            partial void Publicaciones_CataPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel publicacionesCata)
        {
            if ((publicacionesCata == null))
            {
                return false;
            }

            if (
                    (this.Publicacion_Numero == -1)
            )
            {
                return base.Equals(publicacionesCata);
            }

 return ((
                    (this.Publicacion_Numero.Equals(publicacionesCata.Publicacion_Numero))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel publicacionesCata = null;
			 publicacionesCata = obj as OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel;
            return this.Equals( publicacionesCata);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel publicacionesCata)
        {
            if ((publicacionesCata == null))
            {
                throw new System.ArgumentNullException("publicacionesCata");
            }
            int localCompareTo = this.Publicacion_Numero.CompareTo(publicacionesCata.Publicacion_Numero);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel Load(int publicacion_Numero)
        {
            var _publicacionesCataDb = OSIS.PEPPAM.BOM.Publicaciones_Cata.Load(publicacion_Numero);
	        if (_publicacionesCataDb == null)
	        {
                return null;
	        }

	        var _publicacionesCata = new OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel()
            {
                Publicacion_Numero = _publicacionesCataDb.Publicacion_Numero,
                Publicacion_Descripcion = _publicacionesCataDb.Publicacion_Descripcion,
                Publicacion_Simbolo = _publicacionesCataDb.Publicacion_Simbolo,
                Publicacion_Orden = _publicacionesCataDb.Publicacion_Orden,
                Registro_Estado = _publicacionesCataDb.Registro_Estado,
                Registro_Fecha = _publicacionesCataDb.Registro_Fecha,
                Registro_Usuario = _publicacionesCataDb.Registro_Usuario,

            };

	        return _publicacionesCata;
       }

     public virtual bool Save()
	        {
             var _publicacionesCataDb = new OSIS.PEPPAM.BOM.Publicaciones_Cata()
	            {
                Publicacion_Numero = this.Publicacion_Numero,
                Publicacion_Descripcion = this.Publicacion_Descripcion,
                Publicacion_Simbolo = this.Publicacion_Simbolo,
                Publicacion_Orden = this.Publicacion_Orden,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _publicacionesCataDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Publicacion_Numero = _publicacionesCataDb.Publicacion_Numero;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel publicacionesCata)
        {
            if ((publicacionesCata == null))
            {
                return false;
            }
            bool ret = publicacionesCata.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel publicacionesCata)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel.Save(publicacionesCata);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel> publicacionesCata)
        {
            int index;
            for (index = (publicacionesCata.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel _publicacionesCata = publicacionesCata[index];
                _publicacionesCata.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel publicacionesCata)
        {
            if ((publicacionesCata == null))
            {
                return false;
            }
            bool ret = publicacionesCata.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _publicacionesCataDb = new OSIS.PEPPAM.BOM.Publicaciones_Cata()
	            {
                Publicacion_Numero = this.Publicacion_Numero,

	            };

	            return _publicacionesCataDb.Delete();

	        }

        public static bool Delete(int publicacion_Numero)
        {
            if ((publicacion_Numero == default(int)))
            {
                return false;
            }
             var _publicacionesCataDb = OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel.Load(publicacion_Numero);
            return _publicacionesCataDb.Delete();
        }

        public string Trace()
	        {
             var _publicacionesCataDb = new OSIS.PEPPAM.BOM.Publicaciones_Cata()
	            {
                Publicacion_Numero = this.Publicacion_Numero,
                Publicacion_Descripcion = this.Publicacion_Descripcion,
                Publicacion_Simbolo = this.Publicacion_Simbolo,
                Publicacion_Orden = this.Publicacion_Orden,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _publicacionesCataDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel publicacionesCata;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            publicacionesCata = OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel.Load( var0);
            return publicacionesCata;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel  publicacionesCata = new  OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel();
            this.CopyTo(publicacionesCata , deep);
            return publicacionesCata ;
        }

        public OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel localClone = this.Clone(true);
            return localClone;
        }

        public virtual void CopyFrom(System.Collections.IDictionary dict, bool deep)
        {
            if ((dict == null))
            {
                throw new System.ArgumentNullException("dict");
            }
            if ((dict.Contains("Publicacion_Descripcion") == true))
            {
                this.Publicacion_Descripcion = ((string)(ConvertUtilities.ChangeType(dict["Publicacion_Descripcion"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Publicacion_Numero") == true))
            {
                this.Publicacion_Numero = ((int)(ConvertUtilities.ChangeType(dict["Publicacion_Numero"], typeof(int), -1)));
            }
            if ((dict.Contains("Publicacion_Orden") == true))
            {
                this.Publicacion_Orden = ((int)(ConvertUtilities.ChangeType(dict["Publicacion_Orden"], typeof(int), -1)));
            }
            if ((dict.Contains("Publicacion_Simbolo") == true))
            {
                this.Publicacion_Simbolo = ((string)(ConvertUtilities.ChangeType(dict["Publicacion_Simbolo"], typeof(string), string.Empty)));
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

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel  publicacionesCata, bool deep)
        {
            if ((publicacionesCata == null))
            {
                throw new System.ArgumentNullException("publicacionesCata");
            }
            publicacionesCata.Publicacion_Descripcion = this.Publicacion_Descripcion;
            publicacionesCata.Publicacion_Numero = this.Publicacion_Numero;
            publicacionesCata.Publicacion_Orden = this.Publicacion_Orden;
            publicacionesCata.Publicacion_Simbolo = this.Publicacion_Simbolo;
            publicacionesCata.Registro_Estado = this.Registro_Estado;
            publicacionesCata.Registro_Fecha = this.Registro_Fecha;
            publicacionesCata.Registro_Usuario = this.Registro_Usuario;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Publicaciones_CataCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _publicacionesCata => 
                    new OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel()
	        {
                Publicacion_Numero = _publicacionesCata.Publicacion_Numero,
                Publicacion_Descripcion = _publicacionesCata.Publicacion_Descripcion,
                Publicacion_Simbolo = _publicacionesCata.Publicacion_Simbolo,
                Publicacion_Orden = _publicacionesCata.Publicacion_Orden,
                Registro_Estado = _publicacionesCata.Registro_Estado,
                Registro_Fecha = _publicacionesCata.Registro_Fecha,
                Registro_Usuario = _publicacionesCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Publicaciones_CataCollection ret = OSIS.PEPPAM.BOM.Publicaciones_CataCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel>();
            }

            var result = ret.Select(
                _publicacionesCata =>
                    new OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel()
                    {
                Publicacion_Numero = _publicacionesCata.Publicacion_Numero,
                Publicacion_Descripcion = _publicacionesCata.Publicacion_Descripcion,
                Publicacion_Simbolo = _publicacionesCata.Publicacion_Simbolo,
                Publicacion_Orden = _publicacionesCata.Publicacion_Orden,
                Registro_Estado = _publicacionesCata.Registro_Estado,
                Registro_Fecha = _publicacionesCata.Registro_Fecha,
                Registro_Usuario = _publicacionesCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Publicaciones_CataCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _publicacionesCata => 
                    new OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel()
	        {
                Publicacion_Numero = _publicacionesCata.Publicacion_Numero,
                Publicacion_Descripcion = _publicacionesCata.Publicacion_Descripcion,
                Publicacion_Simbolo = _publicacionesCata.Publicacion_Simbolo,
                Publicacion_Orden = _publicacionesCata.Publicacion_Orden,
                Registro_Estado = _publicacionesCata.Registro_Estado,
                Registro_Fecha = _publicacionesCata.Registro_Fecha,
                Registro_Usuario = _publicacionesCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Publicaciones_CataCollection ret = OSIS.PEPPAM.BOM.Publicaciones_CataCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel>();
            }

            var result = ret.Select(
                _publicacionesCata =>
                    new OSIS.PEPPAM.Mvc.Models.Publicaciones_CataModel()
                    {
                Publicacion_Numero = _publicacionesCata.Publicacion_Numero,
                Publicacion_Descripcion = _publicacionesCata.Publicacion_Descripcion,
                Publicacion_Simbolo = _publicacionesCata.Publicacion_Simbolo,
                Publicacion_Orden = _publicacionesCata.Publicacion_Orden,
                Registro_Estado = _publicacionesCata.Registro_Estado,
                Registro_Fecha = _publicacionesCata.Registro_Fecha,
                Registro_Usuario = _publicacionesCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	} 
} 



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
	public partial class Idiomas_CataModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Idiomas_Cata","Idioma_Numero")]
		public int Idioma_Numero { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Idiomas_Cata","Idioma_Descripcion")]
		public String Idioma_Descripcion { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Idiomas_Cata","Idioma_Simbolo")]
		public String Idioma_Simbolo { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Idiomas_Cata","Idioma_Orden")]
		public int Idioma_Orden { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Idiomas_Cata","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Idiomas_Cata","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Idiomas_Cata","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        private List<OSIS.PEPPAM.Mvc.Models.Horario_Turno_Informe_TransModel> _horario_Turno_Informe_Trans;
		/// <summary>
		/// The back navigation definition for walking [Idiomas_Cata]->[Horario_Turno_Informe_Trans]
		/// Relationship Links: 
		/// [Idiomas_Cata.Idioma_Numero = Horario_Turno_Informe_Trans.Idioma_Numero] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Horario_Turno_Informe_TransModel> HorarioTurnoInformeTrans
        {
            get
            {
                if ((this._horario_Turno_Informe_Trans == null))
                {
                    this._horario_Turno_Informe_Trans = OSIS.PEPPAM.Mvc.Models.Horario_Turno_Informe_TransModel.LoadByIdiomasCata(this);
                }
                return this._horario_Turno_Informe_Trans;
            }
        }

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Idioma_Numero.ToString();
            }
            set
            {
               this.Idioma_Numero = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Idioma_Descripcion.ToString();
            }
        }
        

        public Idiomas_CataModel()
        {
            this.Idioma_Numero = -1;
            this.Idioma_Descripcion = string.Empty;
            this.Idioma_Simbolo = string.Empty;
            this.Idioma_Orden = -1;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Idiomas_CataPartial();
        }

            partial void Idiomas_CataPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel idiomasCata)
        {
            if ((idiomasCata == null))
            {
                return false;
            }

            if (
                    (this.Idioma_Numero == -1)
            )
            {
                return base.Equals(idiomasCata);
            }

 return ((
                    (this.Idioma_Numero.Equals(idiomasCata.Idioma_Numero))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel idiomasCata = null;
			 idiomasCata = obj as OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel;
            return this.Equals( idiomasCata);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel idiomasCata)
        {
            if ((idiomasCata == null))
            {
                throw new System.ArgumentNullException("idiomasCata");
            }
            int localCompareTo = this.Idioma_Numero.CompareTo(idiomasCata.Idioma_Numero);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel Load(int idioma_Numero)
        {
            var _idiomasCataDb = OSIS.PEPPAM.BOM.Idiomas_Cata.Load(idioma_Numero);
	        if (_idiomasCataDb == null)
	        {
                return null;
	        }

	        var _idiomasCata = new OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel()
            {
                Idioma_Numero = _idiomasCataDb.Idioma_Numero,
                Idioma_Descripcion = _idiomasCataDb.Idioma_Descripcion,
                Idioma_Simbolo = _idiomasCataDb.Idioma_Simbolo,
                Idioma_Orden = _idiomasCataDb.Idioma_Orden,
                Registro_Estado = _idiomasCataDb.Registro_Estado,
                Registro_Fecha = _idiomasCataDb.Registro_Fecha,
                Registro_Usuario = _idiomasCataDb.Registro_Usuario,

            };

	        return _idiomasCata;
       }

     public virtual bool Save()
	        {
             var _idiomasCataDb = new OSIS.PEPPAM.BOM.Idiomas_Cata()
	            {
                Idioma_Numero = this.Idioma_Numero,
                Idioma_Descripcion = this.Idioma_Descripcion,
                Idioma_Simbolo = this.Idioma_Simbolo,
                Idioma_Orden = this.Idioma_Orden,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _idiomasCataDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Idioma_Numero = _idiomasCataDb.Idioma_Numero;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel idiomasCata)
        {
            if ((idiomasCata == null))
            {
                return false;
            }
            bool ret = idiomasCata.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel idiomasCata)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel.Save(idiomasCata);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel> idiomasCata)
        {
            int index;
            for (index = (idiomasCata.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel _idiomasCata = idiomasCata[index];
                _idiomasCata.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel idiomasCata)
        {
            if ((idiomasCata == null))
            {
                return false;
            }
            bool ret = idiomasCata.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _idiomasCataDb = new OSIS.PEPPAM.BOM.Idiomas_Cata()
	            {
                Idioma_Numero = this.Idioma_Numero,

	            };

	            return _idiomasCataDb.Delete();

	        }

        public static bool Delete(int idioma_Numero)
        {
            if ((idioma_Numero == default(int)))
            {
                return false;
            }
             var _idiomasCataDb = OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel.Load(idioma_Numero);
            return _idiomasCataDb.Delete();
        }

        public string Trace()
	        {
             var _idiomasCataDb = new OSIS.PEPPAM.BOM.Idiomas_Cata()
	            {
                Idioma_Numero = this.Idioma_Numero,
                Idioma_Descripcion = this.Idioma_Descripcion,
                Idioma_Simbolo = this.Idioma_Simbolo,
                Idioma_Orden = this.Idioma_Orden,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _idiomasCataDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel idiomasCata;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            idiomasCata = OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel.Load( var0);
            return idiomasCata;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel  idiomasCata = new  OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel();
            this.CopyTo(idiomasCata , deep);
            return idiomasCata ;
        }

        public OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel localClone = this.Clone(true);
            return localClone;
        }

        public virtual void CopyFrom(System.Collections.IDictionary dict, bool deep)
        {
            if ((dict == null))
            {
                throw new System.ArgumentNullException("dict");
            }
            if ((dict.Contains("Idioma_Descripcion") == true))
            {
                this.Idioma_Descripcion = ((string)(ConvertUtilities.ChangeType(dict["Idioma_Descripcion"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Idioma_Numero") == true))
            {
                this.Idioma_Numero = ((int)(ConvertUtilities.ChangeType(dict["Idioma_Numero"], typeof(int), -1)));
            }
            if ((dict.Contains("Idioma_Orden") == true))
            {
                this.Idioma_Orden = ((int)(ConvertUtilities.ChangeType(dict["Idioma_Orden"], typeof(int), -1)));
            }
            if ((dict.Contains("Idioma_Simbolo") == true))
            {
                this.Idioma_Simbolo = ((string)(ConvertUtilities.ChangeType(dict["Idioma_Simbolo"], typeof(string), string.Empty)));
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

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel  idiomasCata, bool deep)
        {
            if ((idiomasCata == null))
            {
                throw new System.ArgumentNullException("idiomasCata");
            }
            idiomasCata.Idioma_Descripcion = this.Idioma_Descripcion;
            idiomasCata.Idioma_Numero = this.Idioma_Numero;
            idiomasCata.Idioma_Orden = this.Idioma_Orden;
            idiomasCata.Idioma_Simbolo = this.Idioma_Simbolo;
            idiomasCata.Registro_Estado = this.Registro_Estado;
            idiomasCata.Registro_Fecha = this.Registro_Fecha;
            idiomasCata.Registro_Usuario = this.Registro_Usuario;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Idiomas_CataCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _idiomasCata => 
                    new OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel()
	        {
                Idioma_Numero = _idiomasCata.Idioma_Numero,
                Idioma_Descripcion = _idiomasCata.Idioma_Descripcion,
                Idioma_Simbolo = _idiomasCata.Idioma_Simbolo,
                Idioma_Orden = _idiomasCata.Idioma_Orden,
                Registro_Estado = _idiomasCata.Registro_Estado,
                Registro_Fecha = _idiomasCata.Registro_Fecha,
                Registro_Usuario = _idiomasCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Idiomas_CataCollection ret = OSIS.PEPPAM.BOM.Idiomas_CataCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel>();
            }

            var result = ret.Select(
                _idiomasCata =>
                    new OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel()
                    {
                Idioma_Numero = _idiomasCata.Idioma_Numero,
                Idioma_Descripcion = _idiomasCata.Idioma_Descripcion,
                Idioma_Simbolo = _idiomasCata.Idioma_Simbolo,
                Idioma_Orden = _idiomasCata.Idioma_Orden,
                Registro_Estado = _idiomasCata.Registro_Estado,
                Registro_Fecha = _idiomasCata.Registro_Fecha,
                Registro_Usuario = _idiomasCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Idiomas_CataCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _idiomasCata => 
                    new OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel()
	        {
                Idioma_Numero = _idiomasCata.Idioma_Numero,
                Idioma_Descripcion = _idiomasCata.Idioma_Descripcion,
                Idioma_Simbolo = _idiomasCata.Idioma_Simbolo,
                Idioma_Orden = _idiomasCata.Idioma_Orden,
                Registro_Estado = _idiomasCata.Registro_Estado,
                Registro_Fecha = _idiomasCata.Registro_Fecha,
                Registro_Usuario = _idiomasCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Idiomas_CataCollection ret = OSIS.PEPPAM.BOM.Idiomas_CataCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel>();
            }

            var result = ret.Select(
                _idiomasCata =>
                    new OSIS.PEPPAM.Mvc.Models.Idiomas_CataModel()
                    {
                Idioma_Numero = _idiomasCata.Idioma_Numero,
                Idioma_Descripcion = _idiomasCata.Idioma_Descripcion,
                Idioma_Simbolo = _idiomasCata.Idioma_Simbolo,
                Idioma_Orden = _idiomasCata.Idioma_Orden,
                Registro_Estado = _idiomasCata.Registro_Estado,
                Registro_Fecha = _idiomasCata.Registro_Fecha,
                Registro_Usuario = _idiomasCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	} 
} 



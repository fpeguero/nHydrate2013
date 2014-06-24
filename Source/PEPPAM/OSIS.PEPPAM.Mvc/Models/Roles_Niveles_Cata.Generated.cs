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
	public partial class Roles_Niveles_CataModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Roles_Niveles_Cata","Role_Nivel_Numero")]
		public int Role_Nivel_Numero { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Roles_Niveles_Cata","Role_Nivel")]
		public int Role_Nivel { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Roles_Niveles_Cata","Role_Nivel_Nombre")]
		public String Role_Nivel_Nombre { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Roles_Niveles_Cata","Role_Nivel_Descripcion")]
		public String Role_Nivel_Descripcion { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Roles_Niveles_Cata","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Roles_Niveles_Cata","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Roles_Niveles_Cata","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        private List<OSIS.PEPPAM.Mvc.Models.Roles_CataModel> _roles_Cata;
		/// <summary>
		/// The back navigation definition for walking [Roles_Niveles_Cata]->[Roles_Cata]
		/// Relationship Links: 
		/// [Roles_Niveles_Cata.Role_Nivel_Numero = Roles_Cata.Role_Nivel_Numero] (Optional)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Roles_CataModel> RolesCata
        {
            get
            {
                if ((this._roles_Cata == null))
                {
                    this._roles_Cata = OSIS.PEPPAM.Mvc.Models.Roles_CataModel.LoadByRolesNivelesCata(this);
                }
                return this._roles_Cata;
            }
        }

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Role_Nivel_Numero.ToString();
            }
            set
            {
               this.Role_Nivel_Numero = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Role_Nivel_Nombre.ToString();
            }
        }
        

        public Roles_Niveles_CataModel()
        {
            this.Role_Nivel_Numero = -1;
            this.Role_Nivel = -1;
            this.Role_Nivel_Nombre = string.Empty;
            this.Role_Nivel_Descripcion = string.Empty;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Roles_Niveles_CataPartial();
        }

            partial void Roles_Niveles_CataPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel rolesNivelesCata)
        {
            if ((rolesNivelesCata == null))
            {
                return false;
            }

            if (
                    (this.Role_Nivel_Numero == -1)
            )
            {
                return base.Equals(rolesNivelesCata);
            }

 return ((
                    (this.Role_Nivel_Numero.Equals(rolesNivelesCata.Role_Nivel_Numero))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel rolesNivelesCata = null;
			 rolesNivelesCata = obj as OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel;
            return this.Equals( rolesNivelesCata);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel rolesNivelesCata)
        {
            if ((rolesNivelesCata == null))
            {
                throw new System.ArgumentNullException("rolesNivelesCata");
            }
            int localCompareTo = this.Role_Nivel_Numero.CompareTo(rolesNivelesCata.Role_Nivel_Numero);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel Load(int role_Nivel_Numero)
        {
            var _rolesNivelesCataDb = OSIS.PEPPAM.BOM.Roles_Niveles_Cata.Load(role_Nivel_Numero);
	        if (_rolesNivelesCataDb == null)
	        {
                return null;
	        }

	        var _rolesNivelesCata = new OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel()
            {
                Role_Nivel_Numero = _rolesNivelesCataDb.Role_Nivel_Numero,
                Role_Nivel = _rolesNivelesCataDb.Role_Nivel,
                Role_Nivel_Nombre = _rolesNivelesCataDb.Role_Nivel_Nombre,
                Role_Nivel_Descripcion = _rolesNivelesCataDb.Role_Nivel_Descripcion,
                Registro_Estado = _rolesNivelesCataDb.Registro_Estado,
                Registro_Fecha = _rolesNivelesCataDb.Registro_Fecha,
                Registro_Usuario = _rolesNivelesCataDb.Registro_Usuario,

            };

	        return _rolesNivelesCata;
       }

     public virtual bool Save()
	        {
             var _rolesNivelesCataDb = new OSIS.PEPPAM.BOM.Roles_Niveles_Cata()
	            {
                Role_Nivel_Numero = this.Role_Nivel_Numero,
                Role_Nivel = this.Role_Nivel,
                Role_Nivel_Nombre = this.Role_Nivel_Nombre,
                Role_Nivel_Descripcion = this.Role_Nivel_Descripcion,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _rolesNivelesCataDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Role_Nivel_Numero = _rolesNivelesCataDb.Role_Nivel_Numero;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel rolesNivelesCata)
        {
            if ((rolesNivelesCata == null))
            {
                return false;
            }
            bool ret = rolesNivelesCata.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel rolesNivelesCata)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel.Save(rolesNivelesCata);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel> rolesNivelesCata)
        {
            int index;
            for (index = (rolesNivelesCata.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel _rolesNivelesCata = rolesNivelesCata[index];
                _rolesNivelesCata.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel rolesNivelesCata)
        {
            if ((rolesNivelesCata == null))
            {
                return false;
            }
            bool ret = rolesNivelesCata.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _rolesNivelesCataDb = new OSIS.PEPPAM.BOM.Roles_Niveles_Cata()
	            {
                Role_Nivel_Numero = this.Role_Nivel_Numero,

	            };

	            return _rolesNivelesCataDb.Delete();

	        }

        public static bool Delete(int role_Nivel_Numero)
        {
            if ((role_Nivel_Numero == default(int)))
            {
                return false;
            }
             var _rolesNivelesCataDb = OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel.Load(role_Nivel_Numero);
            return _rolesNivelesCataDb.Delete();
        }

        public string Trace()
	        {
             var _rolesNivelesCataDb = new OSIS.PEPPAM.BOM.Roles_Niveles_Cata()
	            {
                Role_Nivel_Numero = this.Role_Nivel_Numero,
                Role_Nivel = this.Role_Nivel,
                Role_Nivel_Nombre = this.Role_Nivel_Nombre,
                Role_Nivel_Descripcion = this.Role_Nivel_Descripcion,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _rolesNivelesCataDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel rolesNivelesCata;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            rolesNivelesCata = OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel.Load( var0);
            return rolesNivelesCata;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel  rolesNivelesCata = new  OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel();
            this.CopyTo(rolesNivelesCata , deep);
            return rolesNivelesCata ;
        }

        public OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel localClone = this.Clone(true);
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
            if ((dict.Contains("Role_Nivel") == true))
            {
                this.Role_Nivel = ((int)(ConvertUtilities.ChangeType(dict["Role_Nivel"], typeof(int), -1)));
            }
            if ((dict.Contains("Role_Nivel_Descripcion") == true))
            {
                this.Role_Nivel_Descripcion = ((string)(ConvertUtilities.ChangeType(dict["Role_Nivel_Descripcion"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Role_Nivel_Nombre") == true))
            {
                this.Role_Nivel_Nombre = ((string)(ConvertUtilities.ChangeType(dict["Role_Nivel_Nombre"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Role_Nivel_Numero") == true))
            {
                this.Role_Nivel_Numero = ((int)(ConvertUtilities.ChangeType(dict["Role_Nivel_Numero"], typeof(int), -1)));
            }
        }

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel  rolesNivelesCata, bool deep)
        {
            if ((rolesNivelesCata == null))
            {
                throw new System.ArgumentNullException("rolesNivelesCata");
            }
            rolesNivelesCata.Registro_Estado = this.Registro_Estado;
            rolesNivelesCata.Registro_Fecha = this.Registro_Fecha;
            rolesNivelesCata.Registro_Usuario = this.Registro_Usuario;
            rolesNivelesCata.Role_Nivel = this.Role_Nivel;
            rolesNivelesCata.Role_Nivel_Descripcion = this.Role_Nivel_Descripcion;
            rolesNivelesCata.Role_Nivel_Nombre = this.Role_Nivel_Nombre;
            rolesNivelesCata.Role_Nivel_Numero = this.Role_Nivel_Numero;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Roles_Niveles_CataCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _rolesNivelesCata => 
                    new OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel()
	        {
                Role_Nivel_Numero = _rolesNivelesCata.Role_Nivel_Numero,
                Role_Nivel = _rolesNivelesCata.Role_Nivel,
                Role_Nivel_Nombre = _rolesNivelesCata.Role_Nivel_Nombre,
                Role_Nivel_Descripcion = _rolesNivelesCata.Role_Nivel_Descripcion,
                Registro_Estado = _rolesNivelesCata.Registro_Estado,
                Registro_Fecha = _rolesNivelesCata.Registro_Fecha,
                Registro_Usuario = _rolesNivelesCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Roles_Niveles_CataCollection ret = OSIS.PEPPAM.BOM.Roles_Niveles_CataCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel>();
            }

            var result = ret.Select(
                _rolesNivelesCata =>
                    new OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel()
                    {
                Role_Nivel_Numero = _rolesNivelesCata.Role_Nivel_Numero,
                Role_Nivel = _rolesNivelesCata.Role_Nivel,
                Role_Nivel_Nombre = _rolesNivelesCata.Role_Nivel_Nombre,
                Role_Nivel_Descripcion = _rolesNivelesCata.Role_Nivel_Descripcion,
                Registro_Estado = _rolesNivelesCata.Registro_Estado,
                Registro_Fecha = _rolesNivelesCata.Registro_Fecha,
                Registro_Usuario = _rolesNivelesCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Roles_Niveles_CataCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _rolesNivelesCata => 
                    new OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel()
	        {
                Role_Nivel_Numero = _rolesNivelesCata.Role_Nivel_Numero,
                Role_Nivel = _rolesNivelesCata.Role_Nivel,
                Role_Nivel_Nombre = _rolesNivelesCata.Role_Nivel_Nombre,
                Role_Nivel_Descripcion = _rolesNivelesCata.Role_Nivel_Descripcion,
                Registro_Estado = _rolesNivelesCata.Registro_Estado,
                Registro_Fecha = _rolesNivelesCata.Registro_Fecha,
                Registro_Usuario = _rolesNivelesCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Roles_Niveles_CataCollection ret = OSIS.PEPPAM.BOM.Roles_Niveles_CataCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel>();
            }

            var result = ret.Select(
                _rolesNivelesCata =>
                    new OSIS.PEPPAM.Mvc.Models.Roles_Niveles_CataModel()
                    {
                Role_Nivel_Numero = _rolesNivelesCata.Role_Nivel_Numero,
                Role_Nivel = _rolesNivelesCata.Role_Nivel,
                Role_Nivel_Nombre = _rolesNivelesCata.Role_Nivel_Nombre,
                Role_Nivel_Descripcion = _rolesNivelesCata.Role_Nivel_Descripcion,
                Registro_Estado = _rolesNivelesCata.Registro_Estado,
                Registro_Fecha = _rolesNivelesCata.Registro_Fecha,
                Registro_Usuario = _rolesNivelesCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	} 
} 



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
	public partial class Personas_Tipo_CataModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Personas_Tipo_Cata","Persona_Tipo_Secuencia")]
		public int Persona_Tipo_Secuencia { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Personas_Tipo_Cata","Persona_Tipo_Descripcion")]
		public String Persona_Tipo_Descripcion { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Personas_Tipo_Cata","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Personas_Tipo_Cata","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Personas_Tipo_Cata","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        private List<OSIS.PEPPAM.Mvc.Models.Personas_MasterModel> _personas_Master;
		/// <summary>
		/// The back navigation definition for walking [Personas_Tipo_Cata]->[Personas_Master]
		/// Relationship Links: 
		/// [Personas_Tipo_Cata.Persona_Tipo_Secuencia = Personas_Master.Persona_Tipo_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Personas_MasterModel> PersonasMaster
        {
            get
            {
                if ((this._personas_Master == null))
                {
                    this._personas_Master = OSIS.PEPPAM.Mvc.Models.Personas_MasterModel.LoadByPersonasTipoCata(this);
                }
                return this._personas_Master;
            }
        }

        private List<OSIS.PEPPAM.Mvc.Models.Personas_Tipos_TransModel> _personas_Tipos_Trans;
		/// <summary>
		/// The back navigation definition for walking [Personas_Tipo_Cata]->[Personas_Tipos_Trans]
		/// Relationship Links: 
		/// [Personas_Tipo_Cata.Persona_Tipo_Secuencia = Personas_Tipos_Trans.Persona_Tipo_Secuencia] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Personas_Tipos_TransModel> PersonasTiposTrans
        {
            get
            {
                if ((this._personas_Tipos_Trans == null))
                {
                    this._personas_Tipos_Trans = OSIS.PEPPAM.Mvc.Models.Personas_Tipos_TransModel.LoadByPersonasTipoCata(this);
                }
                return this._personas_Tipos_Trans;
            }
        }

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Persona_Tipo_Secuencia.ToString();
            }
            set
            {
               this.Persona_Tipo_Secuencia = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Persona_Tipo_Descripcion.ToString();
            }
        }
        

        public Personas_Tipo_CataModel()
        {
            this.Persona_Tipo_Secuencia = -1;
            this.Persona_Tipo_Descripcion = string.Empty;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Personas_Tipo_CataPartial();
        }

            partial void Personas_Tipo_CataPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel personasTipoCata)
        {
            if ((personasTipoCata == null))
            {
                return false;
            }

            if (
                    (this.Persona_Tipo_Secuencia == -1)
            )
            {
                return base.Equals(personasTipoCata);
            }

 return ((
                    (this.Persona_Tipo_Secuencia.Equals(personasTipoCata.Persona_Tipo_Secuencia))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel personasTipoCata = null;
			 personasTipoCata = obj as OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel;
            return this.Equals( personasTipoCata);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel personasTipoCata)
        {
            if ((personasTipoCata == null))
            {
                throw new System.ArgumentNullException("personasTipoCata");
            }
            int localCompareTo = this.Persona_Tipo_Secuencia.CompareTo(personasTipoCata.Persona_Tipo_Secuencia);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel Load(int persona_Tipo_Secuencia)
        {
            var _personasTipoCataDb = OSIS.PEPPAM.BOM.Personas_Tipo_Cata.Load(persona_Tipo_Secuencia);
	        if (_personasTipoCataDb == null)
	        {
                return null;
	        }

	        var _personasTipoCata = new OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel()
            {
                Persona_Tipo_Secuencia = _personasTipoCataDb.Persona_Tipo_Secuencia,
                Persona_Tipo_Descripcion = _personasTipoCataDb.Persona_Tipo_Descripcion,
                Registro_Estado = _personasTipoCataDb.Registro_Estado,
                Registro_Fecha = _personasTipoCataDb.Registro_Fecha,
                Registro_Usuario = _personasTipoCataDb.Registro_Usuario,

            };

	        return _personasTipoCata;
       }

     public virtual bool Save()
	        {
             var _personasTipoCataDb = new OSIS.PEPPAM.BOM.Personas_Tipo_Cata()
	            {
                Persona_Tipo_Secuencia = this.Persona_Tipo_Secuencia,
                Persona_Tipo_Descripcion = this.Persona_Tipo_Descripcion,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _personasTipoCataDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Persona_Tipo_Secuencia = _personasTipoCataDb.Persona_Tipo_Secuencia;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel personasTipoCata)
        {
            if ((personasTipoCata == null))
            {
                return false;
            }
            bool ret = personasTipoCata.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel personasTipoCata)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel.Save(personasTipoCata);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel> personasTipoCata)
        {
            int index;
            for (index = (personasTipoCata.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel _personasTipoCata = personasTipoCata[index];
                _personasTipoCata.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel personasTipoCata)
        {
            if ((personasTipoCata == null))
            {
                return false;
            }
            bool ret = personasTipoCata.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _personasTipoCataDb = new OSIS.PEPPAM.BOM.Personas_Tipo_Cata()
	            {
                Persona_Tipo_Secuencia = this.Persona_Tipo_Secuencia,

	            };

	            return _personasTipoCataDb.Delete();

	        }

        public static bool Delete(int persona_Tipo_Secuencia)
        {
            if ((persona_Tipo_Secuencia == default(int)))
            {
                return false;
            }
             var _personasTipoCataDb = OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel.Load(persona_Tipo_Secuencia);
            return _personasTipoCataDb.Delete();
        }

        public string Trace()
	        {
             var _personasTipoCataDb = new OSIS.PEPPAM.BOM.Personas_Tipo_Cata()
	            {
                Persona_Tipo_Secuencia = this.Persona_Tipo_Secuencia,
                Persona_Tipo_Descripcion = this.Persona_Tipo_Descripcion,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _personasTipoCataDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel personasTipoCata;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            personasTipoCata = OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel.Load( var0);
            return personasTipoCata;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel  personasTipoCata = new  OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel();
            this.CopyTo(personasTipoCata , deep);
            return personasTipoCata ;
        }

        public OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel localClone = this.Clone(true);
            return localClone;
        }

        public virtual void CopyFrom(System.Collections.IDictionary dict, bool deep)
        {
            if ((dict == null))
            {
                throw new System.ArgumentNullException("dict");
            }
            if ((dict.Contains("Persona_Tipo_Descripcion") == true))
            {
                this.Persona_Tipo_Descripcion = ((string)(ConvertUtilities.ChangeType(dict["Persona_Tipo_Descripcion"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Persona_Tipo_Secuencia") == true))
            {
                this.Persona_Tipo_Secuencia = ((int)(ConvertUtilities.ChangeType(dict["Persona_Tipo_Secuencia"], typeof(int), -1)));
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

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel  personasTipoCata, bool deep)
        {
            if ((personasTipoCata == null))
            {
                throw new System.ArgumentNullException("personasTipoCata");
            }
            personasTipoCata.Persona_Tipo_Descripcion = this.Persona_Tipo_Descripcion;
            personasTipoCata.Persona_Tipo_Secuencia = this.Persona_Tipo_Secuencia;
            personasTipoCata.Registro_Estado = this.Registro_Estado;
            personasTipoCata.Registro_Fecha = this.Registro_Fecha;
            personasTipoCata.Registro_Usuario = this.Registro_Usuario;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Personas_Tipo_CataCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _personasTipoCata => 
                    new OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel()
	        {
                Persona_Tipo_Secuencia = _personasTipoCata.Persona_Tipo_Secuencia,
                Persona_Tipo_Descripcion = _personasTipoCata.Persona_Tipo_Descripcion,
                Registro_Estado = _personasTipoCata.Registro_Estado,
                Registro_Fecha = _personasTipoCata.Registro_Fecha,
                Registro_Usuario = _personasTipoCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Personas_Tipo_CataCollection ret = OSIS.PEPPAM.BOM.Personas_Tipo_CataCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel>();
            }

            var result = ret.Select(
                _personasTipoCata =>
                    new OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel()
                    {
                Persona_Tipo_Secuencia = _personasTipoCata.Persona_Tipo_Secuencia,
                Persona_Tipo_Descripcion = _personasTipoCata.Persona_Tipo_Descripcion,
                Registro_Estado = _personasTipoCata.Registro_Estado,
                Registro_Fecha = _personasTipoCata.Registro_Fecha,
                Registro_Usuario = _personasTipoCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Personas_Tipo_CataCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _personasTipoCata => 
                    new OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel()
	        {
                Persona_Tipo_Secuencia = _personasTipoCata.Persona_Tipo_Secuencia,
                Persona_Tipo_Descripcion = _personasTipoCata.Persona_Tipo_Descripcion,
                Registro_Estado = _personasTipoCata.Registro_Estado,
                Registro_Fecha = _personasTipoCata.Registro_Fecha,
                Registro_Usuario = _personasTipoCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Personas_Tipo_CataCollection ret = OSIS.PEPPAM.BOM.Personas_Tipo_CataCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel>();
            }

            var result = ret.Select(
                _personasTipoCata =>
                    new OSIS.PEPPAM.Mvc.Models.Personas_Tipo_CataModel()
                    {
                Persona_Tipo_Secuencia = _personasTipoCata.Persona_Tipo_Secuencia,
                Persona_Tipo_Descripcion = _personasTipoCata.Persona_Tipo_Descripcion,
                Registro_Estado = _personasTipoCata.Registro_Estado,
                Registro_Fecha = _personasTipoCata.Registro_Fecha,
                Registro_Usuario = _personasTipoCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	} 
} 


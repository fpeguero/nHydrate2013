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
	public partial class Zonas_Encargados_TransModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Encargados_Trans","Persona_Secuencia")]
		public int Persona_Secuencia { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Encargados_Trans","Zona_Secuencia")]
		public int Zona_Secuencia { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Encargados_Trans","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Encargados_Trans","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Zonas_Encargados_Trans","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        public OSIS.PEPPAM.Mvc.Models.Personas_MasterModel _persona;
		/// <summary>
		/// The navigation definition for walking [Zonas_Encargados_Trans]->[Personas_Master]
		/// Relationship Links: 
		/// [Personas_Master.Persona_Secuencia = Zonas_Encargados_Trans.Persona_Secuencia] (Required)
		/// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
		public virtual OSIS.PEPPAM.Mvc.Models.Personas_MasterModel Persona
		{
			get
			{
                if ((this._persona == null))
                {
                    this._persona = OSIS.PEPPAM.Mvc.Models.Personas_MasterModel.Load(Persona_Secuencia);
                }
                return this._persona;
			}
		}

     private List<OSIS.PEPPAM.Mvc.Models.Personas_MasterModel> _personaList;
		public virtual List<OSIS.PEPPAM.Mvc.Models.Personas_MasterModel> PersonaList
		{
			get
			{
                if ((this._personaList == null))
                {
                    this._personaList = OSIS.PEPPAM.Mvc.Models.Personas_MasterModel.LoadAll();
                }
                return this._personaList;
			}
		}

        public OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel _zona;
		/// <summary>
		/// The navigation definition for walking [Zonas_Encargados_Trans]->[Zonas_Master]
		/// Relationship Links: 
		/// [Zonas_Master.Zona_Secuencia = Zonas_Encargados_Trans.Zona_Secuencia] (Required)
		/// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
		public virtual OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel Zona
		{
			get
			{
                if ((this._zona == null))
                {
                    this._zona = OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel.Load(Zona_Secuencia);
                }
                return this._zona;
			}
		}

     private List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel> _zonaList;
		public virtual List<OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel> ZonaList
		{
			get
			{
                if ((this._zonaList == null))
                {
                    this._zonaList = OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel.LoadAll();
                }
                return this._zonaList;
			}
		}

		#endregion

        public virtual string EntityKey
        {
            get
            {
                object[] keys = new object[] {
                        this.Persona_Secuencia,
                        this.Zona_Secuencia
                 };
                string v = CodeFluentPersistence.BuildEntityKey(keys);
                return v;
            }
            set
            {
                System.Type[] types = new System.Type[] {
                        typeof(int),
                        typeof(int)
                        };
                object[] defaultValues = new object[] {
                        -1,
                        -1
                        };
                object[] v1 = CodeFluentPersistence.ParseEntityKey(value, types, defaultValues);
                this. Persona_Secuencia = ((int)(v1[0]));
                this. Zona_Secuencia = ((int)(v1[1]));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Registro_Estado.ToString();
            }
        }
        

        public Zonas_Encargados_TransModel()
        {
            this.Persona_Secuencia = -1;
            this.Zona_Secuencia = -1;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Zonas_Encargados_TransPartial();
        }

            partial void Zonas_Encargados_TransPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel zonasEncargadosTrans)
        {
            if ((zonasEncargadosTrans == null))
            {
                return false;
            }

            if (
                    (this.Persona_Secuencia == -1)
                    ||
                    (this.Zona_Secuencia == -1)
            )
            {
                return base.Equals(zonasEncargadosTrans);
            }

 return ((
                    (this.Persona_Secuencia.Equals(zonasEncargadosTrans.Persona_Secuencia))
                    &&
                    (this.Zona_Secuencia.Equals(zonasEncargadosTrans.Zona_Secuencia))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel zonasEncargadosTrans = null;
			 zonasEncargadosTrans = obj as OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel;
            return this.Equals( zonasEncargadosTrans);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel zonasEncargadosTrans)
        {
            if ((zonasEncargadosTrans == null))
            {
                throw new System.ArgumentNullException("zonasEncargadosTrans");
            }
            int localCompareTo = this.Persona_Secuencia.CompareTo(zonasEncargadosTrans.Persona_Secuencia);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel Load(int persona_Secuencia,int zona_Secuencia)
        {
            var _zonasEncargadosTransDb = OSIS.PEPPAM.BOM.Zonas_Encargados_Trans.Load(persona_Secuencia,zona_Secuencia);
	        if (_zonasEncargadosTransDb == null)
	        {
                return null;
	        }

	        var _zonasEncargadosTrans = new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
            {
                Persona_Secuencia = _zonasEncargadosTransDb.Persona_Secuencia,
                Zona_Secuencia = _zonasEncargadosTransDb.Zona_Secuencia,
                Registro_Estado = _zonasEncargadosTransDb.Registro_Estado,
                Registro_Fecha = _zonasEncargadosTransDb.Registro_Fecha,
                Registro_Usuario = _zonasEncargadosTransDb.Registro_Usuario,

            };

	        return _zonasEncargadosTrans;
       }

     public virtual bool Save()
	        {
             var _zonasEncargadosTransDb = new OSIS.PEPPAM.BOM.Zonas_Encargados_Trans()
	            {
                Persona_Secuencia = this.Persona_Secuencia,
                Zona_Secuencia = this.Zona_Secuencia,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _zonasEncargadosTransDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Persona_Secuencia = _zonasEncargadosTransDb.Persona_Secuencia;
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Zona_Secuencia = _zonasEncargadosTransDb.Zona_Secuencia;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel zonasEncargadosTrans)
        {
            if ((zonasEncargadosTrans == null))
            {
                return false;
            }
            bool ret = zonasEncargadosTrans.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel zonasEncargadosTrans)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel.Save(zonasEncargadosTrans);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> zonasEncargadosTrans)
        {
            int index;
            for (index = (zonasEncargadosTrans.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel _zonasEncargadosTrans = zonasEncargadosTrans[index];
                _zonasEncargadosTrans.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel zonasEncargadosTrans)
        {
            if ((zonasEncargadosTrans == null))
            {
                return false;
            }
            bool ret = zonasEncargadosTrans.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _zonasEncargadosTransDb = new OSIS.PEPPAM.BOM.Zonas_Encargados_Trans()
	            {
                Persona_Secuencia = this.Persona_Secuencia,
                Zona_Secuencia = this.Zona_Secuencia,

	            };

	            return _zonasEncargadosTransDb.Delete();

	        }

        public static bool Delete(int persona_Secuencia,int zona_Secuencia)
        {
            if ((persona_Secuencia == default(int)))
            {
                return false;
            }
            if ((zona_Secuencia == default(int)))
            {
                return false;
            }
             var _zonasEncargadosTransDb = OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel.Load(persona_Secuencia,zona_Secuencia);
            return _zonasEncargadosTransDb.Delete();
        }

        public string Trace()
	        {
             var _zonasEncargadosTransDb = new OSIS.PEPPAM.BOM.Zonas_Encargados_Trans()
	            {
                Persona_Secuencia = this.Persona_Secuencia,
                Zona_Secuencia = this.Zona_Secuencia,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _zonasEncargadosTransDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel zonasEncargadosTrans;
            System.Type[] types = new System.Type[] {
                    typeof(int),                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1,                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
                    int var1;            var1 = ((int)(v[1]));
            zonasEncargadosTrans = OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel.Load( var0, var1);
            return zonasEncargadosTrans;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel  zonasEncargadosTrans = new  OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel();
            this.CopyTo(zonasEncargadosTrans , deep);
            return zonasEncargadosTrans ;
        }

        public OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel localClone = this.Clone(true);
            return localClone;
        }

        public virtual void CopyFrom(System.Collections.IDictionary dict, bool deep)
        {
            if ((dict == null))
            {
                throw new System.ArgumentNullException("dict");
            }
            if ((dict.Contains("Persona_Secuencia") == true))
            {
                this.Persona_Secuencia = ((int)(ConvertUtilities.ChangeType(dict["Persona_Secuencia"], typeof(int), -1)));
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
            if ((dict.Contains("Zona_Secuencia") == true))
            {
                this.Zona_Secuencia = ((int)(ConvertUtilities.ChangeType(dict["Zona_Secuencia"], typeof(int), -1)));
            }
        }

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel  zonasEncargadosTrans, bool deep)
        {
            if ((zonasEncargadosTrans == null))
            {
                throw new System.ArgumentNullException("zonasEncargadosTrans");
            }
            zonasEncargadosTrans.Persona_Secuencia = this.Persona_Secuencia;
            zonasEncargadosTrans.Registro_Estado = this.Registro_Estado;
            zonasEncargadosTrans.Registro_Fecha = this.Registro_Fecha;
            zonasEncargadosTrans.Registro_Usuario = this.Registro_Usuario;
            zonasEncargadosTrans.Zona_Secuencia = this.Zona_Secuencia;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
	        }

	        var result =  pageLoadAll.Select(
                _zonasEncargadosTrans => 
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
	        {
                Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection ret = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
            }

            var result = ret.Select(
                _zonasEncargadosTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
                    {
                Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,

                    }).ToList();

            return result;
        }

        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> LoadByPersona(OSIS.PEPPAM.Mvc.Models.Personas_MasterModel persona)
        {

            var _Personas_Master = new OSIS.PEPPAM.BOM.Personas_Master()
            {
                Persona_Secuencia = persona.Persona_Secuencia,
                Congregacion_Secuencia = persona.Congregacion_Secuencia,
                Persona_Congregacion = persona.Persona_Congregacion,
                Persona_Tipo_Secuencia = persona.Persona_Tipo_Secuencia,
                Persona_Nombres = persona.Persona_Nombres,
                Persona_Apellidos = persona.Persona_Apellidos,
                Persona_Conyuge_Apellido = persona.Persona_Conyuge_Apellido,
                Persona_Sexo = persona.Persona_Sexo,
                Persona_Correo = persona.Persona_Correo,
                Persona_Clave = persona.Persona_Clave,
                Persona_Verificacion_Numero = persona.Persona_Verificacion_Numero,
                Persona_Estado_Secuencia = persona.Persona_Estado_Secuencia,
                Registro_Estado = persona.Registro_Estado,
                Registro_Fecha = persona.Registro_Fecha,
                Registro_Usuario = persona.Registro_Usuario,
            };


            OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection ret = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.LoadByPersona(_Personas_Master);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
            }

            var result = ret.Select(
                _zonasEncargadosTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
                    {
                        Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                        Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                        Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                        Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                        Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> PageLoadByPersona(int pageIndex, int pageSize, CodeFluent.Runtime.PageOptions pageOptions, OSIS.PEPPAM.Mvc.Models.Personas_MasterModel persona)
        {
            var _persona = new OSIS.PEPPAM.BOM.Personas_Master()
            {
                Persona_Secuencia = persona.Persona_Secuencia,
                Congregacion_Secuencia = persona.Congregacion_Secuencia,
                Persona_Congregacion = persona.Persona_Congregacion,
                Persona_Tipo_Secuencia = persona.Persona_Tipo_Secuencia,
                Persona_Nombres = persona.Persona_Nombres,
                Persona_Apellidos = persona.Persona_Apellidos,
                Persona_Conyuge_Apellido = persona.Persona_Conyuge_Apellido,
                Persona_Sexo = persona.Persona_Sexo,
                Persona_Correo = persona.Persona_Correo,
                Persona_Clave = persona.Persona_Clave,
                Persona_Verificacion_Numero = persona.Persona_Verificacion_Numero,
                Persona_Estado_Secuencia = persona.Persona_Estado_Secuencia,
                Registro_Estado = persona.Registro_Estado,
                Registro_Fecha = persona.Registro_Fecha,
                Registro_Usuario = persona.Registro_Usuario,
            };
            OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection ret = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.PageLoadByPersona(int.MinValue, int.MaxValue, null, _persona);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
            }

            var result = ret.Select(
                _zonasEncargadosTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
                    {
                        Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                        Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                        Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                        Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                        Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }


        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> PageLoadByPersona(int pageIndex, int pageSize,int persona_Secuencia)
        {
            OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection ret = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.PageLoadByPersona(int.MinValue, int.MaxValue,
persona_Secuencia);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
            }

            var result = ret.Select(
                _zonasEncargadosTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
                    {
                        Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                        Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                        Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                        Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                        Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }
        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> LoadByZona(OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zona)
        {

            var _Zonas_Master = new OSIS.PEPPAM.BOM.Zonas_Master()
            {
                Zona_Secuencia = zona.Zona_Secuencia,
                Zona_Descripcion = zona.Zona_Descripcion,
                Zona_Nota = zona.Zona_Nota,
                Registro_Estado = zona.Registro_Estado,
                Registro_Fecha = zona.Registro_Fecha,
                Registro_Usuario = zona.Registro_Usuario,
            };


            OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection ret = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.LoadByZona(_Zonas_Master);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
            }

            var result = ret.Select(
                _zonasEncargadosTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
                    {
                        Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                        Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                        Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                        Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                        Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> PageLoadByZona(int pageIndex, int pageSize, CodeFluent.Runtime.PageOptions pageOptions, OSIS.PEPPAM.Mvc.Models.Zonas_MasterModel zona)
        {
            var _zona = new OSIS.PEPPAM.BOM.Zonas_Master()
            {
                Zona_Secuencia = zona.Zona_Secuencia,
                Zona_Descripcion = zona.Zona_Descripcion,
                Zona_Nota = zona.Zona_Nota,
                Registro_Estado = zona.Registro_Estado,
                Registro_Fecha = zona.Registro_Fecha,
                Registro_Usuario = zona.Registro_Usuario,
            };
            OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection ret = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.PageLoadByZona(int.MinValue, int.MaxValue, null, _zona);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
            }

            var result = ret.Select(
                _zonasEncargadosTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
                    {
                        Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                        Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                        Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                        Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                        Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }


        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> PageLoadByZona(int pageIndex, int pageSize,int zona_Secuencia)
        {
            OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection ret = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.PageLoadByZona(int.MinValue, int.MaxValue,
zona_Secuencia);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
            }

            var result = ret.Select(
                _zonasEncargadosTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
                    {
                        Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                        Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                        Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                        Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                        Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }
	public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
	        }

	        var result =  pageLoadAll.Select(
                _zonasEncargadosTrans => 
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
	        {
                Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection ret = OSIS.PEPPAM.BOM.Zonas_Encargados_TransCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel>();
            }

            var result = ret.Select(
                _zonasEncargadosTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Zonas_Encargados_TransModel()
                    {
                Persona_Secuencia = _zonasEncargadosTrans.Persona_Secuencia,
                Zona_Secuencia = _zonasEncargadosTrans.Zona_Secuencia,
                Registro_Estado = _zonasEncargadosTrans.Registro_Estado,
                Registro_Fecha = _zonasEncargadosTrans.Registro_Fecha,
                Registro_Usuario = _zonasEncargadosTrans.Registro_Usuario,

                    }).ToList();

            return result;
        }

	} 
} 



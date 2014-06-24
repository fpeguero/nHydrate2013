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
	public partial class Sistema_Correos_Enviado_TransModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Sistema_Correos_Enviado_Trans","Correo_Enviado_Secuencia")]
		public int Correo_Enviado_Secuencia { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Sistema_Correos_Enviado_Trans","Correos_Secuencia")]
		public int Correos_Secuencia { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Sistema_Correos_Enviado_Trans","Correo_Enviado_Texto")]
		public String Correo_Enviado_Texto { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Sistema_Correos_Enviado_Trans","Correo_Enviado_Fecha")]
		public DateTime Correo_Enviado_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Sistema_Correos_Enviado_Trans","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Sistema_Correos_Enviado_Trans","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Sistema_Correos_Enviado_Trans","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        public OSIS.PEPPAM.Mvc.Models.Sistemas_Correos_CataModel _sistemas_Correos_Cata;
		/// <summary>
		/// The navigation definition for walking [Sistema_Correos_Enviado_Trans]->[Sistemas_Correos_Cata]
		/// Relationship Links: 
		/// [Sistemas_Correos_Cata.Correos_Secuencia = Sistema_Correos_Enviado_Trans.Correos_Secuencia] (Required)
		/// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
		public virtual OSIS.PEPPAM.Mvc.Models.Sistemas_Correos_CataModel SistemasCorreosCata
		{
			get
			{
                if ((this._sistemas_Correos_Cata == null))
                {
                    this._sistemas_Correos_Cata = OSIS.PEPPAM.Mvc.Models.Sistemas_Correos_CataModel.Load(Correos_Secuencia);
                }
                return this._sistemas_Correos_Cata;
			}
		}

     private List<OSIS.PEPPAM.Mvc.Models.Sistemas_Correos_CataModel> _sistemas_Correos_CataList;
		public virtual List<OSIS.PEPPAM.Mvc.Models.Sistemas_Correos_CataModel> SistemasCorreosCataList
		{
			get
			{
                if ((this._sistemas_Correos_CataList == null))
                {
                    this._sistemas_Correos_CataList = OSIS.PEPPAM.Mvc.Models.Sistemas_Correos_CataModel.LoadAll();
                }
                return this._sistemas_Correos_CataList;
			}
		}

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Correo_Enviado_Secuencia.ToString();
            }
            set
            {
               this.Correo_Enviado_Secuencia = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Correo_Enviado_Texto.ToString();
            }
        }
        

        public Sistema_Correos_Enviado_TransModel()
        {
            this.Correo_Enviado_Secuencia = -1;
            this.Correos_Secuencia = -1;
            this.Correo_Enviado_Texto = string.Empty;
            this.Correo_Enviado_Fecha = System.DateTime.MinValue;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Sistema_Correos_Enviado_TransPartial();
        }

            partial void Sistema_Correos_Enviado_TransPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel sistemaCorreosEnviadoTrans)
        {
            if ((sistemaCorreosEnviadoTrans == null))
            {
                return false;
            }

            if (
                    (this.Correo_Enviado_Secuencia == -1)
            )
            {
                return base.Equals(sistemaCorreosEnviadoTrans);
            }

 return ((
                    (this.Correo_Enviado_Secuencia.Equals(sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel sistemaCorreosEnviadoTrans = null;
			 sistemaCorreosEnviadoTrans = obj as OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel;
            return this.Equals( sistemaCorreosEnviadoTrans);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel sistemaCorreosEnviadoTrans)
        {
            if ((sistemaCorreosEnviadoTrans == null))
            {
                throw new System.ArgumentNullException("sistemaCorreosEnviadoTrans");
            }
            int localCompareTo = this.Correo_Enviado_Secuencia.CompareTo(sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel Load(int correo_Enviado_Secuencia)
        {
            var _sistemaCorreosEnviadoTransDb = OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_Trans.Load(correo_Enviado_Secuencia);
	        if (_sistemaCorreosEnviadoTransDb == null)
	        {
                return null;
	        }

	        var _sistemaCorreosEnviadoTrans = new OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel()
            {
                Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTransDb.Correo_Enviado_Secuencia,
                Correos_Secuencia = _sistemaCorreosEnviadoTransDb.Correos_Secuencia,
                Correo_Enviado_Texto = _sistemaCorreosEnviadoTransDb.Correo_Enviado_Texto,
                Correo_Enviado_Fecha = _sistemaCorreosEnviadoTransDb.Correo_Enviado_Fecha,
                Registro_Estado = _sistemaCorreosEnviadoTransDb.Registro_Estado,
                Registro_Fecha = _sistemaCorreosEnviadoTransDb.Registro_Fecha,
                Registro_Usuario = _sistemaCorreosEnviadoTransDb.Registro_Usuario,

            };

	        return _sistemaCorreosEnviadoTrans;
       }

     public virtual bool Save()
	        {
             var _sistemaCorreosEnviadoTransDb = new OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_Trans()
	            {
                Correo_Enviado_Secuencia = this.Correo_Enviado_Secuencia,
                Correos_Secuencia = this.Correos_Secuencia,
                Correo_Enviado_Texto = this.Correo_Enviado_Texto,
                Correo_Enviado_Fecha = this.Correo_Enviado_Fecha,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _sistemaCorreosEnviadoTransDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTransDb.Correo_Enviado_Secuencia;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel sistemaCorreosEnviadoTrans)
        {
            if ((sistemaCorreosEnviadoTrans == null))
            {
                return false;
            }
            bool ret = sistemaCorreosEnviadoTrans.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel sistemaCorreosEnviadoTrans)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel.Save(sistemaCorreosEnviadoTrans);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel> sistemaCorreosEnviadoTrans)
        {
            int index;
            for (index = (sistemaCorreosEnviadoTrans.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel _sistemaCorreosEnviadoTrans = sistemaCorreosEnviadoTrans[index];
                _sistemaCorreosEnviadoTrans.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel sistemaCorreosEnviadoTrans)
        {
            if ((sistemaCorreosEnviadoTrans == null))
            {
                return false;
            }
            bool ret = sistemaCorreosEnviadoTrans.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _sistemaCorreosEnviadoTransDb = new OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_Trans()
	            {
                Correo_Enviado_Secuencia = this.Correo_Enviado_Secuencia,

	            };

	            return _sistemaCorreosEnviadoTransDb.Delete();

	        }

        public static bool Delete(int correo_Enviado_Secuencia)
        {
            if ((correo_Enviado_Secuencia == default(int)))
            {
                return false;
            }
             var _sistemaCorreosEnviadoTransDb = OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel.Load(correo_Enviado_Secuencia);
            return _sistemaCorreosEnviadoTransDb.Delete();
        }

        public string Trace()
	        {
             var _sistemaCorreosEnviadoTransDb = new OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_Trans()
	            {
                Correo_Enviado_Secuencia = this.Correo_Enviado_Secuencia,
                Correos_Secuencia = this.Correos_Secuencia,
                Correo_Enviado_Texto = this.Correo_Enviado_Texto,
                Correo_Enviado_Fecha = this.Correo_Enviado_Fecha,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _sistemaCorreosEnviadoTransDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel sistemaCorreosEnviadoTrans;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            sistemaCorreosEnviadoTrans = OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel.Load( var0);
            return sistemaCorreosEnviadoTrans;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel  sistemaCorreosEnviadoTrans = new  OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel();
            this.CopyTo(sistemaCorreosEnviadoTrans , deep);
            return sistemaCorreosEnviadoTrans ;
        }

        public OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel localClone = this.Clone(true);
            return localClone;
        }

        public virtual void CopyFrom(System.Collections.IDictionary dict, bool deep)
        {
            if ((dict == null))
            {
                throw new System.ArgumentNullException("dict");
            }
            if ((dict.Contains("Correo_Enviado_Fecha") == true))
            {
                this.Correo_Enviado_Fecha = ((DateTime)(ConvertUtilities.ChangeType(dict["Correo_Enviado_Fecha"], typeof(DateTime), System.DateTime.MinValue)));
            }
            if ((dict.Contains("Correo_Enviado_Secuencia") == true))
            {
                this.Correo_Enviado_Secuencia = ((int)(ConvertUtilities.ChangeType(dict["Correo_Enviado_Secuencia"], typeof(int), -1)));
            }
            if ((dict.Contains("Correo_Enviado_Texto") == true))
            {
                this.Correo_Enviado_Texto = ((string)(ConvertUtilities.ChangeType(dict["Correo_Enviado_Texto"], typeof(string), string.Empty)));
            }
            if ((dict.Contains("Correos_Secuencia") == true))
            {
                this.Correos_Secuencia = ((int)(ConvertUtilities.ChangeType(dict["Correos_Secuencia"], typeof(int), -1)));
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

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel  sistemaCorreosEnviadoTrans, bool deep)
        {
            if ((sistemaCorreosEnviadoTrans == null))
            {
                throw new System.ArgumentNullException("sistemaCorreosEnviadoTrans");
            }
            sistemaCorreosEnviadoTrans.Correo_Enviado_Fecha = this.Correo_Enviado_Fecha;
            sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia = this.Correo_Enviado_Secuencia;
            sistemaCorreosEnviadoTrans.Correo_Enviado_Texto = this.Correo_Enviado_Texto;
            sistemaCorreosEnviadoTrans.Correos_Secuencia = this.Correos_Secuencia;
            sistemaCorreosEnviadoTrans.Registro_Estado = this.Registro_Estado;
            sistemaCorreosEnviadoTrans.Registro_Fecha = this.Registro_Fecha;
            sistemaCorreosEnviadoTrans.Registro_Usuario = this.Registro_Usuario;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel>();
	        }

	        var result =  pageLoadAll.Select(
                _sistemaCorreosEnviadoTrans => 
                    new OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel()
	        {
                Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia,
                Correos_Secuencia = _sistemaCorreosEnviadoTrans.Correos_Secuencia,
                Correo_Enviado_Texto = _sistemaCorreosEnviadoTrans.Correo_Enviado_Texto,
                Correo_Enviado_Fecha = _sistemaCorreosEnviadoTrans.Correo_Enviado_Fecha,
                Registro_Estado = _sistemaCorreosEnviadoTrans.Registro_Estado,
                Registro_Fecha = _sistemaCorreosEnviadoTrans.Registro_Fecha,
                Registro_Usuario = _sistemaCorreosEnviadoTrans.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection ret = OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel>();
            }

            var result = ret.Select(
                _sistemaCorreosEnviadoTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel()
                    {
                Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia,
                Correos_Secuencia = _sistemaCorreosEnviadoTrans.Correos_Secuencia,
                Correo_Enviado_Texto = _sistemaCorreosEnviadoTrans.Correo_Enviado_Texto,
                Correo_Enviado_Fecha = _sistemaCorreosEnviadoTrans.Correo_Enviado_Fecha,
                Registro_Estado = _sistemaCorreosEnviadoTrans.Registro_Estado,
                Registro_Fecha = _sistemaCorreosEnviadoTrans.Registro_Fecha,
                Registro_Usuario = _sistemaCorreosEnviadoTrans.Registro_Usuario,

                    }).ToList();

            return result;
        }

        public static List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel> LoadBySistemasCorreosCata(OSIS.PEPPAM.Mvc.Models.Sistemas_Correos_CataModel sistemas_Correos_Cata)
        {

            var _Sistemas_Correos_Cata = new OSIS.PEPPAM.BOM.Sistemas_Correos_Cata()
            {
                Correos_Secuencia = sistemas_Correos_Cata.Correos_Secuencia,
                Correo_Descripcion = sistemas_Correos_Cata.Correo_Descripcion,
                Correo_Explicacion = sistemas_Correos_Cata.Correo_Explicacion,
                Registro_Estado = sistemas_Correos_Cata.Registro_Estado,
                Registro_Fecha = sistemas_Correos_Cata.Registro_Fecha,
                Registro_Usuario = sistemas_Correos_Cata.Registro_Usuario,
            };


            OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection ret = OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection.LoadBySistemasCorreosCata(_Sistemas_Correos_Cata);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel>();
            }

            var result = ret.Select(
                _sistemaCorreosEnviadoTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel()
                    {
                        Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia,
                        Correos_Secuencia = _sistemaCorreosEnviadoTrans.Correos_Secuencia,
                        Correo_Enviado_Texto = _sistemaCorreosEnviadoTrans.Correo_Enviado_Texto,
                        Correo_Enviado_Fecha = _sistemaCorreosEnviadoTrans.Correo_Enviado_Fecha,
                        Registro_Estado = _sistemaCorreosEnviadoTrans.Registro_Estado,
                        Registro_Fecha = _sistemaCorreosEnviadoTrans.Registro_Fecha,
                        Registro_Usuario = _sistemaCorreosEnviadoTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel> PageLoadBySistemasCorreosCata(int pageIndex, int pageSize, CodeFluent.Runtime.PageOptions pageOptions, OSIS.PEPPAM.Mvc.Models.Sistemas_Correos_CataModel sistemas_Correos_Cata)
        {
            var _sistemas_Correos_Cata = new OSIS.PEPPAM.BOM.Sistemas_Correos_Cata()
            {
                Correos_Secuencia = sistemas_Correos_Cata.Correos_Secuencia,
                Correo_Descripcion = sistemas_Correos_Cata.Correo_Descripcion,
                Correo_Explicacion = sistemas_Correos_Cata.Correo_Explicacion,
                Registro_Estado = sistemas_Correos_Cata.Registro_Estado,
                Registro_Fecha = sistemas_Correos_Cata.Registro_Fecha,
                Registro_Usuario = sistemas_Correos_Cata.Registro_Usuario,
            };
            OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection ret = OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection.PageLoadBySistemasCorreosCata(int.MinValue, int.MaxValue, null, _sistemas_Correos_Cata);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel>();
            }

            var result = ret.Select(
                _sistemaCorreosEnviadoTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel()
                    {
                        Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia,
                        Correos_Secuencia = _sistemaCorreosEnviadoTrans.Correos_Secuencia,
                        Correo_Enviado_Texto = _sistemaCorreosEnviadoTrans.Correo_Enviado_Texto,
                        Correo_Enviado_Fecha = _sistemaCorreosEnviadoTrans.Correo_Enviado_Fecha,
                        Registro_Estado = _sistemaCorreosEnviadoTrans.Registro_Estado,
                        Registro_Fecha = _sistemaCorreosEnviadoTrans.Registro_Fecha,
                        Registro_Usuario = _sistemaCorreosEnviadoTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }


        public static List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel> PageLoadBySistemasCorreosCata(int pageIndex, int pageSize,int correos_Secuencia)
        {
            OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection ret = OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection.PageLoadBySistemasCorreosCata(int.MinValue, int.MaxValue,
correos_Secuencia);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel>();
            }

            var result = ret.Select(
                _sistemaCorreosEnviadoTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel()
                    {
                        Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia,
                        Correos_Secuencia = _sistemaCorreosEnviadoTrans.Correos_Secuencia,
                        Correo_Enviado_Texto = _sistemaCorreosEnviadoTrans.Correo_Enviado_Texto,
                        Correo_Enviado_Fecha = _sistemaCorreosEnviadoTrans.Correo_Enviado_Fecha,
                        Registro_Estado = _sistemaCorreosEnviadoTrans.Registro_Estado,
                        Registro_Fecha = _sistemaCorreosEnviadoTrans.Registro_Fecha,
                        Registro_Usuario = _sistemaCorreosEnviadoTrans.Registro_Usuario,
                    }).ToList();

            return result;
        }
	public static List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel>();
	        }

	        var result =  pageLoadAll.Select(
                _sistemaCorreosEnviadoTrans => 
                    new OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel()
	        {
                Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia,
                Correos_Secuencia = _sistemaCorreosEnviadoTrans.Correos_Secuencia,
                Correo_Enviado_Texto = _sistemaCorreosEnviadoTrans.Correo_Enviado_Texto,
                Correo_Enviado_Fecha = _sistemaCorreosEnviadoTrans.Correo_Enviado_Fecha,
                Registro_Estado = _sistemaCorreosEnviadoTrans.Registro_Estado,
                Registro_Fecha = _sistemaCorreosEnviadoTrans.Registro_Fecha,
                Registro_Usuario = _sistemaCorreosEnviadoTrans.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection ret = OSIS.PEPPAM.BOM.Sistema_Correos_Enviado_TransCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel>();
            }

            var result = ret.Select(
                _sistemaCorreosEnviadoTrans =>
                    new OSIS.PEPPAM.Mvc.Models.Sistema_Correos_Enviado_TransModel()
                    {
                Correo_Enviado_Secuencia = _sistemaCorreosEnviadoTrans.Correo_Enviado_Secuencia,
                Correos_Secuencia = _sistemaCorreosEnviadoTrans.Correos_Secuencia,
                Correo_Enviado_Texto = _sistemaCorreosEnviadoTrans.Correo_Enviado_Texto,
                Correo_Enviado_Fecha = _sistemaCorreosEnviadoTrans.Correo_Enviado_Fecha,
                Registro_Estado = _sistemaCorreosEnviadoTrans.Registro_Estado,
                Registro_Fecha = _sistemaCorreosEnviadoTrans.Registro_Fecha,
                Registro_Usuario = _sistemaCorreosEnviadoTrans.Registro_Usuario,

                    }).ToList();

            return result;
        }

	} 
} 


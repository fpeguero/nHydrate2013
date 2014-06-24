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
	public partial class Horario_Semanas_CataModel
	{

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Semanas_Cata","Semana_Codigo")]
		public int Semana_Codigo { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Semanas_Cata","Semana_Desde")]
		public DateTime Semana_Desde { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Semanas_Cata","Semana_Hasta")]
		public DateTime Semana_Hasta { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Semanas_Cata","Registro_Estado")]
		public String Registro_Estado { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Semanas_Cata","Registro_Fecha")]
		public DateTime Registro_Fecha { get; set; } 

		[OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Semanas_Cata","Registro_Usuario")]
		public String Registro_Usuario { get; set; } 

		#region Navigation Properties

        private List<OSIS.PEPPAM.Mvc.Models.Horario_TransModel> _horario_Trans;
		/// <summary>
		/// The back navigation definition for walking [Horario_Semanas_Cata]->[Horario_Trans]
		/// Relationship Links: 
		/// [Horario_Semanas_Cata.Semana_Codigo = Horario_Trans.Semana_Codigo] (Required)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual List<OSIS.PEPPAM.Mvc.Models.Horario_TransModel> HorarioTrans
        {
            get
            {
                if ((this._horario_Trans == null))
                {
                    this._horario_Trans = OSIS.PEPPAM.Mvc.Models.Horario_TransModel.LoadByHorarioSemanasCata(this);
                }
                return this._horario_Trans;
            }
        }

		#endregion

        public virtual string EntityKey
        {
            get
            {
                return this.Semana_Codigo.ToString();
            }
            set
            {
               this.Semana_Codigo = ((int)(ConvertUtilities.ChangeType(value, typeof(int), -1)));
            }
        }

        public virtual string EntityDisplayName
        {
            get
            {
                return this.Registro_Estado.ToString();
            }
        }
        

        public Horario_Semanas_CataModel()
        {
            this.Semana_Codigo = -1;
            this.Semana_Desde = System.DateTime.MinValue;
            this.Semana_Hasta = System.DateTime.MinValue;
            this.Registro_Estado = "A";
            this.Registro_Fecha = DateTime.Now;
            this.Registro_Usuario = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "";
            Horario_Semanas_CataPartial();
        }

            partial void Horario_Semanas_CataPartial();

        public virtual bool Equals(OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel horarioSemanasCata)
        {
            if ((horarioSemanasCata == null))
            {
                return false;
            }

            if (
                    (this.Semana_Codigo == -1)
            )
            {
                return base.Equals(horarioSemanasCata);
            }

 return ((
                    (this.Semana_Codigo.Equals(horarioSemanasCata.Semana_Codigo))
                        )== true);
        }

        public override bool Equals(object obj)
        {
            OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel horarioSemanasCata = null;
			 horarioSemanasCata = obj as OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel;
            return this.Equals( horarioSemanasCata);
        }

        public override int GetHashCode()
        {
            if ((this.EntityKey == null))
            {
                return base.GetHashCode();
            }
            return this.EntityKey.GetHashCode();
        }
        
        public virtual int CompareTo(OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel horarioSemanasCata)
        {
            if ((horarioSemanasCata == null))
            {
                throw new System.ArgumentNullException("horarioSemanasCata");
            }
            int localCompareTo = this.Semana_Codigo.CompareTo(horarioSemanasCata.Semana_Codigo);
            return localCompareTo;
        }

        public static OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel Load(int semana_Codigo)
        {
            var _horarioSemanasCataDb = OSIS.PEPPAM.BOM.Horario_Semanas_Cata.Load(semana_Codigo);
	        if (_horarioSemanasCataDb == null)
	        {
                return null;
	        }

	        var _horarioSemanasCata = new OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel()
            {
                Semana_Codigo = _horarioSemanasCataDb.Semana_Codigo,
                Semana_Desde = _horarioSemanasCataDb.Semana_Desde,
                Semana_Hasta = _horarioSemanasCataDb.Semana_Hasta,
                Registro_Estado = _horarioSemanasCataDb.Registro_Estado,
                Registro_Fecha = _horarioSemanasCataDb.Registro_Fecha,
                Registro_Usuario = _horarioSemanasCataDb.Registro_Usuario,

            };

	        return _horarioSemanasCata;
       }

     public virtual bool Save()
	        {
             var _horarioSemanasCataDb = new OSIS.PEPPAM.BOM.Horario_Semanas_Cata()
	            {
                Semana_Codigo = this.Semana_Codigo,
                Semana_Desde = this.Semana_Desde,
                Semana_Hasta = this.Semana_Hasta,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            var result  = _horarioSemanasCataDb.Save();
             //TODO: Puede ser que solo sean los Identity y no todo los primary keys
             this.Semana_Codigo = _horarioSemanasCataDb.Semana_Codigo;

             return result;

	        }

        public static bool Save(OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel horarioSemanasCata)
        {
            if ((horarioSemanasCata == null))
            {
                return false;
            }
            bool ret = horarioSemanasCata.Save();
            return ret;
        }

        public static bool Insert(OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel horarioSemanasCata)
        {
            bool ret = OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel.Save(horarioSemanasCata);
            return ret;
        }

        public static void SaveAll(List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel> horarioSemanasCata)
        {
            int index;
            for (index = (horarioSemanasCata.Count - 1); (index >= 0); index = (index - 1))
            {
                OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel _horarioSemanasCata = horarioSemanasCata[index];
                _horarioSemanasCata.Save();
            }
        }

        public static bool Delete(OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel horarioSemanasCata)
        {
            if ((horarioSemanasCata == null))
            {
                return false;
            }
            bool ret = horarioSemanasCata.Delete();
            return ret;
        }

         public virtual bool Delete()
	        {
             var _horarioSemanasCataDb = new OSIS.PEPPAM.BOM.Horario_Semanas_Cata()
	            {
                Semana_Codigo = this.Semana_Codigo,

	            };

	            return _horarioSemanasCataDb.Delete();

	        }

        public static bool Delete(int semana_Codigo)
        {
            if ((semana_Codigo == default(int)))
            {
                return false;
            }
             var _horarioSemanasCataDb = OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel.Load(semana_Codigo);
            return _horarioSemanasCataDb.Delete();
        }

        public string Trace()
	        {
             var _horarioSemanasCataDb = new OSIS.PEPPAM.BOM.Horario_Semanas_Cata()
	            {
                Semana_Codigo = this.Semana_Codigo,
                Semana_Desde = this.Semana_Desde,
                Semana_Hasta = this.Semana_Hasta,
                Registro_Estado = this.Registro_Estado,
                Registro_Fecha = this.Registro_Fecha,
                Registro_Usuario = this.Registro_Usuario
	            };

	            return _horarioSemanasCataDb.Trace();

	        }

        public static OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel LoadByEntityKey(string key)
        {
            if ((key == string.Empty))
            {
                return null;
            }
            OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel horarioSemanasCata;
            System.Type[] types = new System.Type[] {
                    typeof(int)                    };
            object[] defaultValues = new object[] {
                    -1                    };
            object[] v = CodeFluentPersistence.ParseEntityKey(key, types, defaultValues);
                    int var0;            var0 = ((int)(v[0]));
            horarioSemanasCata = OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel.Load( var0);
            return horarioSemanasCata;
        }


// Metodos Definidos en el Modelo y las propiedades CollectionKey
        public  OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel Clone(bool deep)
        {
             OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel  horarioSemanasCata = new  OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel();
            this.CopyTo(horarioSemanasCata , deep);
            return horarioSemanasCata ;
        }

        public OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel Clone()
        {
            OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel localClone = this.Clone(true);
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
            if ((dict.Contains("Semana_Codigo") == true))
            {
                this.Semana_Codigo = ((int)(ConvertUtilities.ChangeType(dict["Semana_Codigo"], typeof(int), -1)));
            }
            if ((dict.Contains("Semana_Desde") == true))
            {
                this.Semana_Desde = ((DateTime)(ConvertUtilities.ChangeType(dict["Semana_Desde"], typeof(DateTime), System.DateTime.MinValue)));
            }
            if ((dict.Contains("Semana_Hasta") == true))
            {
                this.Semana_Hasta = ((DateTime)(ConvertUtilities.ChangeType(dict["Semana_Hasta"], typeof(DateTime), System.DateTime.MinValue)));
            }
        }

        public virtual void CopyTo( OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel  horarioSemanasCata, bool deep)
        {
            if ((horarioSemanasCata == null))
            {
                throw new System.ArgumentNullException("horarioSemanasCata");
            }
            horarioSemanasCata.Registro_Estado = this.Registro_Estado;
            horarioSemanasCata.Registro_Fecha = this.Registro_Fecha;
            horarioSemanasCata.Registro_Usuario = this.Registro_Usuario;
            horarioSemanasCata.Semana_Codigo = this.Semana_Codigo;
            horarioSemanasCata.Semana_Desde = this.Semana_Desde;
            horarioSemanasCata.Semana_Hasta = this.Semana_Hasta;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel> PageLoadAll(int pageIndex, int pageSize,
	        CodeFluent.Runtime.PageOptions pageOptions)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Horario_Semanas_CataCollection.PageLoadAll(pageIndex, pageSize, pageOptions);

	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _horarioSemanasCata => 
                    new OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel()
	        {
                Semana_Codigo = _horarioSemanasCata.Semana_Codigo,
                Semana_Desde = _horarioSemanasCata.Semana_Desde,
                Semana_Hasta = _horarioSemanasCata.Semana_Hasta,
                Registro_Estado = _horarioSemanasCata.Registro_Estado,
                Registro_Fecha = _horarioSemanasCata.Registro_Fecha,
                Registro_Usuario = _horarioSemanasCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel> LoadAll()
        {
            OSIS.PEPPAM.BOM.Horario_Semanas_CataCollection ret = OSIS.PEPPAM.BOM.Horario_Semanas_CataCollection.PageLoadAll(int.MinValue, int.MaxValue, null);

            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel>();
            }

            var result = ret.Select(
                _horarioSemanasCata =>
                    new OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel()
                    {
                Semana_Codigo = _horarioSemanasCata.Semana_Codigo,
                Semana_Desde = _horarioSemanasCata.Semana_Desde,
                Semana_Hasta = _horarioSemanasCata.Semana_Hasta,
                Registro_Estado = _horarioSemanasCata.Registro_Estado,
                Registro_Fecha = _horarioSemanasCata.Registro_Fecha,
                Registro_Usuario = _horarioSemanasCata.Registro_Usuario,

                    }).ToList();

            return result;
        }

	public static List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel> PageLoadAllPaging(int pageIndex, int pageSize, string searchString,
	        CodeFluent.Runtime.PageOptions pageOptions, out int totalCount)
	    {
	        var pageLoadAll = OSIS.PEPPAM.BOM.Horario_Semanas_CataCollection.PageLoadAllPaging(pageIndex, pageSize, searchString, pageOptions);

	        totalCount = pageLoadAll.TotalRowCount;
	        if (pageLoadAll == null)
	        {
                return new List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel>();
	        }

	        var result =  pageLoadAll.Select(
                _horarioSemanasCata => 
                    new OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel()
	        {
                Semana_Codigo = _horarioSemanasCata.Semana_Codigo,
                Semana_Desde = _horarioSemanasCata.Semana_Desde,
                Semana_Hasta = _horarioSemanasCata.Semana_Hasta,
                Registro_Estado = _horarioSemanasCata.Registro_Estado,
                Registro_Fecha = _horarioSemanasCata.Registro_Fecha,
                Registro_Usuario = _horarioSemanasCata.Registro_Usuario,

	        }).ToList();

	        return result;
	    }

        public static List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel> LoadAllPaging(string searchString, out int totalCount)
        {
            OSIS.PEPPAM.BOM.Horario_Semanas_CataCollection ret = OSIS.PEPPAM.BOM.Horario_Semanas_CataCollection.PageLoadAllPaging(1, 1000000,searchString, null);

	            totalCount = ret.TotalRowCount;
            if (ret == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel>();
            }

            var result = ret.Select(
                _horarioSemanasCata =>
                    new OSIS.PEPPAM.Mvc.Models.Horario_Semanas_CataModel()
                    {
                Semana_Codigo = _horarioSemanasCata.Semana_Codigo,
                Semana_Desde = _horarioSemanasCata.Semana_Desde,
                Semana_Hasta = _horarioSemanasCata.Semana_Hasta,
                Registro_Estado = _horarioSemanasCata.Registro_Estado,
                Registro_Fecha = _horarioSemanasCata.Registro_Fecha,
                Registro_Usuario = _horarioSemanasCata.Registro_Usuario,

                    }).ToList();

            return result;
        }


public static List<OSIS.PEPPAM.Mvc.Models.Proc_Semanas_Abrir_HorariosModel> DisponiblesAbrirHorarios()
        {
            var _disponibles_Abrir_Horarios = OSIS.PEPPAM.BOM.Horario_Semanas_Cata.DisponiblesAbrirHorarios(
);



            if ((_disponibles_Abrir_Horarios == null))
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Proc_Semanas_Abrir_HorariosModel>();
            }

            var result = _disponibles_Abrir_Horarios.Select(
                x =>
                    new OSIS.PEPPAM.Mvc.Models.Proc_Semanas_Abrir_HorariosModel()
                    {
                Registro_Estado = x.Registro_Estado,
                Registro_Fecha = x.Registro_Fecha.Value,
                Registro_Usuario = x.Registro_Usuario,
                Semana_Codigo = x.Semana_Codigo.Value,
                Semana_Desde = x.Semana_Desde.Value,
                Semana_Hasta = x.Semana_Hasta.Value                    }).ToList();

            return result;
        }
	} 
} 



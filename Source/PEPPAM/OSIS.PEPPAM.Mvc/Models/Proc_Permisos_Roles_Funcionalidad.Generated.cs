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
  using System.Collections.Generic;
  using System.Linq;
 using System.Runtime.Serialization;
 using CodeFluent.Runtime;
 using CodeFluent.Runtime.Utilities;
namespace OSIS.PEPPAM.Mvc.Models
{
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DataObjectAttribute()]
    public partial class Proc_Permisos_Roles_FuncionalidadBase
    {


        
        public Proc_Permisos_Roles_FuncionalidadBase()
        {
        }

		#region Primitive Properties

		/// <summary>
		/// 
		/// </summary>
		public virtual int? Funcionalidad_Numero
		{
			get { return _funcionalidad_Numero; }
			set
			{
				_funcionalidad_Numero = value;
			}
		}
		protected int? _funcionalidad_Numero = -1;

		#endregion

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
        

public static OSIS.PEPPAM.Mvc.Models.Proc_Permisos_Roles_FuncionalidadModel LoadOne(int? moduloNumero,int? roleNumero)
        {
            var _loadOne = OSIS.PEPPAM.BOM.Proc_Permisos_Roles_Funcionalidad.LoadOne(
moduloNumero,roleNumero);
            if ((_loadOne == null))
            {
                return new OSIS.PEPPAM.Mvc.Models.Proc_Permisos_Roles_FuncionalidadModel();
            }


	        var _procPermisosRolesFuncionalidad = new OSIS.PEPPAM.Mvc.Models.Proc_Permisos_Roles_FuncionalidadModel()
            {
                Funcionalidad_Numero = _loadOne.Funcionalidad_Numero
            };
            return _procPermisosRolesFuncionalidad;
            }


public static List<OSIS.PEPPAM.Mvc.Models.Proc_Permisos_Roles_FuncionalidadModel> Load(int? moduloNumero,int? roleNumero)
        {
            var _load = OSIS.PEPPAM.BOM.Proc_Permisos_Roles_Funcionalidad.Load(
moduloNumero,roleNumero);



            if ((_load == null))
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Proc_Permisos_Roles_FuncionalidadModel>();
            }

            var result = _load.Select(
                x =>
                    new OSIS.PEPPAM.Mvc.Models.Proc_Permisos_Roles_FuncionalidadModel()
                    {
                Funcionalidad_Numero = x.Funcionalidad_Numero.Value                    }).ToList();

            return result;
        }

    }
}

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
    public partial class Proc_Semanas_Abrir_HorariosBase
    {


        
        public Proc_Semanas_Abrir_HorariosBase()
        {
        }

		#region Primitive Properties

		/// <summary>
		/// 
		/// </summary>
		public virtual string Registro_Estado
		{
			get { return _registro_Estado; }
			set
			{
				_registro_Estado = value;
			}
		}
		protected string _registro_Estado = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Registro_Fecha
		{
			get { return _registro_Fecha; }
			set
			{
				_registro_Fecha = value;
			}
		}
		protected DateTime? _registro_Fecha = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Registro_Usuario
		{
			get { return _registro_Usuario; }
			set
			{
				_registro_Usuario = value;
			}
		}
		protected string _registro_Usuario = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual int? Semana_Codigo
		{
			get { return _semana_Codigo; }
			set
			{
				_semana_Codigo = value;
			}
		}
		protected int? _semana_Codigo = -1;

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Semana_Desde
		{
			get { return _semana_Desde; }
			set
			{
				_semana_Desde = value;
			}
		}
		protected DateTime? _semana_Desde = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Semana_Hasta
		{
			get { return _semana_Hasta; }
			set
			{
				_semana_Hasta = value;
			}
		}
		protected DateTime? _semana_Hasta = System.DateTime.MinValue;

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
        

public static OSIS.PEPPAM.Mvc.Models.Proc_Semanas_Abrir_HorariosModel LoadOne()
        {
            var _loadOne = OSIS.PEPPAM.BOM.Proc_Semanas_Abrir_Horarios.LoadOne(
);
            if ((_loadOne == null))
            {
                return new OSIS.PEPPAM.Mvc.Models.Proc_Semanas_Abrir_HorariosModel();
            }


	        var _procSemanasAbrirHorarios = new OSIS.PEPPAM.Mvc.Models.Proc_Semanas_Abrir_HorariosModel()
            {
                Registro_Estado = _loadOne.Registro_Estado,
                Registro_Fecha = _loadOne.Registro_Fecha,
                Registro_Usuario = _loadOne.Registro_Usuario,
                Semana_Codigo = _loadOne.Semana_Codigo,
                Semana_Desde = _loadOne.Semana_Desde,
                Semana_Hasta = _loadOne.Semana_Hasta
            };
            return _procSemanasAbrirHorarios;
            }


public static List<OSIS.PEPPAM.Mvc.Models.Proc_Semanas_Abrir_HorariosModel> Load()
        {
            var _load = OSIS.PEPPAM.BOM.Proc_Semanas_Abrir_Horarios.Load(
);



            if ((_load == null))
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Proc_Semanas_Abrir_HorariosModel>();
            }

            var result = _load.Select(
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

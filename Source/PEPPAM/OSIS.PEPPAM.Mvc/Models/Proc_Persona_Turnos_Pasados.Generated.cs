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
    public partial class Proc_Persona_Turnos_PasadosBase
    {


        
        public Proc_Persona_Turnos_PasadosBase()
        {
        }

		#region Primitive Properties

		/// <summary>
		/// 
		/// </summary>
		public virtual string Dia_Descripcion
		{
			get { return _dia_Descripcion; }
			set
			{
				_dia_Descripcion = value;
			}
		}
		protected string _dia_Descripcion = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual int? Dia_Secuencia
		{
			get { return _dia_Secuencia; }
			set
			{
				_dia_Secuencia = value;
			}
		}
		protected int? _dia_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Horario_Fecha_Desde
		{
			get { return _horario_Fecha_Desde; }
			set
			{
				_horario_Fecha_Desde = value;
			}
		}
		protected DateTime? _horario_Fecha_Desde = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Horario_Fecha_Hasta
		{
			get { return _horario_Fecha_Hasta; }
			set
			{
				_horario_Fecha_Hasta = value;
			}
		}
		protected DateTime? _horario_Fecha_Hasta = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
		public virtual int? Horario_Secuencia
		{
			get { return _horario_Secuencia; }
			set
			{
				_horario_Secuencia = value;
			}
		}
		protected int? _horario_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
		public virtual int? Horario_Turno_Secuencia
		{
			get { return _horario_Turno_Secuencia; }
			set
			{
				_horario_Turno_Secuencia = value;
			}
		}
		protected int? _horario_Turno_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Persona_Apellidos
		{
			get { return _persona_Apellidos; }
			set
			{
				_persona_Apellidos = value;
			}
		}
		protected string _persona_Apellidos = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Persona_Nombres
		{
			get { return _persona_Nombres; }
			set
			{
				_persona_Nombres = value;
			}
		}
		protected string _persona_Nombres = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual int? Persona_Secuencia
		{
			get { return _persona_Secuencia; }
			set
			{
				_persona_Secuencia = value;
			}
		}
		protected int? _persona_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Ruta_Descripcion
		{
			get { return _ruta_Descripcion; }
			set
			{
				_ruta_Descripcion = value;
			}
		}
		protected string _ruta_Descripcion = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual int? Ruta_Secuencia
		{
			get { return _ruta_Secuencia; }
			set
			{
				_ruta_Secuencia = value;
			}
		}
		protected int? _ruta_Secuencia = -1;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Turno_Descripcion
		{
			get { return _turno_Descripcion; }
			set
			{
				_turno_Descripcion = value;
			}
		}
		protected string _turno_Descripcion = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Turno_Fecha
		{
			get { return _turno_Fecha; }
			set
			{
				_turno_Fecha = value;
			}
		}
		protected DateTime? _turno_Fecha = System.DateTime.MinValue;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Turno_Hora_Desde
		{
			get { return _turno_Hora_Desde; }
			set
			{
				_turno_Hora_Desde = value;
			}
		}
		protected string _turno_Hora_Desde = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Turno_Hora_Hasta
		{
			get { return _turno_Hora_Hasta; }
			set
			{
				_turno_Hora_Hasta = value;
			}
		}
		protected string _turno_Hora_Hasta = string.Empty;

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
        

public static OSIS.PEPPAM.Mvc.Models.Proc_Persona_Turnos_PasadosModel LoadOne(int? personaSecuencia)
        {
            var _loadOne = OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Pasados.LoadOne(
personaSecuencia);
            if ((_loadOne == null))
            {
                return new OSIS.PEPPAM.Mvc.Models.Proc_Persona_Turnos_PasadosModel();
            }


	        var _procPersonaTurnosPasados = new OSIS.PEPPAM.Mvc.Models.Proc_Persona_Turnos_PasadosModel()
            {
                Dia_Descripcion = _loadOne.Dia_Descripcion,
                Dia_Secuencia = _loadOne.Dia_Secuencia,
                Horario_Fecha_Desde = _loadOne.Horario_Fecha_Desde,
                Horario_Fecha_Hasta = _loadOne.Horario_Fecha_Hasta,
                Horario_Secuencia = _loadOne.Horario_Secuencia,
                Horario_Turno_Secuencia = _loadOne.Horario_Turno_Secuencia,
                Persona_Apellidos = _loadOne.Persona_Apellidos,
                Persona_Nombres = _loadOne.Persona_Nombres,
                Persona_Secuencia = _loadOne.Persona_Secuencia,
                Ruta_Descripcion = _loadOne.Ruta_Descripcion,
                Ruta_Secuencia = _loadOne.Ruta_Secuencia,
                Turno_Descripcion = _loadOne.Turno_Descripcion,
                Turno_Fecha = _loadOne.Turno_Fecha,
                Turno_Hora_Desde = _loadOne.Turno_Hora_Desde,
                Turno_Hora_Hasta = _loadOne.Turno_Hora_Hasta
            };
            return _procPersonaTurnosPasados;
            }


public static List<OSIS.PEPPAM.Mvc.Models.Proc_Persona_Turnos_PasadosModel> Load(int? personaSecuencia)
        {
            var _load = OSIS.PEPPAM.BOM.Proc_Persona_Turnos_Pasados.Load(
personaSecuencia);



            if ((_load == null))
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Proc_Persona_Turnos_PasadosModel>();
            }

            var result = _load.Select(
                x =>
                    new OSIS.PEPPAM.Mvc.Models.Proc_Persona_Turnos_PasadosModel()
                    {
                Dia_Descripcion = x.Dia_Descripcion,
                Dia_Secuencia = x.Dia_Secuencia.Value,
                Horario_Fecha_Desde = x.Horario_Fecha_Desde.Value,
                Horario_Fecha_Hasta = x.Horario_Fecha_Hasta.Value,
                Horario_Secuencia = x.Horario_Secuencia.Value,
                Horario_Turno_Secuencia = x.Horario_Turno_Secuencia.Value,
                Persona_Apellidos = x.Persona_Apellidos,
                Persona_Nombres = x.Persona_Nombres,
                Persona_Secuencia = x.Persona_Secuencia.Value,
                Ruta_Descripcion = x.Ruta_Descripcion,
                Ruta_Secuencia = x.Ruta_Secuencia.Value,
                Turno_Descripcion = x.Turno_Descripcion,
                Turno_Fecha = x.Turno_Fecha.Value,
                Turno_Hora_Desde = x.Turno_Hora_Desde,
                Turno_Hora_Hasta = x.Turno_Hora_Hasta                    }).ToList();

            return result;
        }

    }
}

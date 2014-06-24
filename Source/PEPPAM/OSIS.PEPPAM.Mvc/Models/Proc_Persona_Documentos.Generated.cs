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
    public partial class Proc_Persona_DocumentosBase
    {


        
        public Proc_Persona_DocumentosBase()
        {
        }

		#region Primitive Properties

		/// <summary>
		/// 
		/// </summary>
		public virtual string Documento_Archivo_Nombre
		{
			get { return _documento_Archivo_Nombre; }
			set
			{
				_documento_Archivo_Nombre = value;
			}
		}
		protected string _documento_Archivo_Nombre = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Documento_Descripcion
		{
			get { return _documento_Descripcion; }
			set
			{
				_documento_Descripcion = value;
			}
		}
		protected string _documento_Descripcion = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual string Documento_Nombre
		{
			get { return _documento_Nombre; }
			set
			{
				_documento_Nombre = value;
			}
		}
		protected string _documento_Nombre = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public virtual int? Documento_Secuencia
		{
			get { return _documento_Secuencia; }
			set
			{
				_documento_Secuencia = value;
			}
		}
		protected int? _documento_Secuencia = -1;

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
        

public static OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel LoadOne(int? usuarioNumero)
        {
            var _loadOne = OSIS.PEPPAM.BOM.Proc_Persona_Documentos.LoadOne(
usuarioNumero);
            if ((_loadOne == null))
            {
                return new OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel();
            }


	        var _procPersonaDocumentos = new OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel()
            {
                Documento_Archivo_Nombre = _loadOne.Documento_Archivo_Nombre,
                Documento_Descripcion = _loadOne.Documento_Descripcion,
                Documento_Nombre = _loadOne.Documento_Nombre,
                Documento_Secuencia = _loadOne.Documento_Secuencia,
                Registro_Estado = _loadOne.Registro_Estado,
                Registro_Fecha = _loadOne.Registro_Fecha,
                Registro_Usuario = _loadOne.Registro_Usuario
            };
            return _procPersonaDocumentos;
            }


public static List<OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel> Load(int? usuarioNumero)
        {
            var _load = OSIS.PEPPAM.BOM.Proc_Persona_Documentos.Load(
usuarioNumero);



            if ((_load == null))
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel>();
            }

            var result = _load.Select(
                x =>
                    new OSIS.PEPPAM.Mvc.Models.Proc_Persona_DocumentosModel()
                    {
                Documento_Archivo_Nombre = x.Documento_Archivo_Nombre,
                Documento_Descripcion = x.Documento_Descripcion,
                Documento_Nombre = x.Documento_Nombre,
                Documento_Secuencia = x.Documento_Secuencia.Value,
                Registro_Estado = x.Registro_Estado,
                Registro_Fecha = x.Registro_Fecha.Value,
                Registro_Usuario = x.Registro_Usuario                    }).ToList();

            return result;
        }

    }
}


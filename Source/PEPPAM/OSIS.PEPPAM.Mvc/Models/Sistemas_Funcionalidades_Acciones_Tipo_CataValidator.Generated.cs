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
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Validators;
using OSIS.PEPPAM.Mvc.Models; 
using OSIS.PEPPAM.Mvc.UI; 

namespace OSIS.PEPPAM.Mvc.Models 
{

	public partial class Sistemas_Funcionalidades_Acciones_Tipo_CataValidator : AbstractValidator<Sistemas_Funcionalidades_Acciones_Tipo_CataModel>
	{
	public void Validators()
	{
		//Required,
		RuleFor(x => x.Funcionalidad_Accion_Tipo_Descripcion).NotNull().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NOTNULL"));
		//Length,
		RuleFor(x => x.Funcionalidad_Accion_Tipo_Descripcion).Length(0,50).WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_LENGTH"));
		//Required,
		RuleFor(x => x.Funcionalidad_Accion_Tipo_Explicacion).NotNull().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NOTNULL"));
		//Length,
		RuleFor(x => x.Funcionalidad_Accion_Tipo_Explicacion).Length(0,500).WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_LENGTH"));
		//Required,
		RuleFor(x => x.Registro_Estado).NotNull().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NOTNULL"));
		//Length,
		RuleFor(x => x.Registro_Estado).Length(0,1).WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_LENGTH"));
	}

        
	}
} 


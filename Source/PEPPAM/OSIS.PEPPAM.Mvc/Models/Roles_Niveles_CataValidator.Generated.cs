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

	public partial class Roles_Niveles_CataValidator : AbstractValidator<Roles_Niveles_CataModel>
	{
	public void Validators()
	{
		//Required,
		RuleFor(x => x.Role_Nivel).NotNull().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NOTNULL"));
		//Numeric,
		RuleFor(x => x.Role_Nivel).Numeric().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NUMERIC"));
		//Required,
		RuleFor(x => x.Role_Nivel_Nombre).NotNull().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NOTNULL"));
		//Length,
		RuleFor(x => x.Role_Nivel_Nombre).Length(0,50).WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_LENGTH"));
		//Required,
		RuleFor(x => x.Role_Nivel_Descripcion).NotNull().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NOTNULL"));
		//Length,
		RuleFor(x => x.Role_Nivel_Descripcion).Length(0,500).WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_LENGTH"));
		//Required,
		RuleFor(x => x.Registro_Estado).NotNull().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NOTNULL"));
		//Length,
		RuleFor(x => x.Registro_Estado).Length(0,1).WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_LENGTH"));
	}

        
	}
} 

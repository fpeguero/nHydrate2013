//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Creador : Administrator
//    Dominio : OSISPC
//    Pc      : OSISPC
//    Fecha   : 5/17/2014 6:34:23 AM
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

namespace OSIS.PEPPAM.Mvc.Models 
{ 
[Validator(typeof(Documentos_MasterValidator))]
	public partial class Documentos_MasterModel 
	{ 
		// Add your custom members here 
	} 
	public partial class Documentos_MasterValidator 
	{ 

 public Documentos_MasterValidator()
{

   Validators();

}

		// Add your custom members here 
	} 
} 



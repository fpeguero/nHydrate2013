//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Creador : f.peguero
//    Dominio : SSRL
//    Pc      : DTI_GTE_GIS
//    Fecha   : 29/05/2014 11:22:56 a.m.
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
[Validator(typeof(Horario_Semanas_CataValidator))]
	public partial class Horario_Semanas_CataModel 
	{ 
		// Add your custom members here


    public string EntityDisplayName2
    {
        get
        {
            return "(" + this.Semana_Codigo + ") " + this.Semana_Desde.ToString("D") + " - " + this.Semana_Hasta.ToString("D");
        }
    }

	} 
	public partial class Horario_Semanas_CataValidator 
	{ 

 public Horario_Semanas_CataValidator()
{

   Validators();

}

		// Add your custom members here 
	} 
} 


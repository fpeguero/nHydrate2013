//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Creador : Administrator
//    Dominio : OSISPC
//    Pc      : OSISPC
//    Fecha   : 5/4/2014 6:24:26 PM
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
[Validator(typeof(Personas_Turnos_TransValidator))]
	public partial class Personas_Turnos_TransModel 
	{ 
		// Add your custom members here 

        public int Ruta_Secuencia { get; set; }

        public int Horario_Secuencia { get; set; }

    public string Turnos_Dias_Key { get; set; }

    //public string 

	} 
	public partial class Personas_Turnos_TransValidator 
	{ 

 public Personas_Turnos_TransValidator()
{

   Validators();

}

		// Add your custom members here 
	} 
} 


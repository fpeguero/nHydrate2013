//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Creador : Administrator
//    Dominio : OSISPC
//    Pc      : OSISPC
//    Fecha   : 5/4/2014 3:34:24 PM
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Validators;
using OSIS.PEPPAM.Mvc.Models;
using OSIS.PEPPAM.Mvc.UI;

namespace OSIS.PEPPAM.Mvc.Models
{
    [Validator(typeof(Horario_Turno_TransValidator))]
    public partial class Horario_Turno_TransModel
    {
        // Add your custom members here 

        partial void Horario_Turno_TransPartial()
        {
            DiasSelect = new List<string>();
        }

        public List<Dias_CataModel> DiasList
        {
            get { return Dias_CataModel.LoadAll(); }
        }

        public List<string> DiasSelect { get; set; }


        [OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Turno_Trans", "Turno_Dia_Razon_Cancelacion")]
        public String Turno_Dia_Razon_Cancelacion { get; set; } 

    }
    public partial class Horario_Turno_TransValidator
    {

        public Horario_Turno_TransValidator()
        {
            
            RuleFor(x => x.DiasSelect)
             .Must(x => x.Count() > 0)
             .WithMessage("Debe seleccionar el o los d�as correspondiente a este turno");

            RuleFor(x => x.Turno_Cantidad_Publicadores)
                .GreaterThan(0)
                .WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_CANTIDAD_PUBLICADORES"));


            RuleFor(x => x.Turno_Dia_Razon_Cancelacion).NotNull().WithMessage(Messages.GetOrSetMensaje("MENSAJE_ERROR_NOTNULL"));

            Validators();

        }

        // Add your custom members here 
    }
}


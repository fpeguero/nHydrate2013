//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Creador : Administrator
//    Dominio : OSISPC
//    Pc      : OSISPC
//    Fecha   : 5/18/2014 2:19:15 PM
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System; 
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CodeFluent.Runtime;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Validators;
using OSIS.PEPPAM.Mvc.Models; 

namespace OSIS.PEPPAM.Mvc.Models 
{ 
[Validator(typeof(Experiencias_MasterValidator))]
	public partial class Experiencias_MasterModel 
	{ 
		// Add your custom members here 

    public static List<OSIS.PEPPAM.Mvc.Models.Experiencias_MasterModel> PageLoadAllPagingPersona(int pageIndex, int pageSize, string searchString,
            CodeFluent.Runtime.PageOptions pageOptions, int usuarioNumero,  out int totalCount)
        {
            var pageLoadAll = OSIS.PEPPAM.BOM.Experiencias_MasterCollection.PageLoadAllPagingPersona(pageIndex, pageSize, searchString, pageOptions, usuarioNumero);

            totalCount = pageLoadAll.TotalRowCount;
            if (pageLoadAll == null)
            {
                return new List<OSIS.PEPPAM.Mvc.Models.Experiencias_MasterModel>();
            }

            var result = pageLoadAll.Select(
                _experienciasMaster =>
                    new OSIS.PEPPAM.Mvc.Models.Experiencias_MasterModel()
                    {
                        Experiencia_Secuencia = _experienciasMaster.Experiencia_Secuencia,
                        Persona_Secuencia = _experienciasMaster.Persona_Secuencia,
                        Horario_Turno_Secuencia = _experienciasMaster.Horario_Turno_Secuencia,
                        Dia_Secuencia = _experienciasMaster.Dia_Secuencia,
                        Experiencia_Contenido = _experienciasMaster.Experiencia_Contenido,
                        Registro_Estado = _experienciasMaster.Registro_Estado,
                        Registro_Fecha = _experienciasMaster.Registro_Fecha,
                        Registro_Usuario = _experienciasMaster.Registro_Usuario,

                    }).ToList();

            return result;
        }//PageLoadAllPagingPersona


            public List<Proc_Persona_Turnos_PasadosModel> TurnosPasados { get; set; }


            public virtual string EntityKeyTurnos
            {
                get
                {
                    object[] keys = new object[] {
                        this.Persona_Secuencia,
                        this.Horario_Turno_Secuencia,
                        this.Dia_Secuencia
                 };
                    string v = CodeFluentPersistence.BuildEntityKey(keys);
                    return v;
                }
                set
                {
                    System.Type[] types = new System.Type[] {
                        typeof(int),
                        typeof(int),
                        typeof(int)
                        };
                    object[] defaultValues = new object[] {
                        -1,
                        -1,
                        -1
                        };
                    object[] v1 = CodeFluentPersistence.ParseEntityKey(value, types, defaultValues);
                    this.Persona_Secuencia = ((int)(v1[0]));
                    this.Horario_Turno_Secuencia = ((int)(v1[1]));
                    this.Dia_Secuencia = ((int)(v1[2]));
                }
            }


	} 
	public partial class Experiencias_MasterValidator 
	{ 

 public Experiencias_MasterValidator()
{

   Validators();

}

		// Add your custom members here 
	} 
} 



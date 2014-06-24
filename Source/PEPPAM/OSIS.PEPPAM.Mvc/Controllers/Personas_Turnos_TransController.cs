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
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSIS.PEPPAM.Mvc.Models;

namespace OSIS.PEPPAM.Mvc.Controllers
{
	public partial class Personas_Turnos_TransController : Personas_Turnos_TransControllerBase
	{
			// Put your controller's initialization logic here

        public JsonResult LoadHorarios(int rutaSecuencia)
        {
            var horarios = Horario_TransModel.PageLoadByRutasMaster(0, 1000, rutaSecuencia).Where(x => x.HorarioTurnoTrans != null && x.HorarioTurnoTrans.Count > 0);

            return Json(new SelectList(horarios, "Horario_Secuencia", "EntityDisplayName2"), JsonRequestBehavior.AllowGet);

        }


        public JsonResult LoadHorarioTurnos(int horarioSecuencia)
        {
            var horarios = Horario_TransModel.LoadTurnos(horarioSecuencia);

            return Json(new SelectList(horarios, "EntityKey", "Turnos"), JsonRequestBehavior.AllowGet);

        }
	}
}


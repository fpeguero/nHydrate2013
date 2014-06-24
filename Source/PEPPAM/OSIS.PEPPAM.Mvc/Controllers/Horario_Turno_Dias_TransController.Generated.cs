//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Creador : Administrator
//    Dominio : OSISPC
//    Pc      : OSISPC
//    Fecha   : 6/19/2014 1:29:11 PM
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web.Mvc; 
using System.Web; 
using System.Web.UI; 
using CodeFluent.Runtime; 
using OSIS.PEPPAM.Mvc.Models; 
using OSIS.PEPPAM.Mvc.Extensions.Controllers; 
using OSIS.PEPPAM.Mvc.Models.Shared; 
using OSIS.PEPPAM.Mvc.Extensions.ActionResults; 
using OSIS.PEPPAM.Mvc.Extensions.Controllers; 
using OSIS.PEPPAM.Mvc.Extensions.Helpers; 
using OSIS.PEPPAM.Mvc.Models.Shared; 
using OSIS.PEPPAM.Mvc.Models; 
using OSIS.PEPPAM.Mvc.UI; 
 
namespace OSIS.PEPPAM.Mvc.Controllers 
{ 
    public partial class Horario_Turno_Dias_TransController : Horario_Turno_Dias_TransControllerBase 
    { 

    } 
 
	public partial class Horario_Turno_Dias_TransControllerBase : BaseController 
	{ 
		#region Members 
 

 
        #endregion 
 
        #region Constructors 
 

 
        #endregion 
 
		#region Index 
 

public virtual ActionResult Index()
{
    var model = new Horario_Turno_Dias_TransModel();

    ViewBag.PageIndex = this.GetPageIndex();
    ViewBag.PageSize = this.GetPageSize();
    ViewBag.SearchValue = this.GetSearchValue();

    return View(model);
}


[HttpPost]
public virtual ActionResult Load(GridRequestViewModel gridRequest)
{
    OrderByArgumentCollection orderByArguments = new OrderByArgumentCollection();
    orderByArguments.Add("[" + gridRequest.SortColumnName + "]", gridRequest.SortDirection);

    PageOptions pageOptions = new PageOptions();
    pageOptions.OrderByArguments = orderByArguments;

    var totalCount = 0;

    var allhorarioTurnoDiasTrans = Horario_Turno_Dias_TransModel.PageLoadAllPaging(1 + gridRequest.RowStartIndex/gridRequest.RowCount,
        gridRequest.RowCount, gridRequest.Search, pageOptions, out totalCount);

    var displayRecords = allhorarioTurnoDiasTrans.Count;
    var totalRecords = totalCount;

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
        ? "MM/dd/yyyy"
        : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi =
        System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";

    return Json(new
    {
        iTotalDisplayRecords = displayRecords,
        iTotalRecords = totalRecords,
        sEcho = gridRequest.GridCustomData,
        aaData =
            allhorarioTurnoDiasTrans.Select(
                d =>
                    new
                    {
d.EntityKey,Turno_Fecha = d.Turno_Fecha.ToString(dateFormat, dtfi),d.Turno_Estado,d.Turno_Razon_Inactivo,d.Turno_Estudios_Iniciado_Cantidad,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Horario_Turno_Secuencia = d.HorarioTurnoTrans != null ? d.HorarioTurnoTrans.EntityDisplayName : string.Empty,Dia_Secuencia = d.DiasCata != null ? d.DiasCata.EntityDisplayName : string.Empty
                    })
    });

}

public virtual ActionResult Report()
{
    var totalCount = 0;
    var allhorarioTurnoDiasTrans = Horario_Turno_Dias_TransModel.LoadAllPaging(this.GetSearchValue(), out totalCount);

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
        ? "MM/dd/yyyy"
        : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi =
        System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";
    return new CsvReportResult("Horario_Turno_Dias_Trans",
        allhorarioTurnoDiasTrans.Select(
            d =>
                new
                {
d.EntityKey,Turno_Fecha = d.Turno_Fecha.ToString(dateFormat, dtfi),d.Turno_Estado,d.Turno_Razon_Inactivo,d.Turno_Estudios_Iniciado_Cantidad,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Horario_Turno_Secuencia = d.HorarioTurnoTrans != null ? d.HorarioTurnoTrans.EntityDisplayName : string.Empty,Dia_Secuencia = d.DiasCata != null ? d.DiasCata.EntityDisplayName : string.Empty
                }));
}


[HttpPost]
public virtual ActionResult Delete( string entityKey)

{
    try
    {
        var deleteModel  = Horario_Turno_Dias_TransModel.LoadByEntityKey(entityKey);
       if (deleteModel.Delete())
       {
          return Json(new { cssMainClass = "success", title = Messages.GetOrSetMensaje("MENSAJE_OPERACION_REALIZDA_SASTIFACTORIAMENTE_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }
       else
       {
          return Json(new { cssMainClass = "warning", title = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_NO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }
    }
    catch (Exception ex)
    {
          return Json(new { cssMainClass = "success", title = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_BORRADO") }, JsonRequestBehavior.AllowGet);
    }
    return Content(string.Empty);
}
		 
 
		#endregion 
 
		#region Create 
 

		// ******************************************* 
        // URL: /Horario_Turno_Dias_Trans/Create 
        // ******************************************* 

public virtual ActionResult Create()
{
    var horarioTurnoDiasTrans = new Horario_Turno_Dias_TransModel();
    ViewBag.IsNew = true;
    horarioTurnoDiasTrans.Registro_Estado = "A";

    return View(horarioTurnoDiasTrans);
}

//
// POST: /Usuarios/Create
[HttpPost]
public virtual ActionResult Create(Horario_Turno_Dias_TransModel horarioTurnoDiasTrans)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        horarioTurnoDiasTrans.Registro_Fecha = DateTime.Now;
        horarioTurnoDiasTrans.Registro_Usuario = User.Identity.Name;
                
        var result = horarioTurnoDiasTrans.Save();

        if (result)
        {
            return RedirectToAction("Edit", new { 
entityKey = horarioTurnoDiasTrans.EntityKey});
        }

    }

    ViewBag.IsNew = true;
    return View(horarioTurnoDiasTrans);
            
}

		 
 
		#endregion 
 
		#region Edit 
 

		// ******************************************* 
        // URL: /Horario_Turno_Dias_Trans/Edit/id 
        // ******************************************* 

public virtual ActionResult Edit(string entityKey)
{

    var horarioTurnoDiasTrans = Horario_Turno_Dias_TransModel.LoadByEntityKey(entityKey);

    ViewBag.IsNew = false;
            
    return View(horarioTurnoDiasTrans);
}

[HttpPost]
public virtual ActionResult Edit(Horario_Turno_Dias_TransModel horarioTurnoDiasTrans)
{
           
        if (ModelState.IsValid)
        {
        //Campos Auditorias
        horarioTurnoDiasTrans.Registro_Fecha = DateTime.Now;
        horarioTurnoDiasTrans.Registro_Usuario = User.Identity.Name;
                

            var result = horarioTurnoDiasTrans.Save();

            if (result)
            {
                return RedirectToAction("Index");
            }
        }

        ViewBag.IsNew = false;
        return View(horarioTurnoDiasTrans);
}

public virtual ActionResult LoadHorarioTurnoInformeTrans(GridRequestViewModel gridRequest,string entityKey){
    var horario_Turno_Informe_Trans = Horario_Turno_Dias_TransModel.LoadByEntityKey(entityKey);

    int count = horario_Turno_Informe_Trans.HorarioTurnoInformeTrans.Count;

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en" ? "MM/dd/yyyy" : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";

    return Json(new
    {
        iTotalDisplayRecords = count,
        iTotalRecords = count,
        sEcho = gridRequest.GridCustomData,
        aaData = horario_Turno_Informe_Trans.HorarioTurnoInformeTrans.Skip(gridRequest.RowStartIndex)
                        .Take(gridRequest.RowCount)
                        .Select(d => new { 
d.EntityKey,d.Publicacion_Cantidad,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Persona_Secuencia = d.PersonasMaster != null ? d.PersonasMaster.EntityDisplayName : string.Empty,Horario_Turno_Secuencia = d.HorarioTurnoDiasTrans != null ? d.HorarioTurnoDiasTrans.EntityDisplayName : string.Empty,Publicacion_Numero = d.PublicacionesCata != null ? d.PublicacionesCata.EntityDisplayName : string.Empty,Idioma_Numero = d.IdiomasCata != null ? d.IdiomasCata.EntityDisplayName : string.Empty,d.Dia_Secuencia
    })
 });

}

public virtual ActionResult AddHorarioTurnoInformeTrans(string entityKey){
    var horario_Turno_Dias_Trans = Horario_Turno_Dias_TransModel.LoadByEntityKey(entityKey);

    var horario_Turno_Informe_Trans = new Horario_Turno_Informe_TransModel();

 horario_Turno_Informe_Trans.Horario_Turno_Secuencia =horario_Turno_Dias_Trans.Horario_Turno_Secuencia; horario_Turno_Informe_Trans.Dia_Secuencia =horario_Turno_Dias_Trans.Dia_Secuencia;            

    ViewBag.MasterProperty = "Horario_Turno_Dias_Trans_Horario_Turno_Informe_Trans";

    //relations

    ViewBag.Name = "AddHorario_Turno_Informe_Trans";
    ViewBag.IsNew = true;
    horario_Turno_Informe_Trans.Registro_Estado = "A";

    return PartialView("~/Views/Horario_Turno_Informe_Trans/PopUp.cshtml", horario_Turno_Informe_Trans);
}

[HttpPost]
public virtual ActionResult AddHorarioTurnoInformeTrans(Horario_Turno_Informe_TransModel horario_Turno_Informe_Trans)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        horario_Turno_Informe_Trans.Registro_Fecha = DateTime.Now;
        horario_Turno_Informe_Trans.Registro_Usuario = User.Identity.Name;

        horario_Turno_Informe_Trans.Save();
                
        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

//Columna por las cuales estan relacionadas
public virtual ActionResult EditHorarioTurnoInformeTrans(string entityKey_parent, string entityKey_child )
{
    var horario_Turno_Informe_Trans =  Horario_Turno_Informe_TransModel.LoadByEntityKey(entityKey_child);
            
    ViewBag.MasterProperty = "Horario_Turno_Dias_Trans_Horario_Turno_Informe_Trans";
    ViewBag.Name = "EditHorario_Turno_Informe_Trans";
    ViewBag.IsNew = false;

    return PartialView("~/Views/Horario_Turno_Informe_Trans/PopUp.cshtml", horario_Turno_Informe_Trans);
}

[HttpPost]
public virtual ActionResult EditHorarioTurnoInformeTrans(Horario_Turno_Informe_TransModel horario_Turno_Informe_Trans)
{
    if (ModelState.IsValid)
    {
        //Campos Auditorias
        horario_Turno_Informe_Trans.Registro_Fecha = DateTime.Now;
        horario_Turno_Informe_Trans.Registro_Usuario = User.Identity.Name;
        horario_Turno_Informe_Trans.Save();

        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

[HttpPost]
public virtual ActionResult DeleteHorarioTurnoInformeTrans(string entityKey_parent, string entityKey_child ){
    var horario_Turno_Informe_Trans = Horario_Turno_Informe_TransModel.LoadByEntityKey(entityKey_child);
       if (horario_Turno_Informe_Trans.Delete())
       {
          return Json(new { cssMainClass = "success", title = Messages.GetOrSetMensaje("MENSAJE_OPERACION_REALIZDA_SASTIFACTORIAMENTE_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }
       else
       {
          return Json(new { cssMainClass = "warning", title = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_NO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }

}

public virtual ActionResult ReportHorarioTurnoInformeTrans(string entityKey){
    var horario_Turno_Informe_Trans = Horario_Turno_Dias_TransModel.LoadByEntityKey(entityKey);            
    return new CsvReportResult("Horario_Turno_Informe_Trans", horario_Turno_Informe_Trans.HorarioTurnoInformeTrans);
}

public virtual ActionResult LoadPersonasTurnosTrans(GridRequestViewModel gridRequest,string entityKey){
    var personas_Turnos_Trans = Horario_Turno_Dias_TransModel.LoadByEntityKey(entityKey);

    int count = personas_Turnos_Trans.PersonasTurnosTrans.Count;

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en" ? "MM/dd/yyyy" : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";

    return Json(new
    {
        iTotalDisplayRecords = count,
        iTotalRecords = count,
        sEcho = gridRequest.GridCustomData,
        aaData = personas_Turnos_Trans.PersonasTurnosTrans.Skip(gridRequest.RowStartIndex)
                        .Take(gridRequest.RowCount)
                        .Select(d => new { 
d.EntityKey,d.Persona_Turno_HC,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Horario_Turno_Secuencia = d.HorarioTurnoDiasTrans != null ? d.HorarioTurnoDiasTrans.EntityDisplayName : string.Empty,Persona_Secuencia = d.Persona != null ? d.Persona.EntityDisplayName : string.Empty,d.Dia_Secuencia
    })
 });

}

public virtual ActionResult AddPersonasTurnosTrans(string entityKey){
    var horario_Turno_Dias_Trans = Horario_Turno_Dias_TransModel.LoadByEntityKey(entityKey);

    var personas_Turnos_Trans = new Personas_Turnos_TransModel();

 personas_Turnos_Trans.Horario_Turno_Secuencia =horario_Turno_Dias_Trans.Horario_Turno_Secuencia; personas_Turnos_Trans.Dia_Secuencia =horario_Turno_Dias_Trans.Dia_Secuencia;            

    ViewBag.MasterProperty = "Horario_Turno_Dias_Trans_Personas_Turnos_Trans";

    //relations

    ViewBag.Name = "AddPersonas_Turnos_Trans";
    ViewBag.IsNew = true;
    personas_Turnos_Trans.Registro_Estado = "A";

    return PartialView("~/Views/Personas_Turnos_Trans/PopUp.cshtml", personas_Turnos_Trans);
}

[HttpPost]
public virtual ActionResult AddPersonasTurnosTrans(Personas_Turnos_TransModel personas_Turnos_Trans)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        personas_Turnos_Trans.Registro_Fecha = DateTime.Now;
        personas_Turnos_Trans.Registro_Usuario = User.Identity.Name;

        personas_Turnos_Trans.Save();
                
        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

//Columna por las cuales estan relacionadas
public virtual ActionResult EditPersonasTurnosTrans(string entityKey_parent, string entityKey_child )
{
    var personas_Turnos_Trans =  Personas_Turnos_TransModel.LoadByEntityKey(entityKey_child);
            
    ViewBag.MasterProperty = "Horario_Turno_Dias_Trans_Personas_Turnos_Trans";
    ViewBag.Name = "EditPersonas_Turnos_Trans";
    ViewBag.IsNew = false;

    return PartialView("~/Views/Personas_Turnos_Trans/PopUp.cshtml", personas_Turnos_Trans);
}

[HttpPost]
public virtual ActionResult EditPersonasTurnosTrans(Personas_Turnos_TransModel personas_Turnos_Trans)
{
    if (ModelState.IsValid)
    {
        //Campos Auditorias
        personas_Turnos_Trans.Registro_Fecha = DateTime.Now;
        personas_Turnos_Trans.Registro_Usuario = User.Identity.Name;
        personas_Turnos_Trans.Save();

        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

[HttpPost]
public virtual ActionResult DeletePersonasTurnosTrans(string entityKey_parent, string entityKey_child ){
    var personas_Turnos_Trans = Personas_Turnos_TransModel.LoadByEntityKey(entityKey_child);
       if (personas_Turnos_Trans.Delete())
       {
          return Json(new { cssMainClass = "success", title = Messages.GetOrSetMensaje("MENSAJE_OPERACION_REALIZDA_SASTIFACTORIAMENTE_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }
       else
       {
          return Json(new { cssMainClass = "warning", title = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_NO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }

}

public virtual ActionResult ReportPersonasTurnosTrans(string entityKey){
    var personas_Turnos_Trans = Horario_Turno_Dias_TransModel.LoadByEntityKey(entityKey);            
    return new CsvReportResult("Personas_Turnos_Trans", personas_Turnos_Trans.PersonasTurnosTrans);
}

		 
 
		#endregion 
 
		#region Details 
 

		 
 
		#endregion 

	} 
} 


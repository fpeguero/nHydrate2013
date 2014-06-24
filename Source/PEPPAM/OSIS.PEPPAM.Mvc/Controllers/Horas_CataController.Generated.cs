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
    public partial class Horas_CataController : Horas_CataControllerBase 
    { 

    } 
 
	public partial class Horas_CataControllerBase : BaseController 
	{ 
		#region Members 
 

 
        #endregion 
 
        #region Constructors 
 

 
        #endregion 
 
		#region Index 
 

public virtual ActionResult Index()
{
    var model = new Horas_CataModel();

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

    var allhorasCata = Horas_CataModel.PageLoadAllPaging(1 + gridRequest.RowStartIndex/gridRequest.RowCount,
        gridRequest.RowCount, gridRequest.Search, pageOptions, out totalCount);

    var displayRecords = allhorasCata.Count;
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
            allhorasCata.Select(
                d =>
                    new
                    {
d.Hora_Secuencia,d.Hora_Desde,d.Hora_Hasta,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario
                    })
    });

}

public virtual ActionResult Report()
{
    var totalCount = 0;
    var allhorasCata = Horas_CataModel.LoadAllPaging(this.GetSearchValue(), out totalCount);

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
        ? "MM/dd/yyyy"
        : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi =
        System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";
    return new CsvReportResult("Horas_Cata",
        allhorasCata.Select(
            d =>
                new
                {
d.Hora_Secuencia,d.Hora_Desde,d.Hora_Hasta,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario
                }));
}


[HttpPost]
public virtual ActionResult Delete( string entityKey)

{
    try
    {
        var deleteModel  = Horas_CataModel.LoadByEntityKey(entityKey);
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
        // URL: /Horas_Cata/Create 
        // ******************************************* 

public virtual ActionResult Create()
{
    var horasCata = new Horas_CataModel();
    ViewBag.IsNew = true;
    horasCata.Registro_Estado = "A";

    return View(horasCata);
}

//
// POST: /Usuarios/Create
[HttpPost]
public virtual ActionResult Create(Horas_CataModel horasCata)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        horasCata.Registro_Fecha = DateTime.Now;
        horasCata.Registro_Usuario = User.Identity.Name;
                
        var result = horasCata.Save();

        if (result)
        {
            return RedirectToAction("Edit", new { 
hora_Secuencia = horasCata.Hora_Secuencia});
        }

    }

    ViewBag.IsNew = true;
    return View(horasCata);
            
}

		 
 
		#endregion 
 
		#region Edit 
 

		// ******************************************* 
        // URL: /Horas_Cata/Edit/id 
        // ******************************************* 

public virtual ActionResult Edit(int hora_Secuencia)
{

    var horasCata = Horas_CataModel.LoadByEntityKey(hora_Secuencia.ToString());

    ViewBag.IsNew = false;
            
    return View(horasCata);
}

[HttpPost]
public virtual ActionResult Edit(Horas_CataModel horasCata)
{
           
        if (ModelState.IsValid)
        {
        //Campos Auditorias
        horasCata.Registro_Fecha = DateTime.Now;
        horasCata.Registro_Usuario = User.Identity.Name;
                

            var result = horasCata.Save();

            if (result)
            {
                return RedirectToAction("Index");
            }
        }

        ViewBag.IsNew = false;
        return View(horasCata);
}

public virtual ActionResult LoadPersonasDiponibilidad(GridRequestViewModel gridRequest,int hora_Secuencia){
    var personas_Diponibilidad = Horas_CataModel.LoadByEntityKey(hora_Secuencia.ToString());

    int count = personas_Diponibilidad.PersonasDiponibilidad.Count;

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en" ? "MM/dd/yyyy" : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";

    return Json(new
    {
        iTotalDisplayRecords = count,
        iTotalRecords = count,
        sEcho = gridRequest.GridCustomData,
        aaData = personas_Diponibilidad.PersonasDiponibilidad.Skip(gridRequest.RowStartIndex)
                        .Take(gridRequest.RowCount)
                        .Select(d => new { 
d.EntityKey,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Persona_Secuencia = d.PersonasMaster != null ? d.PersonasMaster.EntityDisplayName : string.Empty,Hora_Secuencia = d.HorasCata != null ? d.HorasCata.EntityDisplayName : string.Empty,Dia_Secuencia = d.DiasCata != null ? d.DiasCata.EntityDisplayName : string.Empty
    })
 });

}

public virtual ActionResult AddPersonasDiponibilidad(int hora_Secuencia){
    var horas_Cata = Horas_CataModel.LoadByEntityKey(hora_Secuencia.ToString());

    var personas_Diponibilidad = new Personas_DiponibilidadModel();

 personas_Diponibilidad.Hora_Secuencia =horas_Cata.Hora_Secuencia;            

    ViewBag.MasterProperty = "Horas_Cata_Personas_Diponibilidad";

    //relations

    ViewBag.Name = "AddPersonas_Diponibilidad";
    ViewBag.IsNew = true;
    personas_Diponibilidad.Registro_Estado = "A";

    return PartialView("~/Views/Personas_Diponibilidad/PopUp.cshtml", personas_Diponibilidad);
}

[HttpPost]
public virtual ActionResult AddPersonasDiponibilidad(Personas_DiponibilidadModel personas_Diponibilidad)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        personas_Diponibilidad.Registro_Fecha = DateTime.Now;
        personas_Diponibilidad.Registro_Usuario = User.Identity.Name;

        personas_Diponibilidad.Save();
                
        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

//Columna por las cuales estan relacionadas
public virtual ActionResult EditPersonasDiponibilidad(int hora_Secuencia_parent, string entityKey_child )
{
    var personas_Diponibilidad =  Personas_DiponibilidadModel.LoadByEntityKey(entityKey_child.ToString());
            
    ViewBag.MasterProperty = "Horas_Cata_Personas_Diponibilidad";
    ViewBag.Name = "EditPersonas_Diponibilidad";
    ViewBag.IsNew = false;

    return PartialView("~/Views/Personas_Diponibilidad/PopUp.cshtml", personas_Diponibilidad);
}

[HttpPost]
public virtual ActionResult EditPersonasDiponibilidad(Personas_DiponibilidadModel personas_Diponibilidad)
{
    if (ModelState.IsValid)
    {
        //Campos Auditorias
        personas_Diponibilidad.Registro_Fecha = DateTime.Now;
        personas_Diponibilidad.Registro_Usuario = User.Identity.Name;
        personas_Diponibilidad.Save();

        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

[HttpPost]
public virtual ActionResult DeletePersonasDiponibilidad(int hora_Secuencia_parent, string entityKey_child ){
    var personas_Diponibilidad = Personas_DiponibilidadModel.LoadByEntityKey(entityKey_child.ToString());
       if (personas_Diponibilidad.Delete())
       {
          return Json(new { cssMainClass = "success", title = Messages.GetOrSetMensaje("MENSAJE_OPERACION_REALIZDA_SASTIFACTORIAMENTE_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }
       else
       {
          return Json(new { cssMainClass = "warning", title = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_NO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }

}

public virtual ActionResult ReportPersonasDiponibilidad(int hora_Secuencia){
    var personas_Diponibilidad = Horas_CataModel.LoadByEntityKey(hora_Secuencia.ToString());            
    return new CsvReportResult("Personas_Diponibilidad", personas_Diponibilidad.PersonasDiponibilidad);
}

		 
 
		#endregion 
 
		#region Details 
 

		 
 
		#endregion 

	} 
} 


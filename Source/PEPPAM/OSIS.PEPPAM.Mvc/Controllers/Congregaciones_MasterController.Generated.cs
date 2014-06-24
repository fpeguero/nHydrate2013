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
    public partial class Congregaciones_MasterController : Congregaciones_MasterControllerBase 
    { 

    } 
 
	public partial class Congregaciones_MasterControllerBase : BaseController 
	{ 
		#region Members 
 

 
        #endregion 
 
        #region Constructors 
 

 
        #endregion 
 
		#region Index 
 

public virtual ActionResult Index()
{
    var model = new Congregaciones_MasterModel();

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

    var allcongregacionesMaster = Congregaciones_MasterModel.PageLoadAllPaging(1 + gridRequest.RowStartIndex/gridRequest.RowCount,
        gridRequest.RowCount, gridRequest.Search, pageOptions, out totalCount);

    var displayRecords = allcongregacionesMaster.Count;
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
            allcongregacionesMaster.Select(
                d =>
                    new
                    {
d.Congregacion_Secuencia,d.Congregacion_Nombre,d.Congregacion_Direccion,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Zona_Secuencia = d.Zona != null ? d.Zona.EntityDisplayName : string.Empty,Circuito_Numero = d.Circuito != null ? d.Circuito.EntityDisplayName : string.Empty
                    })
    });

}

public virtual ActionResult Report()
{
    var totalCount = 0;
    var allcongregacionesMaster = Congregaciones_MasterModel.LoadAllPaging(this.GetSearchValue(), out totalCount);

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
        ? "MM/dd/yyyy"
        : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi =
        System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";
    return new CsvReportResult("Congregaciones_Master",
        allcongregacionesMaster.Select(
            d =>
                new
                {
d.Congregacion_Secuencia,d.Congregacion_Nombre,d.Congregacion_Direccion,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Zona_Secuencia = d.Zona != null ? d.Zona.EntityDisplayName : string.Empty,Circuito_Numero = d.Circuito != null ? d.Circuito.EntityDisplayName : string.Empty
                }));
}


[HttpPost]
public virtual ActionResult Delete( string entityKey)

{
    try
    {
        var deleteModel  = Congregaciones_MasterModel.LoadByEntityKey(entityKey);
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
        // URL: /Congregaciones_Master/Create 
        // ******************************************* 

public virtual ActionResult Create()
{
    var congregacionesMaster = new Congregaciones_MasterModel();
    ViewBag.IsNew = true;
    congregacionesMaster.Registro_Estado = "A";

    return View(congregacionesMaster);
}

//
// POST: /Usuarios/Create
[HttpPost]
public virtual ActionResult Create(Congregaciones_MasterModel congregacionesMaster)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        congregacionesMaster.Registro_Fecha = DateTime.Now;
        congregacionesMaster.Registro_Usuario = User.Identity.Name;
                
        var result = congregacionesMaster.Save();

        if (result)
        {
            return RedirectToAction("Edit", new { 
congregacion_Secuencia = congregacionesMaster.Congregacion_Secuencia});
        }

    }

    ViewBag.IsNew = true;
    return View(congregacionesMaster);
            
}

		 
 
		#endregion 
 
		#region Edit 
 

		// ******************************************* 
        // URL: /Congregaciones_Master/Edit/id 
        // ******************************************* 

public virtual ActionResult Edit(int congregacion_Secuencia)
{

    var congregacionesMaster = Congregaciones_MasterModel.LoadByEntityKey(congregacion_Secuencia.ToString());

    ViewBag.IsNew = false;
            
    return View(congregacionesMaster);
}

[HttpPost]
public virtual ActionResult Edit(Congregaciones_MasterModel congregacionesMaster)
{
           
        if (ModelState.IsValid)
        {
        //Campos Auditorias
        congregacionesMaster.Registro_Fecha = DateTime.Now;
        congregacionesMaster.Registro_Usuario = User.Identity.Name;
                

            var result = congregacionesMaster.Save();

            if (result)
            {
                return RedirectToAction("Index");
            }
        }

        ViewBag.IsNew = false;
        return View(congregacionesMaster);
}

public virtual ActionResult LoadPersonas(GridRequestViewModel gridRequest,int congregacion_Secuencia){
    var personas = Congregaciones_MasterModel.LoadByEntityKey(congregacion_Secuencia.ToString());

    int count = personas.Personas.Count;

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en" ? "MM/dd/yyyy" : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";

    return Json(new
    {
        iTotalDisplayRecords = count,
        iTotalRecords = count,
        sEcho = gridRequest.GridCustomData,
        aaData = personas.Personas.Skip(gridRequest.RowStartIndex)
                        .Take(gridRequest.RowCount)
                        .Select(d => new { 
d.Persona_Secuencia,d.Persona_Congregacion,d.Persona_Nombres,d.Persona_Apellidos,d.Persona_Conyuge_Apellido,d.Persona_Sexo,d.Persona_Correo,d.Persona_Clave,d.Persona_Verificacion_Numero,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Persona_Estado_Secuencia = d.PersonaEstadoCata != null ? d.PersonaEstadoCata.EntityDisplayName : string.Empty,Persona_Tipo_Secuencia = d.PersonasTipoCata != null ? d.PersonasTipoCata.EntityDisplayName : string.Empty,Congregacion_Secuencia = d.Congregacion != null ? d.Congregacion.EntityDisplayName : string.Empty
    })
 });

}

public virtual ActionResult AddPersonas(int congregacion_Secuencia){
    var congregaciones_Master = Congregaciones_MasterModel.LoadByEntityKey(congregacion_Secuencia.ToString());

    var personas = new Personas_MasterModel();

 personas.Congregacion_Secuencia =congregaciones_Master.Congregacion_Secuencia;            

    ViewBag.MasterProperty = "Congregaciones_Master_Personas";

    //relations

    ViewBag.Name = "AddPersonas_Master";
    ViewBag.IsNew = true;
    personas.Registro_Estado = "A";

    return PartialView("~/Views/Personas_Master/PopUp.cshtml", personas);
}

[HttpPost]
public virtual ActionResult AddPersonas(Personas_MasterModel personas)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        personas.Registro_Fecha = DateTime.Now;
        personas.Registro_Usuario = User.Identity.Name;

        personas.Save();
                
        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

//Columna por las cuales estan relacionadas
public virtual ActionResult EditPersonas(int congregacion_Secuencia_parent, int persona_Secuencia_child )
{
    var personas =  Personas_MasterModel.LoadByEntityKey(persona_Secuencia_child.ToString());
            
    ViewBag.MasterProperty = "Congregaciones_Master_Personas";
    ViewBag.Name = "EditPersonas_Master";
    ViewBag.IsNew = false;

    return PartialView("~/Views/Personas_Master/PopUp.cshtml", personas);
}

[HttpPost]
public virtual ActionResult EditPersonas(Personas_MasterModel personas)
{
    if (ModelState.IsValid)
    {
        //Campos Auditorias
        personas.Registro_Fecha = DateTime.Now;
        personas.Registro_Usuario = User.Identity.Name;
        personas.Save();

        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

[HttpPost]
public virtual ActionResult DeletePersonas(int congregacion_Secuencia_parent, int persona_Secuencia_child ){
    var personas = Personas_MasterModel.LoadByEntityKey(persona_Secuencia_child.ToString());
       if (personas.Delete())
       {
          return Json(new { cssMainClass = "success", title = Messages.GetOrSetMensaje("MENSAJE_OPERACION_REALIZDA_SASTIFACTORIAMENTE_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }
       else
       {
          return Json(new { cssMainClass = "warning", title = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_NO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }

}

public virtual ActionResult ReportPersonas(int congregacion_Secuencia){
    var personas = Congregaciones_MasterModel.LoadByEntityKey(congregacion_Secuencia.ToString());            
    return new CsvReportResult("Personas_Master", personas.Personas);
}

		 
 
		#endregion 
 
		#region Details 
 

		 
 
		#endregion 

	} 
} 



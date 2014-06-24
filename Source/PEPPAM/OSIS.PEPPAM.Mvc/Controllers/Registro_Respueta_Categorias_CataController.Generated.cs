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
    public partial class Registro_Respueta_Categorias_CataController : Registro_Respueta_Categorias_CataControllerBase 
    { 

    } 
 
	public partial class Registro_Respueta_Categorias_CataControllerBase : BaseController 
	{ 
		#region Members 
 

 
        #endregion 
 
        #region Constructors 
 

 
        #endregion 
 
		#region Index 
 

public virtual ActionResult Index()
{
    var model = new Registro_Respueta_Categorias_CataModel();

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

    var allregistroRespuetaCategoriasCata = Registro_Respueta_Categorias_CataModel.PageLoadAllPaging(1 + gridRequest.RowStartIndex/gridRequest.RowCount,
        gridRequest.RowCount, gridRequest.Search, pageOptions, out totalCount);

    var displayRecords = allregistroRespuetaCategoriasCata.Count;
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
            allregistroRespuetaCategoriasCata.Select(
                d =>
                    new
                    {
d.Respuesta_Categoria_Secuencia,d.Respuesta_Categoria_Descripcion,d.Respuesta_Categoria_Explicacion,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario
                    })
    });

}

public virtual ActionResult Report()
{
    var totalCount = 0;
    var allregistroRespuetaCategoriasCata = Registro_Respueta_Categorias_CataModel.LoadAllPaging(this.GetSearchValue(), out totalCount);

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
        ? "MM/dd/yyyy"
        : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi =
        System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";
    return new CsvReportResult("Registro_Respueta_Categorias_Cata",
        allregistroRespuetaCategoriasCata.Select(
            d =>
                new
                {
d.Respuesta_Categoria_Secuencia,d.Respuesta_Categoria_Descripcion,d.Respuesta_Categoria_Explicacion,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario
                }));
}


[HttpPost]
public virtual ActionResult Delete( string entityKey)

{
    try
    {
        var deleteModel  = Registro_Respueta_Categorias_CataModel.LoadByEntityKey(entityKey);
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
        // URL: /Registro_Respueta_Categorias_Cata/Create 
        // ******************************************* 

public virtual ActionResult Create()
{
    var registroRespuetaCategoriasCata = new Registro_Respueta_Categorias_CataModel();
    ViewBag.IsNew = true;
    registroRespuetaCategoriasCata.Registro_Estado = "A";

    return View(registroRespuetaCategoriasCata);
}

//
// POST: /Usuarios/Create
[HttpPost]
public virtual ActionResult Create(Registro_Respueta_Categorias_CataModel registroRespuetaCategoriasCata)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        registroRespuetaCategoriasCata.Registro_Fecha = DateTime.Now;
        registroRespuetaCategoriasCata.Registro_Usuario = User.Identity.Name;
                
        var result = registroRespuetaCategoriasCata.Save();

        if (result)
        {
            return RedirectToAction("Edit", new { 
respuesta_Categoria_Secuencia = registroRespuetaCategoriasCata.Respuesta_Categoria_Secuencia});
        }

    }

    ViewBag.IsNew = true;
    return View(registroRespuetaCategoriasCata);
            
}

		 
 
		#endregion 
 
		#region Edit 
 

		// ******************************************* 
        // URL: /Registro_Respueta_Categorias_Cata/Edit/id 
        // ******************************************* 

public virtual ActionResult Edit(int respuesta_Categoria_Secuencia)
{

    var registroRespuetaCategoriasCata = Registro_Respueta_Categorias_CataModel.LoadByEntityKey(respuesta_Categoria_Secuencia.ToString());

    ViewBag.IsNew = false;
            
    return View(registroRespuetaCategoriasCata);
}

[HttpPost]
public virtual ActionResult Edit(Registro_Respueta_Categorias_CataModel registroRespuetaCategoriasCata)
{
           
        if (ModelState.IsValid)
        {
        //Campos Auditorias
        registroRespuetaCategoriasCata.Registro_Fecha = DateTime.Now;
        registroRespuetaCategoriasCata.Registro_Usuario = User.Identity.Name;
                

            var result = registroRespuetaCategoriasCata.Save();

            if (result)
            {
                return RedirectToAction("Index");
            }
        }

        ViewBag.IsNew = false;
        return View(registroRespuetaCategoriasCata);
}

public virtual ActionResult LoadRegistroRespuestasCata(GridRequestViewModel gridRequest,int respuesta_Categoria_Secuencia){
    var registro_Respuestas_Cata = Registro_Respueta_Categorias_CataModel.LoadByEntityKey(respuesta_Categoria_Secuencia.ToString());

    int count = registro_Respuestas_Cata.RegistroRespuestasCata.Count;

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en" ? "MM/dd/yyyy" : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";

    return Json(new
    {
        iTotalDisplayRecords = count,
        iTotalRecords = count,
        sEcho = gridRequest.GridCustomData,
        aaData = registro_Respuestas_Cata.RegistroRespuestasCata.Skip(gridRequest.RowStartIndex)
                        .Take(gridRequest.RowCount)
                        .Select(d => new { 
d.Respuesta_Secuencia,d.Respuesta_Descripcion,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Respuesta_Categoria_Secuencia = d.RegistroRespuetaCategoriasCata != null ? d.RegistroRespuetaCategoriasCata.EntityDisplayName : string.Empty
    })
 });

}

public virtual ActionResult AddRegistroRespuestasCata(int respuesta_Categoria_Secuencia){
    var registro_Respueta_Categorias_Cata = Registro_Respueta_Categorias_CataModel.LoadByEntityKey(respuesta_Categoria_Secuencia.ToString());

    var registro_Respuestas_Cata = new Registro_Respuestas_CataModel();

 registro_Respuestas_Cata.Respuesta_Categoria_Secuencia =registro_Respueta_Categorias_Cata.Respuesta_Categoria_Secuencia;            

    ViewBag.MasterProperty = "Registro_Respueta_Categorias_Cata_Registro_Respuestas_Cata";

    //relations

    ViewBag.Name = "AddRegistro_Respuestas_Cata";
    ViewBag.IsNew = true;
    registro_Respuestas_Cata.Registro_Estado = "A";

    return PartialView("~/Views/Registro_Respuestas_Cata/PopUp.cshtml", registro_Respuestas_Cata);
}

[HttpPost]
public virtual ActionResult AddRegistroRespuestasCata(Registro_Respuestas_CataModel registro_Respuestas_Cata)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        registro_Respuestas_Cata.Registro_Fecha = DateTime.Now;
        registro_Respuestas_Cata.Registro_Usuario = User.Identity.Name;

        registro_Respuestas_Cata.Save();
                
        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

//Columna por las cuales estan relacionadas
public virtual ActionResult EditRegistroRespuestasCata(int respuesta_Categoria_Secuencia_parent, int respuesta_Secuencia_child )
{
    var registro_Respuestas_Cata =  Registro_Respuestas_CataModel.LoadByEntityKey(respuesta_Secuencia_child.ToString());
            
    ViewBag.MasterProperty = "Registro_Respueta_Categorias_Cata_Registro_Respuestas_Cata";
    ViewBag.Name = "EditRegistro_Respuestas_Cata";
    ViewBag.IsNew = false;

    return PartialView("~/Views/Registro_Respuestas_Cata/PopUp.cshtml", registro_Respuestas_Cata);
}

[HttpPost]
public virtual ActionResult EditRegistroRespuestasCata(Registro_Respuestas_CataModel registro_Respuestas_Cata)
{
    if (ModelState.IsValid)
    {
        //Campos Auditorias
        registro_Respuestas_Cata.Registro_Fecha = DateTime.Now;
        registro_Respuestas_Cata.Registro_Usuario = User.Identity.Name;
        registro_Respuestas_Cata.Save();

        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

[HttpPost]
public virtual ActionResult DeleteRegistroRespuestasCata(int respuesta_Categoria_Secuencia_parent, int respuesta_Secuencia_child ){
    var registro_Respuestas_Cata = Registro_Respuestas_CataModel.LoadByEntityKey(respuesta_Secuencia_child.ToString());
       if (registro_Respuestas_Cata.Delete())
       {
          return Json(new { cssMainClass = "success", title = Messages.GetOrSetMensaje("MENSAJE_OPERACION_REALIZDA_SASTIFACTORIAMENTE_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }
       else
       {
          return Json(new { cssMainClass = "warning", title = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_NO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }

}

public virtual ActionResult ReportRegistroRespuestasCata(int respuesta_Categoria_Secuencia){
    var registro_Respuestas_Cata = Registro_Respueta_Categorias_CataModel.LoadByEntityKey(respuesta_Categoria_Secuencia.ToString());            
    return new CsvReportResult("Registro_Respuestas_Cata", registro_Respuestas_Cata.RegistroRespuestasCata);
}

		 
 
		#endregion 
 
		#region Details 
 

		 
 
		#endregion 

	} 
} 



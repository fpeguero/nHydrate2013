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
    public partial class Roles_Niveles_CataController : Roles_Niveles_CataControllerBase 
    { 

    } 
 
	public partial class Roles_Niveles_CataControllerBase : BaseController 
	{ 
		#region Members 
 

 
        #endregion 
 
        #region Constructors 
 

 
        #endregion 
 
		#region Index 
 

public virtual ActionResult Index()
{
    var model = new Roles_Niveles_CataModel();

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

    var allrolesNivelesCata = Roles_Niveles_CataModel.PageLoadAllPaging(1 + gridRequest.RowStartIndex/gridRequest.RowCount,
        gridRequest.RowCount, gridRequest.Search, pageOptions, out totalCount);

    var displayRecords = allrolesNivelesCata.Count;
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
            allrolesNivelesCata.Select(
                d =>
                    new
                    {
d.Role_Nivel_Numero,d.Role_Nivel,d.Role_Nivel_Nombre,d.Role_Nivel_Descripcion,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario
                    })
    });

}

public virtual ActionResult Report()
{
    var totalCount = 0;
    var allrolesNivelesCata = Roles_Niveles_CataModel.LoadAllPaging(this.GetSearchValue(), out totalCount);

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
        ? "MM/dd/yyyy"
        : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi =
        System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";
    return new CsvReportResult("Roles_Niveles_Cata",
        allrolesNivelesCata.Select(
            d =>
                new
                {
d.Role_Nivel_Numero,d.Role_Nivel,d.Role_Nivel_Nombre,d.Role_Nivel_Descripcion,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario
                }));
}


[HttpPost]
public virtual ActionResult Delete( string entityKey)

{
    try
    {
        var deleteModel  = Roles_Niveles_CataModel.LoadByEntityKey(entityKey);
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
        // URL: /Roles_Niveles_Cata/Create 
        // ******************************************* 

public virtual ActionResult Create()
{
    var rolesNivelesCata = new Roles_Niveles_CataModel();
    ViewBag.IsNew = true;
    rolesNivelesCata.Registro_Estado = "A";

    return View(rolesNivelesCata);
}

//
// POST: /Usuarios/Create
[HttpPost]
public virtual ActionResult Create(Roles_Niveles_CataModel rolesNivelesCata)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        rolesNivelesCata.Registro_Fecha = DateTime.Now;
        rolesNivelesCata.Registro_Usuario = User.Identity.Name;
                
        var result = rolesNivelesCata.Save();

        if (result)
        {
            return RedirectToAction("Edit", new { 
role_Nivel_Numero = rolesNivelesCata.Role_Nivel_Numero});
        }

    }

    ViewBag.IsNew = true;
    return View(rolesNivelesCata);
            
}

		 
 
		#endregion 
 
		#region Edit 
 

		// ******************************************* 
        // URL: /Roles_Niveles_Cata/Edit/id 
        // ******************************************* 

public virtual ActionResult Edit(int role_Nivel_Numero)
{

    var rolesNivelesCata = Roles_Niveles_CataModel.LoadByEntityKey(role_Nivel_Numero.ToString());

    ViewBag.IsNew = false;
            
    return View(rolesNivelesCata);
}

[HttpPost]
public virtual ActionResult Edit(Roles_Niveles_CataModel rolesNivelesCata)
{
           
        if (ModelState.IsValid)
        {
        //Campos Auditorias
        rolesNivelesCata.Registro_Fecha = DateTime.Now;
        rolesNivelesCata.Registro_Usuario = User.Identity.Name;
                

            var result = rolesNivelesCata.Save();

            if (result)
            {
                return RedirectToAction("Index");
            }
        }

        ViewBag.IsNew = false;
        return View(rolesNivelesCata);
}

public virtual ActionResult LoadRolesCata(GridRequestViewModel gridRequest,int role_Nivel_Numero){
    var roles_Cata = Roles_Niveles_CataModel.LoadByEntityKey(role_Nivel_Numero.ToString());

    int count = roles_Cata.RolesCata.Count;

    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en" ? "MM/dd/yyyy" : "dd/MM/yyyy";
    System.Globalization.DateTimeFormatInfo dtfi = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
    dtfi.DateSeparator = "/";

    return Json(new
    {
        iTotalDisplayRecords = count,
        iTotalRecords = count,
        sEcho = gridRequest.GridCustomData,
        aaData = roles_Cata.RolesCata.Skip(gridRequest.RowStartIndex)
                        .Take(gridRequest.RowCount)
                        .Select(d => new { 
d.Role_Numero,d.Role_Nombre,d.Role_Descripcion,d.Registro_Estado,Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),d.Registro_Usuario,Role_Nivel_Numero = d.RolesNivelesCata != null ? d.RolesNivelesCata.EntityDisplayName : string.Empty
    })
 });

}

public virtual ActionResult AddRolesCata(int role_Nivel_Numero){
    var roles_Niveles_Cata = Roles_Niveles_CataModel.LoadByEntityKey(role_Nivel_Numero.ToString());

    var roles_Cata = new Roles_CataModel();

 roles_Cata.Role_Nivel_Numero =roles_Niveles_Cata.Role_Nivel_Numero;            

    ViewBag.MasterProperty = "Roles_Niveles_Cata_Roles_Cata";

    //relations

    ViewBag.Name = "AddRoles_Cata";
    ViewBag.IsNew = true;
    roles_Cata.Registro_Estado = "A";

    return PartialView("~/Views/Roles_Cata/PopUp.cshtml", roles_Cata);
}

[HttpPost]
public virtual ActionResult AddRolesCata(Roles_CataModel roles_Cata)
{
    if (ModelState.IsValid)
    {

        //Campos Auditorias
        roles_Cata.Registro_Fecha = DateTime.Now;
        roles_Cata.Registro_Usuario = User.Identity.Name;

        roles_Cata.Save();
                
        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

//Columna por las cuales estan relacionadas
public virtual ActionResult EditRolesCata(int role_Nivel_Numero_parent, int role_Numero_child )
{
    var roles_Cata =  Roles_CataModel.LoadByEntityKey(role_Numero_child.ToString());
            
    ViewBag.MasterProperty = "Roles_Niveles_Cata_Roles_Cata";
    ViewBag.Name = "EditRoles_Cata";
    ViewBag.IsNew = false;

    return PartialView("~/Views/Roles_Cata/PopUp.cshtml", roles_Cata);
}

[HttpPost]
public virtual ActionResult EditRolesCata(Roles_CataModel roles_Cata)
{
    if (ModelState.IsValid)
    {
        //Campos Auditorias
        roles_Cata.Registro_Fecha = DateTime.Now;
        roles_Cata.Registro_Usuario = User.Identity.Name;
        roles_Cata.Save();

        return new HttpStatusCodeResult(200);
    }
    return new HttpStatusCodeResult(500);
}

[HttpPost]
public virtual ActionResult DeleteRolesCata(int role_Nivel_Numero_parent, int role_Numero_child ){
    var roles_Cata = Roles_CataModel.LoadByEntityKey(role_Numero_child.ToString());
       if (roles_Cata.Delete())
       {
          return Json(new { cssMainClass = "success", title = Messages.GetOrSetMensaje("MENSAJE_OPERACION_REALIZDA_SASTIFACTORIAMENTE_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }
       else
       {
          return Json(new { cssMainClass = "warning", title = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER"), body = Messages.GetOrSetMensaje("MENSAJE_NOTIFICACION_REGISTRO_NO_BORRADO") }, JsonRequestBehavior.AllowGet);
       }

}

public virtual ActionResult ReportRolesCata(int role_Nivel_Numero){
    var roles_Cata = Roles_Niveles_CataModel.LoadByEntityKey(role_Nivel_Numero.ToString());            
    return new CsvReportResult("Roles_Cata", roles_Cata.RolesCata);
}

		 
 
		#endregion 
 
		#region Details 
 

		 
 
		#endregion 

	} 
} 


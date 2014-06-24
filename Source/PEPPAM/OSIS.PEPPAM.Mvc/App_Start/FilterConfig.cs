using System.Web;
using System.Web.Mvc;
using OSIS.PEPPAM.Mvc.Infrastructure;

namespace OSIS.PEPPAM.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Uncomment this line to make this application private:
             //filters.Add(new AuthorizeAttribute());            

           // filters.Add(new CustomAuthorizeAttribute());            
        }

    }
}
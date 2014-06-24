using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace System.Web.Mvc
{
    public static class ViewExtensions
    {
        public static MvcHtmlString MyValidationSummary(this HtmlHelper html, bool addSumaryToo = false, string validationMessage = "")
        {
            if (!html.ViewData.ModelState.IsValid)
            {
                var msg = string.Empty;
                msg += "<div class='validation-summary-errors'>";
                msg += string.Format("<span ><b> {0}</b></span >", validationMessage);
                msg += "<ul>";
                foreach (var key in html.ViewData.ModelState.Keys.Where(x => x == "" || addSumaryToo))
                {
                    foreach (var err in html.ViewData.ModelState[key].Errors)
                        msg += "<li><p>" + html.Raw(err.ErrorMessage) + "</p></li>";
                }
                msg += "</ul>";
                msg += "</div>";

               // return msg;

                return new MvcHtmlString(HttpUtility.HtmlDecode(msg.ToString()));
            }

            return null;
        }
    }
}
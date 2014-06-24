using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OSIS.PEPPAM.Mvc.Extensions.ModelBinders;

namespace OSIS.PEPPAM.Mvc
{
    public class BinderConfig
    {
        public static void RegisterModelBinders()
        {
            // Numeric model binders (for decimal and group separators globalization)
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(decimal), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(decimal?), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(double), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(double?), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Single), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Single?), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Int16), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Int16?), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Int32), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Int32?), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Int64), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Int64?), new NumericModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());
        }
    }
}
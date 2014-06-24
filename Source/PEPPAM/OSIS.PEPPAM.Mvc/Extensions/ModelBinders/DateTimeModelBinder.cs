using System;
using System.Globalization;
using System.Web.Mvc;

namespace OSIS.PEPPAM.Mvc.Extensions.ModelBinders
{
    public partial class DateTimeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                if (valueResult != null && !string.IsNullOrEmpty(valueResult.AttemptedValue))
                {
                    var dateFormat = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en" ? "MM/dd/yyyy" : "dd/MM/yyyy";
                    DateTimeFormatInfo dtfi = CultureInfo.CurrentCulture.DateTimeFormat;
                    dtfi.DateSeparator = "/";
                    dtfi.ShortDatePattern = dateFormat;
                    actualValue = DateTime.Parse(valueResult.AttemptedValue, dtfi);
                }
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }
            catch (OverflowException oe)
            {
                modelState.Errors.Add(oe);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}
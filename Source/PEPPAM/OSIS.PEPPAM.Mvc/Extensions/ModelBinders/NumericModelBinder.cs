using System;
using System.Web.Mvc;
using System.Globalization;

namespace OSIS.PEPPAM.Mvc.Extensions.ModelBinders
{
    public partial class NumericModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                if (valueResult != null && !string.IsNullOrEmpty(valueResult.AttemptedValue))
                {
                    if (bindingContext.ModelType == typeof(decimal) || bindingContext.ModelType == typeof(decimal?))
                    {
                        actualValue = decimal.Parse(valueResult.AttemptedValue, NumberStyles.Number, CultureInfo.CurrentCulture);
                    }
                    else if (bindingContext.ModelType == typeof(double) || bindingContext.ModelType == typeof(double?))
                    {
                        actualValue = double.Parse(valueResult.AttemptedValue, NumberStyles.Number, CultureInfo.CurrentCulture);
                    }
                    else if (bindingContext.ModelType == typeof(Single) || bindingContext.ModelType == typeof(Single?))
                    {
                        actualValue = Single.Parse(valueResult.AttemptedValue, NumberStyles.Number, CultureInfo.CurrentCulture);
                    }
                    else if (bindingContext.ModelType == typeof(Int16) || bindingContext.ModelType == typeof(Int16?))
                    {
                        actualValue = Int16.Parse(valueResult.AttemptedValue, NumberStyles.Number, CultureInfo.CurrentCulture);
                    }
                    else if (bindingContext.ModelType == typeof(Int32) || bindingContext.ModelType == typeof(Int32?))
                    {
                        actualValue = Int32.Parse(valueResult.AttemptedValue, NumberStyles.Number, CultureInfo.CurrentCulture);
                    }
                    else if (bindingContext.ModelType == typeof(Int64) || bindingContext.ModelType == typeof(Int64?))
                    {
                        actualValue = Int64.Parse(valueResult.AttemptedValue, NumberStyles.Number, CultureInfo.CurrentCulture);
                    }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using OSIS.PEPPAM.Mvc.Extensions.Helpers;
using OSIS.PEPPAM.Mvc.Models.Shared;


namespace OSIS.PEPPAM.Mvc.Extensions.ModelBinders
{
    public class DataTablesGridRequestModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var gridRequest = new GridRequestViewModel();

            gridRequest.RowStartIndex = GetValueOrDefault<int>(bindingContext, "iDisplayStart");
            gridRequest.RowCount = GetValueOrDefault<int>(bindingContext, "iDisplayLength");
            gridRequest.GridCustomData = GetStringOrEmpty(bindingContext, "sEcho");
            gridRequest.Search = GetStringOrEmpty(bindingContext, "sSearch");
            var columnNames = GetStringOrEmpty(bindingContext, "sColumns").Split(',');
            var sortColumnIndex = GetValueOrDefault<int>(bindingContext, "iSortCol_0");
            var sortDir = GetStringOrEmpty(bindingContext, "sSortDir_0").ToLower();

            gridRequest.SortColumnName = sortColumnIndex >= 0 && sortColumnIndex < columnNames.Length ? columnNames[sortColumnIndex] : null;
            gridRequest.SortDirection = sortDir == "asc" ? ListSortDirection.Ascending : ListSortDirection.Descending;

            return gridRequest;

        }

        private string GetStringOrEmpty(ModelBindingContext context, string name)
        {
            var valueProviderResult = context.ValueProvider.GetValue(name);
            return valueProviderResult == null ? string.Empty : valueProviderResult.AttemptedValue;
        }

        private T GetValueOrDefault<T>(ModelBindingContext context, string name)
        {
            var valueProviderResult = context.ValueProvider.GetValue(name);
            return valueProviderResult == null ? default(T) : (T)valueProviderResult.ConvertTo(typeof(T));
        }
    }
}
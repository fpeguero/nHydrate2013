using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OSIS.PEPPAM.Mvc.Extensions.ActionResults
{
    public class CsvReportResult : ActionResult
    {
        private const string Separator = ",";
        private readonly string _filename;
        private readonly IEnumerable<object> _data;

        public CsvReportResult(string filename, IEnumerable<object> data)
        {
            _filename = filename;
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ClearContent();
            response.AddHeader("content-disposition", "attachment; filename=" + _filename + ".csv");
            response.ContentType = "text/csv";
            if (_data.Any())
            {
                generateHeader(response, _data.First());
                foreach (var row in _data)
                {
                    generateRow(row, response);
                }
            }
            response.End();
        }

        private void generateHeader(HttpResponseBase response, object obj)
        {
            var properties = getProperties(obj);
            var columns = string.Join(Separator, properties.Select(p => p.Name));
            response.Write(columns + System.Environment.NewLine);
        }

        private void generateRow(object row, HttpResponseBase response)
        {
            var properties = getProperties(row);
            var columns = string.Join(Separator, properties.Select(p =>
            {
                return GetPropertyValue(row, p);
            }));

            response.Write(columns + System.Environment.NewLine);
        }

        private string GetPropertyValue(object row, PropertyInfo p)
        {
            var value = p.GetValue(row);
            string returnedValue = string.Empty;

            if (value != null)
            {
                returnedValue = value.ToString();

                if (p.PropertyType == typeof(string))
                {
                    returnedValue = returnedValue.Replace("\"", "\"\"");
                }

                returnedValue = string.Format("\"{0}\"", returnedValue);
            }

            return returnedValue;
        }

        private IEnumerable<PropertyInfo> getProperties(object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

    }
}
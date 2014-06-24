using System.Web.Mvc;
using OSIS.PEPPAM.Mvc.Extensions.ModelBinders;

namespace OSIS.PEPPAM.Mvc.Models.Shared
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    [ModelBinder(typeof(DataTablesGridRequestModelBinder))]
    public class GridRequestViewModel
    {
        /// <summary>
        /// Zero-based row start index
        /// </summary>
        public int RowStartIndex { get; set; }

        /// <summary>
        /// Number of rows to return
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Number of Total rows to paging
        /// </summary>
        public int RowCountTotal { get; set; }

        /// <summary>
        /// Sort column name
        /// </summary>
        public string SortColumnName { get; set; }

        /// <summary>
        /// Sort direction (ascending | descending)
        /// </summary>
        public System.ComponentModel.ListSortDirection SortDirection { get; set; }

        /// <summary>
        /// Current search string
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Custom data sent by the grid (optional)
        /// </summary>
        public string GridCustomData { get; set; }
    }
}
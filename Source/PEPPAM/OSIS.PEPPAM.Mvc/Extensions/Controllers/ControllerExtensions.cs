using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSIS.PEPPAM.Mvc.Extensions.Controllers
{
    public static class ControllerExtensions
    {
        //SearchValue
        public static string GetSearchValue(this Controller controller)
        {
            string sessionKey = string.Concat(controller.GetType().Name, "_SearchValue");
            return GetSearchValue(controller, sessionKey);
        }

        public static string GetSearchValue(this Controller controller, string sessionKey)
        {
            if (controller.Session[sessionKey] == null)
                controller.Session[sessionKey] = string.Empty;
            return controller.Session[sessionKey].ToString();
        }

        public static void SetSearchValue(this Controller controller, string searchValue)
        {
            string sessionKey = string.Concat(controller.GetType().Name, "_SearchValue");
            SetSearchValue(controller, sessionKey, searchValue);
        }

        public static void SetSearchValue(this Controller controller, string sessionKey, string searchValue)
        {
            controller.Session[sessionKey] = searchValue;
        }

        //OrderBy
        //public static OrderBy GetOrderBy(this Controller controller)
        //{
        //    string sessionKey = string.Concat(controller.GetType().Name, "_OrderBy");
        //    return GetOrderBy(controller, sessionKey);
        //}

        //public static OrderBy GetOrderBy(this Controller controller, string sessionKey)
        //{
        //    if (controller.Session[sessionKey] == null)
        //        controller.Session[sessionKey] = new OrderBy("", true);
        //    return controller.Session[sessionKey] as OrderBy;
        //}

        //public static void SetOrderBy(this Controller controller, OrderBy orderBy)
        //{
        //    string sessionKey = string.Concat(controller.GetType().Name, "_OrderBy");
        //    SetOrderBy(controller, sessionKey, orderBy);
        //}

        //public static void SetOrderBy(this Controller controller, string sessionKey, OrderBy orderBy)
        //{
        //    controller.Session[sessionKey] = orderBy;
        //}


        //PageIndex
        public static int GetPageIndex(this Controller controller)
        {
            string sessionKey = string.Concat(controller.GetType().Name, "_PageIndex");
            return GetPageIndex(controller, sessionKey);
        }

        public static int GetPageIndex(this Controller controller, string sessionKey)
        {
            if (controller.Session[sessionKey] == null)
                controller.Session[sessionKey] = 1;
            return Convert.ToInt32(controller.Session[sessionKey]);
        }

        public static void SetPageIndex(this Controller controller, int pageIndex)
        {
            string sessionKey = string.Concat(controller.GetType().Name, "_PageIndex");
            SetPageIndex(controller, sessionKey, pageIndex);
        }

        public static void SetPageIndex(this Controller controller, string sessionKey, int pageIndex)
        {
            controller.Session[sessionKey] = pageIndex;
        }


        //PageSize
        public static int GetPageSize(this Controller controller)
        {
            string sessionKey = string.Concat(controller.GetType().Name, "_PageSize");
            return GetPageSize(controller, sessionKey);
        }

        public static int GetPageSize(this Controller controller, string sessionKey)
        {
            if (controller.Session[sessionKey] == null)
                controller.Session[sessionKey] = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            return Convert.ToInt32(controller.Session[sessionKey]);
        }

        public static void SetPageSize(this Controller controller, int pageSize)
        {
            string sessionKey = string.Concat(controller.GetType().Name, "_PageSize");
            SetPageSize(controller, sessionKey, pageSize);
        }

        public static void SetPageSize(this Controller controller, string sessionKey, int pageSize)
        {
            controller.Session[sessionKey] = pageSize;
        }

        //Entity
        public static TEntity GetEntity<TEntity>(this Controller controller, int id)
        {
            string sessionKey = string.Format("{0}_{1}_{2}", controller.GetType().Name, typeof(TEntity).Name, id.ToString());
            return GetEntity<TEntity>(controller, sessionKey);
        }

        public static TEntity GetEntity<TEntity>(this Controller controller, string sessionKey)
        {
            if (controller.Session[sessionKey] == null)
                return default(TEntity);
            return (TEntity)controller.Session[sessionKey];
        }

        public static void SetEntity<TEntity>(this Controller controller, TEntity entity, int id)
        {
            string sessionKey = string.Format("{0}_{1}_{2}", controller.GetType().Name, typeof(TEntity).Name, id.ToString());
            SetEntity(controller, sessionKey, entity);
        }

        public static void SetEntity<TEntity>(this Controller controller, string sessionKey, TEntity entity)
        {
            controller.Session[sessionKey] = entity;
        }

        public static void ClearEntity<TEntity>(this Controller controller, int id)
        {
            string sessionKey = string.Format("{0}_{1}_{2}", controller.GetType().Name, typeof(TEntity).Name, id.ToString());
            ClearEntity(controller, sessionKey);
        }

        public static void ClearEntity(this Controller controller, string sessionKey)
        {
            controller.Session.Remove(sessionKey);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XrmLite.Controllers;
using XrmLite.Models;

namespace XrmLite.Helpers
{
    public static class HtmlHelpers
    {
        public static string Id(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("id"))
                return (string)routeValues["id"];
            else if (HttpContext.Current.Request.QueryString.AllKeys.Contains("id"))
                return HttpContext.Current.Request.QueryString["id"];

            return string.Empty;
        }

        public static string Controller(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("controller"))
                return (string)routeValues["controller"];

            return string.Empty;
        }

        public static string Action(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("action"))
                return (string)routeValues["action"];

            return string.Empty;
        }


        public static Type ModelType(this HtmlHelper htmlHelper)
        {            
            return ((BaseController)htmlHelper.ViewContext.Controller).ModelType;
        }

        public static SelectList GetPickList(this HtmlHelper htmlHelper, string fieldPrefix, string selectedValue)
        {
            var modelType = ((BaseController)htmlHelper.ViewContext.Controller).ModelType;

            DatabaseContext DB = new DatabaseContext();

            PickListValue pickListValue = DB.PickListValues.FirstOrDefault(x => x.ModelType == modelType.Name && x.FieldName == fieldPrefix);
            string[] valueList = (pickListValue == null ? new string[0] { } : pickListValue.Values.Split(';'));

            return new SelectList(valueList, selectedValue);
        }

    }
}
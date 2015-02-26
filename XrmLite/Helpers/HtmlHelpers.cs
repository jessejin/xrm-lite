using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XrmLite.Controllers;
using XrmLite.Models;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations.Schema;

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

        public static BaseModel GetDBRecord(Type modelType, int id)
        {
            DatabaseContext DB = new DatabaseContext();            
            return (BaseModel)DB.Set(modelType).Find(id);
        }


        public static string GetXrmDisplayName(this HtmlHelper htmlHelper, Type modelType, int? id)
        {
            if (id == null) return null;
            BaseModel record = GetDBRecord(modelType, id.Value);
            return record.DisplayName;
        }

        public static string GetXrmControllerName(this HtmlHelper htmlHelper, Type modelType)
        {
            return modelType.Name;
        }

        public static string GetXrmAreaName(this HtmlHelper htmlHelper, Type modelType)
        {
            string areaName = modelType.FullName.Split('.')[1];
            if (areaName == "Models") areaName = "";
            return areaName;
        }

        public static MvcHtmlString XrmRecordLink(this HtmlHelper htmlHelper, Type containerType, string fieldPrefix, int id)
        {
            Type modelType = htmlHelper.GetTypeForField(containerType, fieldPrefix);
            BaseModel record = GetDBRecord(modelType, id);
            return htmlHelper.ActionLink(record.DisplayName, "Read", htmlHelper.GetXrmControllerName(modelType), new { area = htmlHelper.GetXrmAreaName(modelType), id = id }, null);
        }


        public static string[] GetPickListValues(string modelType, string fieldPrefix)
        {
            DatabaseContext DB = new DatabaseContext();
            PickListValue pickListValue = DB.PickListValues.FirstOrDefault(x => x.ModelType == modelType && x.FieldName == fieldPrefix);
            string[] valueList = (pickListValue == null ? new string[0] { } : pickListValue.Values.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
            return valueList;
        }

        public static SelectList GetPickList(this HtmlHelper htmlHelper, string fieldPrefix, string selectedValue)
        {
            var modelType = ((BaseController)htmlHelper.ViewContext.Controller).ModelType;
            string[] valueList = GetPickListValues(modelType.Name, fieldPrefix);
            return new SelectList(valueList, selectedValue);
        }


        public static Type GetTypeForField(this HtmlHelper htmlHelper, Type containerType, string fieldPrefix)
        {

            var field = containerType.GetProperties().FirstOrDefault(p =>  p.IsDefined(typeof(ForeignKeyAttribute), false) &&             
                                             ((ForeignKeyAttribute[])p.GetCustomAttributes(typeof(ForeignKeyAttribute), false)).Any(a => a.Name == fieldPrefix));

            if (field == null) throw new Exception("No table is found for this lookup.");
            return field.PropertyType;
        }

        public static MultiSelectList GetMultiPickList(this HtmlHelper htmlHelper, string fieldPrefix, string selectedValue)
        {
            var modelType = ((BaseController)htmlHelper.ViewContext.Controller).ModelType;
            string[] selectedValues = (selectedValue == null ? null : selectedValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            string[] valueList = GetPickListValues(modelType.Name, fieldPrefix);
            return new MultiSelectList(valueList, selectedValues);
        }

    }
}
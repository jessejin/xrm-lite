using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XrmLite.Controllers;
using XrmLite.Models;

namespace XrmLite.Helpers
{
    public static class XrmHelpers
    {

        public static string RemoveNonDigits(string s)
        {
            if (s == null) return null;
            else return System.Text.RegularExpressions.Regex.Replace(s, "\\D", "");
        }
    }
}
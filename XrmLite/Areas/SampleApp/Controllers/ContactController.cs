using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XrmLite.SampleApp.Models;

namespace XrmLite.Areas.SampleApp.Controllers
{
    public class ContactController : XrmLite.Controllers.BaseController
    {
        public ContactController() : base(typeof(Contact)) { }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XrmLite.Models;

namespace XrmLite.Controllers
{
    public class BaseController : Controller
    {
        public Type ModelType;

        private DatabaseContext _DB;
        public DatabaseContext DB
        {
            get
            {
                if (_DB == null)
                {
                    _DB = new DatabaseContext();
                    return _DB;
                }
                else return _DB;
            }
        }


        private UserManager<XrmUser> _UserManager;
        public UserManager<XrmUser> UserManager
        {
            get
            {
                if (_UserManager == null)
                {
                    _UserManager = new UserManager<XrmUser>(new UserStore<XrmUser>(DB));
                    return _UserManager;
                }
                else return _UserManager;
            }
        }

        public BaseController(Type type)
        {
            ModelType = type;
        }


        public virtual ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Items = DB.Set(ModelType);
            model.ModelDisplayName = ((dynamic)Activator.CreateInstance(ModelType)).ModelDisplayName;

            return View(model);
        }

        public virtual ActionResult Lookup()
        {
            return View(DB.Set(ModelType));
        }

        public virtual ActionResult Read(int id)
        {
            return View(DB.Set(ModelType).Find(id));
        }

        public virtual ActionResult ReadGuid(string id)
        {
            return View(DB.Set(ModelType).Find(id));
        }

        public virtual ActionResult Create()
        {
            dynamic model = Activator.CreateInstance(ModelType);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Create(FormCollection form)
        {
            dynamic model = Activator.CreateInstance(ModelType);
            TryUpdateModel(model, form);

            if (ModelState.IsValid)
            {
                DB.Set(ModelType).Add(model);
                DB.SaveChanges();
                return RedirectToAction("Read", new { id = model.Id });
            }
            return View(model);
        }

        public virtual ActionResult Edit(int id)
        {
            return View(DB.Set(ModelType).Find(id));
        }

        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection form)
        {
            dynamic model = DB.Set(ModelType).Find(id);
            if (ModelState.IsValid && TryUpdateModel(model, form))
            {
                DB.SaveChanges();
                return RedirectToAction("Read", new { id = model.Id });
            }
            return View(model);
        }


        public virtual ActionResult EditGuid(string id)
        {
            return View(DB.Set(ModelType).Find(id));
        }

        [HttpPost]
        public virtual ActionResult EditGuid(string id, FormCollection form)
        {
            dynamic model = DB.Set(ModelType).Find(id);
            if (ModelState.IsValid && TryUpdateModel(model, form))
            {
                DB.SaveChanges();
                return RedirectToAction("ReadGuid", new { id = model.Id });
            }
            return View(model);
        }

    }
}
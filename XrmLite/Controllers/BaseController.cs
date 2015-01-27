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
        private DatabaseContext DB
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

        public BaseController(Type type)
        {
            ModelType = type;
        }

        public ActionResult Index()
        {
            return View(DB.Set(ModelType));
        }

        public ActionResult Read(int id)
        {
            return View(DB.Set(ModelType).Find(id));
        }


        public ActionResult Edit(int id)
        {
            return View(DB.Set(ModelType).Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            dynamic model = DB.Set(ModelType).Find(id);
            if (ModelState.IsValid && TryUpdateModel(model, form))
            {
                DB.SaveChanges();
                return RedirectToAction("Read", new { id = model.Id });
            }
            return View(model);
        }

        public ActionResult Create()
        {
            dynamic model = Activator.CreateInstance(ModelType);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
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


    }
}
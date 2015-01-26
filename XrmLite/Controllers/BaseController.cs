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

        DatabaseContext DB = new DatabaseContext();


        public ActionResult Index()
        {
            return View(DB.Contacts.OrderBy(x=>x.Id));
        }

        public ActionResult Read(int id)
        {
            Contact c = DB.Contacts.FirstOrDefault(x => x.Id == id);
            return View(c);
        }


        public ActionResult Edit(int id)
        {
            Contact c = DB.Contacts.FirstOrDefault(x => x.Id == id);

            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            Contact c = DB.Contacts.FirstOrDefault(x => x.Id == id);

            if (ModelState.IsValid && TryUpdateModel(c, form))
            {
                DB.SaveChanges();
                return RedirectToAction("Read", new { id = c.Id });
            }
            return View(c);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Contact c = new Models.Contact();
            TryUpdateModel(c, form);

            if (ModelState.IsValid)
            {
                c.CreatedDate = DateTime.Now;
                c.CreatedBy = User.Identity.Name;
                DB.Contacts.Add(c);
                DB.SaveChanges();
                return RedirectToAction("Read", new { id = c.Id });
            }
            return View(c);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
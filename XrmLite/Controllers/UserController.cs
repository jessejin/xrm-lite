using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XrmLite.Models;

namespace XrmLite.Controllers
{
    public class UserController : BaseController
    {

        public UserController() : base(typeof(XrmUser)) { }

        public override ActionResult Create()
        {
            return View();
        }


        public ActionResult List()
        {
            return PartialView(DB.Users);
        }


        //
        // POST: /Users/Create
        [HttpPost]
        public override ActionResult Create(FormCollection form)
        {
            RegisterViewModel userViewModel = new RegisterViewModel();
            TryUpdateModel(userViewModel, form);

            if (ModelState.IsValid)
            {
                var user = new XrmUser();
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;

                var adminresult = UserManager.Create(user, userViewModel.Password);

                //Add User Admin to Role Admin
                if (!adminresult.Succeeded)
                {
                    ModelState.AddModelError("", adminresult.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("ReadGuid", new {id = user.Id });
            }
            return View();
        }

    }
}
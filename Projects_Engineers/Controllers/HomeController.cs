using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projects_Engineers_BusinessRule;
using Projects_Engineers_Data;

namespace Projects_Engineers.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataAccessSQL<PE_User> contextUser;
        private UserManager obj;
        private Projects_Engineers_Data.Projects_Engineers db = new Projects_Engineers_Data.Projects_Engineers();

        public HomeController()
        {
            contextUser = new DataAccessSQL<PE_User>(new Projects_Engineers_Data.Projects_Engineers());
            obj = new UserManager(contextUser);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Users";

            return View();
        }

        public ActionResult EngineersLocation()
        {
            ViewBag.Message = "Engineers Location";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page.";

            return View();
        }

        [ValidateInput(false)]
        public ActionResult IntelligratedEngineersPartialView()
        {
            //var model = db.PE_User;
            var model = obj.readUsers();
            return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IntelligratedEngineersPartialViewAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Projects_Engineers_Data.PE_User item)
        {
            var model = db.PE_User;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IntelligratedEngineersPartialViewUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Projects_Engineers_Data.PE_User item)
        {
            var model = db.PE_User;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IntelligratedEngineersPartialViewDelete(System.Int32 Id)
        {
            var model = db.PE_User;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult IntelligratedEngineersLocationPartialView()
        {
            //var model = db.PE_User;
            var model = obj.readUsers();
            return PartialView("_IntelligratedEngineersLocationPartialView", model.ToList());
        }
    }
}
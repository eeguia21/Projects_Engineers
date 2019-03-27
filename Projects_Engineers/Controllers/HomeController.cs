using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects_Engineers.Controllers
{
    public class HomeController : Controller
    {

        Projects_Engineers_Data.Projects_Engineers db = new Projects_Engineers_Data.Projects_Engineers();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Intelligrated Engineers";

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
            var model = db.PE_User;
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
                    var modelItem = model.FirstOrDefault(it => it.Id_User == item.Id_User);
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
        public ActionResult IntelligratedEngineersPartialViewDelete(System.Int32 Id_User)
        {
            var model = db.PE_User;
            if (Id_User >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id_User == Id_User);
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
    }
}
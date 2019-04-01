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
        private UserManager objUM;

        private readonly DataAccessSQL<PE_CApplicationRole> contextApplicationRole;
        private ApplicationRoleManager objARM;

        private readonly DataAccessSQL<PE_CJobTitle> contextJobTitle;
        private JobTitleManager objJTM;

        private readonly DataAccessSQL<PE_CDepartment> contextDepartment;
        private DepartmentManager objDM;

        private readonly DataAccessSQL<PE_CCountry> contextCountry;
        private CountryManager objCoM;

        private readonly DataAccessSQL<PE_CState> contextState;
        private StateManager objSM;

        private readonly DataAccessSQL<PE_CCity> contextCity;
        private CityManager objCiM;

        private readonly DataAccessSQL<PE_UserLocation> contextUserLocation;
        private UserLocationManager objULM;

        public HomeController()
        {
            contextUser = new DataAccessSQL<PE_User>(new Projects_Engineers_Data.Projects_Engineers());
            objUM = new UserManager(contextUser);

            contextApplicationRole = new DataAccessSQL<PE_CApplicationRole>(new Projects_Engineers_Data.Projects_Engineers());
            objARM = new ApplicationRoleManager(contextApplicationRole);

            contextJobTitle = new DataAccessSQL<PE_CJobTitle>(new Projects_Engineers_Data.Projects_Engineers());
            objJTM = new JobTitleManager(contextJobTitle);

            contextDepartment = new DataAccessSQL<PE_CDepartment>(new Projects_Engineers_Data.Projects_Engineers());
            objDM = new DepartmentManager(contextDepartment);

            contextCountry = new DataAccessSQL<PE_CCountry>(new Projects_Engineers_Data.Projects_Engineers());
            objCoM = new CountryManager(contextCountry);

            contextState = new DataAccessSQL<PE_CState>(new Projects_Engineers_Data.Projects_Engineers());
            objSM = new StateManager(contextState);

            contextCity = new DataAccessSQL<PE_CCity>(new Projects_Engineers_Data.Projects_Engineers());
            objCiM = new CityManager(contextCity);

            contextUserLocation = new DataAccessSQL<PE_UserLocation>(new Projects_Engineers_Data.Projects_Engineers());
            objULM = new UserLocationManager(contextUserLocation);
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
            var model = objUM.readUsers();
            return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        }

        //[HttpPost, ValidateInput(false)]
        //public ActionResult IntelligratedEngineersPartialViewAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Projects_Engineers_Data.PE_User item)
        //{
        //    var model = db.PE_User;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            model.Add(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        //}

        //[HttpPost, ValidateInput(false)]
        //public ActionResult IntelligratedEngineersPartialViewUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Projects_Engineers_Data.PE_User item)
        //{
        //    var model = db.PE_User;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
        //            if (modelItem != null)
        //            {
        //                this.UpdateModel(modelItem);
        //                db.SaveChanges();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        //}

        //[HttpPost, ValidateInput(false)]
        //public ActionResult IntelligratedEngineersPartialViewDelete(System.Int32 Id)
        //{
        //    var model = db.PE_User;
        //    if (Id >= 0)
        //    {
        //        try
        //        {
        //            var item = model.FirstOrDefault(it => it.Id == Id);
        //            if (item != null)
        //                model.Remove(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        //}

        [ValidateInput(false)]
        public ActionResult IntelligratedEngineersLocationPartialView()
        {
            var model = objUM.readUsers();
            return PartialView("_IntelligratedEngineersLocationPartialView", model.ToList());
        }
    }
}
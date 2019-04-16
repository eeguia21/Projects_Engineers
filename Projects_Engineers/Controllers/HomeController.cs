using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projects_Engineers_BusinessRule;
using Projects_Engineers_Data;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml.Linq;

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
            PE_User usr = objUM.readUser(8);
            string password = "";
            string passwordConfirmation = "";

            objUM.deleteUser(82);

            PE_User usrNew = new PE_User()
            {
                Id_Honeywell = "H293576",
                Name = "Eguia, Edgar ",
                Id_Department = 1,
                Id_JobTitle = 4,
                Id_ApplicationRole = 1,
                Id_ImmediateSuperior = 53,
                Mobile = "00000000",
                Email = "edgar.eguiacalcaneo@honeywell.com"
            };
            password = "edgar.eguiacalcaneo@honeywell.com";
            passwordConfirmation = "edgar.eguiacalcaneo@honeywell.com";
            if (password.Equals(passwordConfirmation))
                objUM.addUser(usrNew, password);

            usrNew.Mobile = "5567762533";
            objUM.updateUser(usrNew);

            var model = objUM.readUsers();
            return PartialView("_IntelligratedEngineersPartialView", model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult IntelligratedEngineersLocationPartialView()
        {
            var model = objUM.readUsers();
            return PartialView("_IntelligratedEngineersLocationPartialView", model.ToList());
        }

        public ActionResult RssFeed()
        {
            var feedData = (from usr in objUM.readUsers()
                            select new PE_User
                            {
                                Id_Honeywell = usr.Id_Honeywell,
                                Name = usr.Name
                            });
            ViewBag.RSSFeed = feedData.ToList();
            return View();
        }
    }
}
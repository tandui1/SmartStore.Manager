using SmartStore.Manager.App.SSO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamrtStore.Test.Controllers
{
    public class HomeController : Controller
    {
        // private string _appKey = ConfigurationManager.AppSettings["SSOAppKey"];
        // GET: Login
        [SSOAuth]
        public ActionResult Index()
        {
            var currentUser = AuthUtil.GetCurrentUser();
            ViewBag.CurrentUser = currentUser;
            return View();
         
        }

        public ActionResult AdminIndex()
        {
            return Redirect(ConfigurationManager.AppSettings["OpenAuthURL"] + "?token=" + Request.Cookies["Token"].Value);
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
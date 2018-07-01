using SmartStore.Manager.App.SSO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamrtStore.Test.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private string _appKey = ConfigurationManager.AppSettings["SSOAppKey"];
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.AppKey = _appKey;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var result = AuthUtil.Login(_appKey, username, password);
            if (result.Success)
                return Redirect("/home/index?Token=" + result.Token);
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            AuthUtil.Logout();
            return Redirect("/Home/Index");
        }
    }
}
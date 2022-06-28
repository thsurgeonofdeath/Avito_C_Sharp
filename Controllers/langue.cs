using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace ASP_Projet.Controllers
{
    internal class langue:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Change(String Abv)
        {
            if(Abv != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Abv);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Abv);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = Abv;
            Response.Cookies.Add(cookie);

            return View("Index");
        }
    }
}
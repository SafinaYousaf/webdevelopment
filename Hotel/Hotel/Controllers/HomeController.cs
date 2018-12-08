using System;
using System.Web.Mvc;
using Hotel.Models;
using System.Configuration;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        public String constr = "Data Source=SAFINAYOUSAF\\SQLEXPRESS;Initial Catalog=Hotel;User ID=sa;Password=***********;MultipleActiveResultSets=True;Application Name=EntityFramework";

        string con = ConfigurationManager.ConnectionStrings["HotelEntities"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

       

        public ActionResult Login()
        {
            return View();
        }
    }
}
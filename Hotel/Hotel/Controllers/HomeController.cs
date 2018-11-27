using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Hotel.Models;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity.Validation;

using System.Net;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        public String constr = "Data Source=ELITEBOOKHP;Initial Catalog=PhoneBookDb;User ID=sa;Password=***********";

        string con = ConfigurationManager.ConnectionStrings["HotelEntities1"].ConnectionString;
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
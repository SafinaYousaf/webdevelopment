using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hotel;
using Hotel.Models;

namespace Hotel.Controllers
{
    
    public class GeneralsController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: Generals
        public ActionResult Index()
        {
            return View(db.Generals.ToList());
        }

        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult user()
        {
            return View();
        }
        public ActionResult feedback()
        {
            return View();
        }
        public ActionResult favourites()
        {
            return View();
        }
        public ActionResult map()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        // GET: Generals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General general = db.Generals.Find(id);
            if (general == null)
            {
                return HttpNotFound();
            }
            return View(general);
        }

        // GET: Generals/Create
        public ActionResult Dashboard()
        {
            return View();
        }

        

        

        // POST: Generals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "ID,Name,Email,Password,ConfirmPassword,Type")] General general)
        {
            try
            {
                //check if email already exist

                General user = db.Generals.FirstOrDefault(u => u.Email == (general.Email));
                //user will not be null if current entered email is presenyt in database
                if (user != null)
                    ModelState.AddModelError("Email", "This Email was already taken");
                //sucessfull signup procedure
                if (ModelState.IsValid && user == null)
                {
                    db.Generals.Add(general);
                    db.SaveChanges();
                    //after saving data in database
                    //we check for type of user and direct it to respective database
                    if(general.Type == "Admin")
                        return RedirectToAction("AdminDash", "HotelDatas");
                    if (general.Type == "HotelManager")
                    {
                        // first add hotel by hotel manger then hotelmanger will able to see dashboard
                        return RedirectToAction("AddHotel1", "HotelDatas");
                    }
                    if (general.Type == "User")
                        return RedirectToAction("Dashboard");
                }
            }

            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(general);
        }

        // GET: Generals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General general = db.Generals.Find(id);
            if (general == null)
            {
                return HttpNotFound();
            }
            return View(general);
        }

        // POST: Generals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Password,ConfirmPassword,Type")] General general)
        {
            if (ModelState.IsValid)
            {
                db.Entry(general).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(general);
        }

        // GET: Generals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General general = db.Generals.Find(id);
            if (general == null)
            {
                return HttpNotFound();
            }
            return View(general);
        }

        // POST: Generals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            General general = db.Generals.Find(id);
            db.Generals.Remove(general);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(General entity)
        {
            using (HotelEntities db = new HotelEntities())
            {
                //fetche the data of user on the basis of inserted email
                General user = db.Generals.FirstOrDefault(u => u.Email == (entity.Email));
                //if entered email is not bound to any user then object will be null
                if (user == null)
                {
                    TempData["ErrorMSG"] = "object not found";
                    return View(entity);

                }
                //if we are here then it mean we sucsessfuly retrived the data
                //now we compare password
                int a = entity.Password.Count();
                if (user.Password.Substring(0, a) != entity.Password)
                {
                    TempData["ErrorMSG"] = "Password not matched";
                    return View(entity);

                }

                if (user != null)
                {

                    if (user.Password.Substring(0, a) == entity.Password)
                    {


                        if (user.Type.Substring(0, 5) == "Admin")
                            return RedirectToAction("AdminDash", "HotelDatas");
                        if (user.Type.Substring(0, 12) == "HotelManager")
                        {

                            // first add hotel by hotel manger then hotelmanger will able to see dashboard
                            return RedirectToAction("AddHotel1", "HotelDatas");
                        }
                        if (user.Type.Substring(0, 4) == "User")
                            return RedirectToAction("Dashboard");
                    }
                    return View();
                }
                return View();
            }
        }
        //Logout//
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AdminDash()
        {
            return View(db.HotelDatas.ToList());
        }
        public ActionResult Delete()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

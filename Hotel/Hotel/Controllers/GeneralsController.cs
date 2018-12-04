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

        public ActionResult HotelDash()
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


                General user = db.Generals.FirstOrDefault(u => u.Email == (general.Email));
                if (user != null)
                    ModelState.AddModelError("Email", "This Email was already taken");
                if (ModelState.IsValid && user == null)
                {
                    db.Generals.Add(general);
                    db.SaveChanges();
                    if(general.Type == "Admin")
                        return RedirectToAction("AdminDash", "HotelDatas");
                    if (general.Type == "HotelManager")
                        return RedirectToAction("HotelDash");
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
                General user = db.Generals.FirstOrDefault(u => u.Email == (entity.Email));
                if (user == null)
                {
                    TempData["ErrorMSG"] = "object not found";
                    return View(entity);

                }
                
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
                            return RedirectToAction("HotelDash");
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
        //AddHotel
        public ActionResult AddHotel()
        {
            
            return View();
        }
        //Edit hotel
        public ActionResult HotelEdit()
        {
            
            return View("HotelEdit", "HotelDatas");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHotel([Bind(Include = "HotelID,HotelName,Ratings,Category,FreeWifi,PriceRangeUpper, PriceRangeLower,RoomAvailable,SwimmingPool,CarPark,FreeBreakfast,PrivateParking, PlayLand,About")] HotelData Hotelobj)
        {
            try
            {


                
                if (ModelState.IsValid )
                {
                    db.HotelDatas.Add(Hotelobj);
                    db.SaveChanges();
                   
                }
            }

            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(Hotelobj);
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

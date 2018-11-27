using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel;

namespace Hotel.Controllers
{
    public class GeneralsController : Controller
    {
        private HotelEntities1 db = new HotelEntities1();

        // GET: Generals
        public ActionResult Index()
        {
            return View(db.Generals.ToList());
        }

        public ActionResult SignUp()
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

        public ActionResult AdminDash()
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

                if (ModelState.IsValid)
                {
                    db.Generals.Add(general);
                    db.SaveChanges();
                    if(general.Type == "Admin")
                        return RedirectToAction("AdminDash");
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

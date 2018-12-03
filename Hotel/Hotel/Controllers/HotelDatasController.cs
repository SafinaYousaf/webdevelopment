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
    public class HotelDatasController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: HotelDatas
        public ActionResult Index()
        {
            return View(db.HotelDatas.ToList());
        }

        public ActionResult AdminDash()
        {
            return View();
        }

        public ActionResult AddHotel()
        {
            return View();
        }

        // GET: HotelDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelData hotelData = db.HotelDatas.Find(id);
            if (hotelData == null)
            {
                return HttpNotFound();
            }
            return View(hotelData);
        }

        // GET: HotelDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotelID,HotelName,Ratings,Category,FreeWifi,PriceRangeUpper,PriceRangeLower,RoomAvailable,SwimmingPool,CarPark,FreeBreakfast,PrivateParking,PlayLand")] HotelData hotelData)
        {
            if (ModelState.IsValid)
            {
                db.HotelDatas.Add(hotelData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelData);
        }

        // GET: HotelDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelData hotelData = db.HotelDatas.Find(id);
            if (hotelData == null)
            {
                return HttpNotFound();
            }
            return View(hotelData);
        }

        // POST: HotelDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotelID,HotelName,Ratings,Category,FreeWifi,PriceRangeUpper,PriceRangeLower,RoomAvailable,SwimmingPool,CarPark,FreeBreakfast,PrivateParking,PlayLand")] HotelData hotelData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelData);
        }

        // GET: HotelDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelData hotelData = db.HotelDatas.Find(id);
            if (hotelData == null)
            {
                return HttpNotFound();
            }
            return View(hotelData);
        }

        // POST: HotelDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelData hotelData = db.HotelDatas.Find(id);
            db.HotelDatas.Remove(hotelData);
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

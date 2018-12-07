using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class HotelDatasController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: HotelDatas
        public ActionResult AdminDash()
        {
            return View(db.HotelDatas.ToList());
        }



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
        public ActionResult AddHotel([Bind(Include = "HotelID,HotelName,Ratings,Category,FreeWifi,PriceRangeUpper, PriceRangeLower,RoomAvailable,SwimmingPool,CarPark,FreeBreakfast,PrivateParking, PlayLand")] HotelData Hotelobj)
        {
            try
            {



                if (ModelState.IsValid)
                {
                    db.HotelDatas.Add(Hotelobj);
                    db.SaveChanges();
                    return RedirectToAction("AdminDash");
                }
            }

            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(Hotelobj);
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

        // ----for hoteldash
        public ActionResult HotelDash()
        {
           
            return View();
        }

        public ActionResult AddHotel1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHotel1([Bind(Include = "HotelID,HotelName,Ratings,Category,FreeWifi,PriceRangeUpper, PriceRangeLower,RoomAvailable,SwimmingPool,CarPark,FreeBreakfast,PrivateParking, PlayLand")] HotelData Hotelobj)
        {
            try
            {



                if (ModelState.IsValid)
                {
                    db.HotelDatas.Add(Hotelobj);
                    db.SaveChanges();
                    HotelStatic.Hotelid = Hotelobj.HotelID;
                    return RedirectToAction("HotelDash");
                }
            }

            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(Hotelobj);
        }

        public ActionResult EditHotel1()
        {
            int id = HotelStatic.Hotelid;
            HotelData hotelData = db.HotelDatas.Find(id);
            if (hotelData == null)
            {
                return HttpNotFound();
            }
            return View(hotelData);
            
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHotel1([Bind(Include = "HotelID,HotelName,Ratings,Category,FreeWifi,PriceRangeUpper,PriceRangeLower,RoomAvailable,SwimmingPool,CarPark,FreeBreakfast,PrivateParking,PlayLand")] HotelData hotelData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HotelDash");
            }
            return View(hotelData);
        }



        //----hoteldash

        // GET: HotelDatas/Edit/5
        public ActionResult EditHotel(int? id)
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
        public ActionResult EditHotel([Bind(Include = "HotelID,HotelName,Ratings,Category,FreeWifi,PriceRangeUpper,PriceRangeLower,RoomAvailable,SwimmingPool,CarPark,FreeBreakfast,PrivateParking,PlayLand")] HotelData hotelData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminDash");
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
            return RedirectToAction("AdminDash");
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

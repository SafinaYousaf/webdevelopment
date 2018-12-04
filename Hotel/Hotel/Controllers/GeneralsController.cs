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


                General user = db.Generals.FirstOrDefault(u => u.Email == (general.Email));
                if (user != null)
                    ModelState.AddModelError("Email", "This Email was already taken");
                if (ModelState.IsValid && user == null)
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
        /*Login code goes here*/
        //LOGIN//
        /*
        [HttpGet]
        public ActionResult Login(string returnURL)
        {
            var userinfo = new LoginVM();

            try
            {
                // We do not want to use any existing identity information
                EnsureLoggedOut();

                // Store the originating URL so we can attach it to a form field
                userinfo.ReturnURL = returnURL;

                return View(userinfo);
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM entity)
        {
            using (db = new HotelEntities1())
            {

                General general = db.Generals.Find(entity.Email);
                if(general == null)
                {
                    TempData["ErrorMSG"] = "object not found";
                }
                if (entity.Password != general.Password)
                {
                    TempData["ErrorMSG"] = "password not matched";
                }
                if (general != null && entity.Password == general.Password)
                {
                    if (general.Type == "Admin")
                    {
                        return RedirectToAction("AdminDash");
                    }
                    else
                    {
                        TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
                        return View(entity);
                    }
                }
                else
                {
                    TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
                    return View(entity);

                }

            }
        }
        //GET: EnsureLoggedOut
        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        //POST: Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                return RedirectToLocal();
            }
            catch
            {
                throw;
            }
        }
        //GET: RedirectToLocal
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site
                // so we will redirect to this "action"
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);

                // If we cannot verify if the url is local to our host we redirect to a default location
                return RedirectToAction("Index", "Dashboard");
            }
            catch
            {
                throw;
            }
        }
        */

        /*
    [HttpGet]
    public ActionResult Login(string returnURL)
    {
        var userinfo = new LoginVM();
        return View(userinfo);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginVM entity)
    {
        using (db = new HotelEntities1())
        {

            General general = db.Generals.Find(entity.Email);
            if (general == null)
            {
                TempData["ErrorMSG"] = "object not found";
            }
            if (entity.Password != general.Password)
            {
                TempData["ErrorMSG"] = "password not matched";
            }
            if (general != null && entity.Password == general.Password)
            {
                if (general.Type == "Admin")
                {
                    return RedirectToAction("AdminDash");
                }
                else
                {
                    TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
                    return View(entity);
                }
            }
            else
            {
                TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
                return View(entity);

            }

        }
    }
    


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(General entity)
        {
            using (HotelEntities1 db = new HotelEntities1())
            {
                General user = db.Generals.SingleOrDefault(u => u.Email == entity.Email);
                if( user== null)
                {
                    TempData["ErrorMSG"] = "object not found";
                    return View(entity);

                }
                Console.Write(user.Password);

                if(user.Password.ToString() != entity.Password.ToString())
                {
                    TempData["ErrorMSG"] = "Password not matched";
                    return View(entity);

                }

                if (user != null)
                {
                    if (user.Password.ToString() != entity.Password.ToString())
                    {
                        return RedirectToAction("AdminDash");
                    }
                    return View();
                }
                return View();
            }
        }
        */
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
                            return RedirectToAction("AdminDash");
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
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("HotelEdit", "HotelDatas");
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

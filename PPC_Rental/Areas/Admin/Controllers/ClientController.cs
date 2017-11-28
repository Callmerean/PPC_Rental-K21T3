using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;

namespace PPC_Rental.Areas.Admin.Controllers
{
    public class ClientController : Controller
    {
        // GET: Admin/Client
        DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                int x1 = (int)Session["UserID"];
                var property = db.PROPERTies.ToList().Where(x => x.UserID == x1);


                return View(property);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.USERs.FirstOrDefault(x => x.Email == username);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["FullName"] = user.FullName;
                    Session["UserId"] = user.ID;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.mgs = "tai khoang khong ton tai";
            }
            return View();
        }
        public ActionResult Logout(int id)
        {
            var user = db.USERs.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                Session["Fulname"] = null;
                Session["UserId"] = null;

            }
            return RedirectToAction("Login");
        }
    }
}
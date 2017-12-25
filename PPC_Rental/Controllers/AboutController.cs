using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;

namespace PPC_Rental.Controllers
{
    public class AboutController : Controller
    {
        DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();
        // GET: About
        public ActionResult About()
        {
            var news = db.ABOUTs.Find(1);
            return View(news);
            
        }
    }
}
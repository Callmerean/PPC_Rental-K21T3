using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;

namespace PPC_Rental.Controllers
{
    public class NewsController : Controller
    {
        DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();
            // GET: News
        public ActionResult News(int page = 1, int pageSize = 4)
        {
            var newsmodel = new DAO();
            
            var news = newsmodel.ListNewsPaging(page, pageSize);
            return View(news);
            

        }
        public ActionResult DetailNews(int id)
        {
            var news = db.NEWS.FirstOrDefault(x => x.ID == id);
            return View(news);
            
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;

namespace PPC_Rental.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> myDis, myType;
        DemoPPCRentalEntities1 model = new DemoPPCRentalEntities1();

        public ActionResult Index()
        {
            var property = model.PROPERTies.ToList().OrderByDescending(x => x.ID).Where(x => x.Status_ID == 3);

            myDis = new List<SelectListItem>();
            myType = new List<SelectListItem>();
            var district = model.DISTRICTs.ToList();
            var type = model.PROPERTY_TYPE.ToList();
            ////////
            foreach (var dt in district)
            {
                myDis.Add(new SelectListItem { Text = dt.DistrictName, Value = dt.DistrictName });
            }
            foreach (var tp in type)
            {
                myType.Add(new SelectListItem { Text = tp.CodeType, Value = tp.CodeType });
            }
            ViewBag.myDistrict = myDis;
            ViewBag.myPropertyType = myType;


            return View(property);


        }

        public JsonResult GetStreet(int did)
        {
            var db = new DemoPPCRentalEntities1();
            var streets = db.STREETs.Where(s => s.District_ID == did);
            return Json(streets.Select(s => new
            {
                id = s.ID,
                text = s.StreetName
            }), JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Search(int? dis, int? propertytype, int? bed, int? bath, string price)
        {
            string[] arr = price.Split('-');
            int min = 0;
            int max = 0;
            if (arr.Length > 1)
            {
                min = int.Parse(arr[0]);
                max = int.Parse(arr[1]);
            }

            var property = model.PROPERTies.ToList();
            if (propertytype != null)
            {
                property = property.Where(x => x.PropertyType_ID == propertytype ).ToList();
            }
            if (dis != null)
            {
                property = property.Where(x => x.District_ID == dis).ToList();
            }
            if (bed != null)
            {
                property = property.Where(x => x.BathRoom == bed).ToList();
            }
            if (bath != null)
            {
                property = property.Where(x => x.BathRoom == bath).ToList();
            }
            if (min != 0 && max != 0)
            {
                property = property.Where(p => p.Price >= min && p.Price <= max).ToList();
            }
            return PartialView(property);
        }
        
        public ActionResult Details(int id)
        {
            var property = model.PROPERTies.Find(id);
            //ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultipleImages")).Select(fn => "~/MultipleImages"+Path.GetFileName(fn));
            ViewBag.features = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id).ToList();
            ViewBag.Count = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id).Count();
            ViewBag.fea = model.FEATUREs.ToList();
            return View(property);
        }

    }
}

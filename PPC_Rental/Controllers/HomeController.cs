using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;


namespace PPC_Rental.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> myDis, myType;
        DemoPPCRentalEntities1 model = new DemoPPCRentalEntities1();

        public ActionResult Index()
        {
            var property = model.PROPERTies.ToList().OrderByDescending(x => x.ID);

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

        [HttpGet]
        public ActionResult Search(int? dis, int? propertytype, int? bed, int? bath, int? price, int? pricerange)
        {

            var property = model.PROPERTies.ToList();
            if (propertytype != null)
            {
                property = property.Where(x => x.PropertyType_ID == propertytype).ToList();
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
            return View(property);



        }
        public JsonResult GetPrice(int cos)
        {
            var db = new DemoPPCRentalEntities1();
            var cost = db.PROPERTies.Where(s => s.Price == cos);
            return Json(cost.Select(s => new
            {
               
            }), JsonRequestBehavior.AllowGet);
        }

    }
}

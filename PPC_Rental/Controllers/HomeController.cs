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
        public ActionResult Search(int? dis, string text, string propertytype, int? bed, int? bath, string area)
        {
            myDis = new List<SelectListItem>();
            myType = new List<SelectListItem>();
            var distr = model.DISTRICTs.ToList();
            var type = model.PROPERTY_TYPE.ToList();
            foreach (var dt in distr)
            {
                myDis.Add(new SelectListItem { Text = dt.DistrictName, Value = dt.DistrictName });
            }
            foreach (var tp in type)
            {
                myType.Add(new SelectListItem { Text = tp.CodeType, Value = tp.CodeType });
            }
            ViewBag.myDistrict = myDis;
            ViewBag.myPropertyType = myType;
            var property = model.PROPERTies.ToList().Where(x => (x.District_ID == dis || x.Area == area || x.BathRoom == bath || x.BedRoom == bed || x.PROPERTY_TYPE.CodeType == propertytype || x.Content.Contains(text)));
            //var properties = model.PROPERTies.Where(p => p.Status_ID == 3);
            //foreach (string key in Request.Form.Keys) ViewData.Add(key, Request.Form[key]);
            //if (dis.HasValue)
            //{
            //    properties = properties.Where(p => p.STREET.DISTRICT.ID == dis);
            //}
            //if (bed.HasValue)
            //{
            //    properties = properties.Where(p => p.BedRoom == bed);
            //}
            //if (bath.HasValue)
            //{
            //    properties = properties.Where(p => p.BathRoom == bath);
            //}

            if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
            {
                property = property.Where(p => p.Content.Contains(text));
            }

            return View(property);
            ///
            

        }

            //}
        //    public ActionResult Search(int? district_ID, int? street_ID, string keyWord, int? bedRoom, int? bathRoom, int? parkPlace, string propertytype)
        //{

        //    var properties = model.PROPERTies.Where(p => p.Status_ID == 3);
        //    foreach (string key in Request.Form.Keys) ViewData.Add(key, Request.Form[key]);
        //    ViewBag.District_ID = new SelectList(model.DISTRICTs, "ID", "DistrictName", district_ID);
        //    //ViewBag.minPrice = minPrice;
        //    //ViewBag.maxPrice = maxPrice;
        //    ViewBag.myPropertyType = propertytype;
        //    ViewBag.Street_ID = street_ID;
        //    ViewBag.keyWord = keyWord;
        //    ViewBag.bedRoom = bedRoom;
        //    ViewBag.bathRoom = bathRoom;
        //    ViewBag.parkPlace = parkPlace;
        //    if (district_ID.HasValue)
        //    {
        //        properties = properties.Where(p => p.STREET.DISTRICT.ID == district_ID);
        //    }
        //    if (street_ID.HasValue)
        //    {
        //        properties = properties.Where(p => p.STREET.ID == street_ID);
        //    }
        //    //if (maxPrice.HasValue)
        //    //{
        //    //    properties = properties.Where(p => p.Price <= maxPrice);
        //    //}
        //    //if (minPrice.HasValue)
        //    //{
        //    //    properties = properties.Where(p => p.Price >= minPrice);
        //    //}
        //    if (bedRoom.HasValue)
        //    {
        //        properties = properties.Where(p => p.BedRoom >= bedRoom);
        //    }
        //    if (bathRoom.HasValue)
        //    {
        //        properties = properties.Where(p => p.BedRoom >= bathRoom);
        //    }
        //    if (parkPlace.HasValue)
        //    {
        //        properties = properties.Where(p => p.BedRoom >= bathRoom);
        //    }
        //    if (!String.IsNullOrEmpty(keyWord) && !String.IsNullOrWhiteSpace(keyWord))
        //    {
        //        properties = properties.Where(p => p.Content.Contains(keyWord));
        //    }
        //    return View(properties.ToList());
        //}


    }
     
}

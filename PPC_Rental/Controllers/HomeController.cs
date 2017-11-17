using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;


namespace PPC_Rental.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> myDis, myType;
        DemoPPCRentalEntities model = new DemoPPCRentalEntities();
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
        public ActionResult Search(string dis, string text, string propertytype, int bed, int bath, string area)
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
            var property = model.PROPERTies.ToList().Where(x => (x.DISTRICT.DistrictName == dis || x.Area == area || x.BathRoom == bath || x.BedRoom == bed || x.PROPERTY_TYPE.CodeType== propertytype));

            return View(property);


            //}
            //public ActionResult Search(int? district_ID, int? minPrice, int? maxPrice, string keyWord, int? bathRoom, int? bedRoom)
            //{
            //    var properties = model.PROPERTies.in.Where(p => p.PROJECT_STATUS.Status_Name == "Đã duyệt").;

            //    foreach (string key in Request.Form.Keys) ViewData.Add(key, Request.Form[key]);
            //    ViewBag.District_ID = new SelectList(model.DISTRICTs, "ID", "DistrictName",district_ID);
            //    ViewBag.minPrice = minPrice;
            //    ViewBag.maxPrice = maxPrice;
            //    ViewBag.keyWord = keyWord;
            //    ViewBag.bedRoom = bedRoom;
            //    ViewBag.bathRoom = bathRoom;

            //    if (district_ID.HasValue)
            //    {
            //        properties = properties.Where(p => p.District_ID == district_ID);
            //    }
            //    if (minPrice.HasValue)
            //    {
            //        properties = properties.Where(p => p.Price >= minPrice);
            //    }
            //    if (maxPrice.HasValue)
            //    {
            //        properties = properties.Where(p => p.Price <= maxPrice);
            //    }
            //    if (bathRoom.HasValue)
            //    {
            //        properties = properties.Where(p => p.BathRoom >= bathRoom);
            //    }
            //    if (bedRoom.HasValue)
            //    {
            //        properties = properties.Where(p => p.BedRoom >= bedRoom);
            //    }
            //    if (bedRoom.HasValue)
            //    {
            //        properties = properties.Where(p => p.BedRoom >= bedRoom);
            //    }

            //    if (!String.IsNullOrEmpty(keyWord) && !String.IsNullOrWhiteSpace(keyWord))
            //    {
            //        properties = properties.Where(p => p.Content.Contains(keyWord));
            //    }
            //    return View(properties.ToList());

            }
            }
     
}

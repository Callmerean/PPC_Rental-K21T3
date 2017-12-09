using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;

namespace PPC_Rental.Controllers
{
    public class AjaxFilterController : Controller
    {
        DemoPPCRentalEntities1 model = new DemoPPCRentalEntities1();
        // GET: AjaxFilter
        public ActionResult Filter(int? dis, int? propertytype, int? bed, int? bath, string price)
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
            if (min != 0)
            {
                property = property.Where(p => p.Price >= min).ToList();
            }
            if (max != 0)
            {
                property = property.Where(p => p.Price <= max).ToList();
            }

            return View(property);
        }
    }
}
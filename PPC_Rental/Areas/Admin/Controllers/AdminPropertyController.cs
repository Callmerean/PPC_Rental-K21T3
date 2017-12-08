using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;
using System.Data.Entity;
using System.Net;

namespace PPC_Rental.Areas.Admin.Controllers
{
    public class AdminPropertyController : Controller
    {
        
        DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();
        // GET: /Admin/AdminProperty/
        public ActionResult Index(int page = 1, int pageSize = 5)
        {

            
            var propertymodel = new DAO();
            var model = propertymodel.ListAllPaging(page, pageSize);
            return View(model);


        }

        public JsonResult GetStreet(int did)
        {
            var db = new DemoPPCRentalEntities1();
            var streets = db.STREETs.Where(s => s.DISTRICT.ID == did);
            return Json(streets.Select(s => new
            {
                id = s.ID,
                text = s.StreetName
            }), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var property = new DAO().ViewDetail(id);
            ListItem();


            return View(property);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PROPERTY property, List<HttpPostedFileBase> files)
        {

            ListItem();
            // Images
            try
            {

                string filename = Path.GetFileNameWithoutExtension(property.ImageFile.FileName);
                string extension = Path.GetExtension(property.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                property.Avatar = "~/Images/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                // Avatar

                if (Path.GetFileNameWithoutExtension(property.ImageFile.FileName) == null)
                {
                    string s2 = "~/Images/ImagesNull.png";
                    property.ImageFile.SaveAs(s2);
                    //property.ImageFile2.SaveAs(filename2);
                }
                else
                {
                    //property.ImageFile2.SaveAs(filename2);
                    property.ImageFile.SaveAs(filename);
                }



                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var model = new DAO();
                    var res = model.Update(property);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminProperty");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update không thành công");
                    }
                }

            }
            catch
            {
                if (ModelState.IsValid)
                {

                    var model = new DAO();
                    var res = model.Update(property);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminProperty");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update không thành công");
                    }
                }
            }

            return View();
       

        }
        public ActionResult Create()
        {
            ListItem();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PROPERTY pROPERTY, List<HttpPostedFileBase> files)
        {
            ListItem();
            try
            {

                string filename = Path.GetFileNameWithoutExtension(pROPERTY.ImageFile.FileName);
                string extension = Path.GetExtension(pROPERTY.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                pROPERTY.Avatar = "~/Images/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                // Avatar

                if (Path.GetFileNameWithoutExtension(pROPERTY.ImageFile.FileName) == null)
                {
                    string s2 = "~/Images/ImagesNull.png";
                    pROPERTY.ImageFile.SaveAs(s2);
                    //property.ImageFile2.SaveAs(filename2);
                }
                else
                {
                    //property.ImageFile2.SaveAs(filename2);
                    pROPERTY.ImageFile.SaveAs(filename);
                }

                pROPERTY.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());

                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var model = new DAO();
                    var res = model.InsertProperty(pROPERTY);
                    if (res > 0)
                    {
                        return RedirectToAction("Index", "AdminProperty");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update không thành công");
                    }
                }

            }
            catch
            {
                if (ModelState.IsValid)
                {

                    var model = new DAO();
                    var res = model.InsertProperty(pROPERTY);
                    if (res > 0)
                    {
                        return RedirectToAction("Index", "AdminProperty");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update không thành công");
                    }
                }
            }


            
            return View(pROPERTY);
        }
      
        [HttpGet]
        public ActionResult Delete(int id)
        {

#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id == null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROPERTY pROPERTY = db.PROPERTies.Find(id);
            db.PROPERTies.Remove(pROPERTY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(product);

        }
        public void ListItem()
        {
            ViewBag.property_type = db.PROPERTY_TYPE.ToList();
            ViewBag.property_street = db.STREETs.OrderBy(x => x.StreetName).ToList();
            ViewBag.property_ward = db.WARDs.OrderBy(x => x.WardName).ToList();
            ViewBag.property_district = db.DISTRICTs.OrderBy(x => x.DistrictName).ToList();
            ViewBag.property_userid = db.USERs.OrderBy(x => x.FullName).ToList();
            ViewBag.property_status = db.PROJECT_STATUS.OrderBy(x => x.Status_Name).ToList();
            

        }

    }
}
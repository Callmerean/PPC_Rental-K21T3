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
            if (Session["UserID"] != null)
            {
                int x1 = (int)Session["UserID"];
                var propertymodel = new DAO();
                var model = propertymodel.ListAllPaging(page, pageSize, x1);
                return View(model);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public JsonResult GetStreet(int did)
        {
            var db = new DemoPPCRentalEntities1();
            var streets = db.STREETs.Where(s => s.DISTRICT.ID == did);
            var wards = db.WARDs.Where(s => s.DISTRICT.ID == did);
            return Json(streets.Select(s => new
            {
                id = s.ID,
                text = s.StreetName
            }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetWard(int did)
        {
            var db = new DemoPPCRentalEntities1();
            var wards = db.WARDs.Where(s => s.DISTRICT.ID == did);
            return Json(wards.Select(s => new
            {
                id = s.ID,
                text = s.WardName
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
            ViewBag.property_type = db.PROPERTY_TYPE.ToList();
            ViewBag.property_street = db.STREETs.Where(w => w.District_ID == property.District_ID).OrderBy(x => x.StreetName).ToList();
            ViewBag.property_ward = db.WARDs.Where(w => w.District_ID == property.District_ID).OrderBy(x => x.WardName).ToList();
            ViewBag.property_district = db.DISTRICTs.OrderBy(x => x.DistrictName).ToList();
            ViewBag.property_userid = db.USERs.OrderBy(x => x.FullName).ToList();
            ViewBag.property_status = db.PROJECT_STATUS.OrderBy(x => x.Status_Name).ToList();
            // Images
            try
            {
                string filename = Path.GetFileNameWithoutExtension(property.ImageFile.FileName);
                string extension = Path.GetExtension(property.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                property.Avatar =  filename;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                // Avatar
                if (Path.GetFileNameWithoutExtension(property.ImageFile.FileName) == null)
                {
                    string s2 = "~/Images/ImagesNull.png";
                    property.ImageFile.SaveAs(s2);
                }
                else
                {
                    property.ImageFile.SaveAs(filename);
                }
                property.Images = ImagesU(property);
                property.Sale_ID = 1;
                var model = new DAO();
                if (ModelState.IsValid)
                {
                    var id = model.Update(property);
                    db.PROPERTY_FEATURE.RemoveRange(db.PROPERTY_FEATURE.Where(x=> x.Property_ID == property.ID ));
                    var Features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var fea in Features)
                    {
                        var ids = int.Parse(fea.Split('_')[1]);
                        if (Request.Form[fea].StartsWith("true"))
                        {
                                db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                                {
                                    Property_ID = property.ID,
                                    Feature_ID = ids
                                });
                        }
                    }
                    db.SaveChanges();
                    if (id)
                    {
                        return RedirectToAction("Index", "AdminProperty");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create không thành công");
                    }
                }
            }
            catch(Exception)
            {
                property.Sale_ID = 1;
                var model = new DAO();
                if (ModelState.IsValid)
                {
                    var id = model.Update(property);
                    db.PROPERTY_FEATURE.RemoveRange(db.PROPERTY_FEATURE.Where(x => x.Property_ID == property.ID));
                    var Features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var fea in Features)
                    {
                        var ids = int.Parse(fea.Split('_')[1]);
                        if (Request.Form[fea].StartsWith("true"))
                        {
                                db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                                {
                                    Property_ID = property.ID,
                                    Feature_ID = ids
                                });
                           
                        }
                    }
                    db.SaveChanges();
                    if (id)
                    {
                        return RedirectToAction("Index", "AdminProperty");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create không thành công");
                    }
                }
            }

            return View();
       

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
        public void ListItem()
        {
            ViewBag.property_type = db.PROPERTY_TYPE.ToList();
            ViewBag.property_street = db.STREETs.OrderBy(x => x.StreetName).ToList();
            ViewBag.property_ward = db.WARDs.OrderBy(x => x.WardName).ToList();
            ViewBag.property_district = db.DISTRICTs.OrderBy(x => x.DistrictName).ToList();
            ViewBag.property_userid = db.USERs.OrderBy(x => x.FullName).ToList();
            ViewBag.property_status = db.PROJECT_STATUS.OrderBy(x => x.Status_Name).ToList();
            

        }
        private string ImagesU(PROPERTY p)
        {

            string filename;
            string extension;
            string b;
            string s = "";
            foreach (var file in p.ImageFile1)
            {
                if (file.ContentLength > 0)
                {
                    filename = Path.GetFileNameWithoutExtension(file.FileName);
                    extension = Path.GetExtension(file.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                    p.Images = filename;
                    b = p.Images;
                    s = string.Concat(s, b, ",");
                    filename = Path.Combine(Server.MapPath("~/MultipleImages"), filename);
                    file.SaveAs(filename);
                }
            }
          
            return s;

        }
    }
}
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
    public class ClientController : Controller
    {
        // GET: Admin/Client
        DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();
        public static string idd = "";
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            if (Session["UserID"] != null)
            {
                int x1 = (int)Session["UserID"];
                var property = db.PROPERTies.Where(x => x.UserID == x1);


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

                    Session["UserID"] = user.ID;
                    idd = Session["UserID"].ToString();
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
                pROPERTY.UserID = int.Parse(idd);
                pROPERTY.Status_ID = 1;
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var model = new DAO();
                    var res = model.InsertProperty(pROPERTY);
                    if (res > 0)
                    {
                        return RedirectToAction("Index", "Client");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update không thành công");
                    }
                }

            }
            catch
            {
                pROPERTY.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                pROPERTY.UserID = int.Parse(idd);
                pROPERTY.Status_ID = 1;
                if (ModelState.IsValid)
                {

                    var model = new DAO();
                    var res = model.InsertProperty(pROPERTY);
                    if (res > 0)
                    {
                        return RedirectToAction("Index", "Client");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update không thành công");
                    }
                }
            }



            return View();
        }
        //[HttpPost]
        //public ActionResult Create(PROPERTY property, List<HttpPostedFileBase> files)
        //{
        //    ListItem();

        //    try
        //    {
        // // Images

        //        string filename = Path.GetFileNameWithoutExtension(property.ImageFile.FileName);
        //        string extension = Path.GetExtension(property.ImageFile.FileName);
        //        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
        //        property.Images = filename;
        //        filename = Path.Combine(Server.MapPath("~/Images"), filename);
        //        property.ImageFile.SaveAs(filename);





        //        property.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());

        //        if (ModelState.IsValid)
        //        {
        //            var model = new DAO();
        //            long id = model.InsertProperty(property);

        //            // SavemultiImage ----------------------------
        //            var path = "";
        //            foreach (var item in files)
        //            {
        //                if (item != null)
        //                {
        //                    if (item.ContentLength > 0)
        //                    {
        //                        if (Path.GetExtension(item.FileName).ToLower() == ".jpg"
        //                            || Path.GetExtension(item.FileName).ToLower() == ".png"
        //                            || Path.GetExtension(item.FileName).ToLower() == ".gif"
        //                            || Path.GetExtension(item.FileName).ToLower() == ".jpeg")
        //                        {
        //                            var path0 = id + item.FileName;
        //                            path = Path.Combine(Server.MapPath("~/MultipleImages"), path0);

        //                            item.SaveAs(path);
        //                            ViewBag.UploadSuccess = true;

        //                        }
        //                    }
        //                }
        //            }
        //            // End SaveMultiImage -------------------------

        //            if (id > 0)
        //            {
        //                return RedirectToAction("Index", "AdminProperty");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Create Property khong thanh cong");

        //            }

        //        }

        //    }
        //    catch (NullReferenceException)
        //    {

        //        property.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());

        //        ListItem();

        //        if (ModelState.IsValid)
        //        {
        //            var model = new DAO();
        //            long id = model.InsertProperty(property);
        //            if (id > 0)
        //            {
        //                return RedirectToAction("Index", "AdminProperty");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Create Property khong thanh cong");

        //            }

        //        }
        //    }


        //    return View();
        //}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROPERTY pROPERTY = db.PROPERTies.Find(id);
            if (pROPERTY == null)
            {
                return HttpNotFound();
            }
            return View(pROPERTY);
        }

        // POST: Admin/xx/Delete/5
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
            //ViewBag.sale = model.Sla.ToList();

        }
    }
}
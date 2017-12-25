using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;
using System.Data.Entity;
using System.Net;
using PPC_Rental.Models.Common;
using BotDetect.Web.Mvc;
using System.Web.Helpers;

namespace PPC_Rental.Areas.Admin.Controllers
{
    public class ClientController : Controller
    {
        // GET: Admin/Client
        DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();
       

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
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            if (Session["UserID"] != null)
            {
                int x1 = (int)Session["UserID"];
                var propertymodel = new DAO();
                var model = propertymodel.UserListAllPaging(page, pageSize, x1);
                return View(model);
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
                    if (user.Status == true && int.Parse(user.Role) == 0)
                    {
                        Session["FullName"] = user.FullName;
                        Session["Role"] = user.Role;
                        Session["Email"] = user.Email;
                        Session["UserID"] = user.ID;

                        return RedirectToAction("Index", "Admin/AdminProperty");
                    }
                    else if (user.Status == true && int.Parse(user.Role) == 1)
                    {
                        Session["FullName"] = user.FullName;
                        Session["Role"] = user.Role;
                        Session["Email"] = user.Email;
                        Session["UserID"] = user.ID;
                        return RedirectToAction("Index", "Client");
                    }
                }
                else
                {
                    ViewBag.mgs = "Tài khoảng hoặc mật khẩu không đúng";
                }
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
                Session["Role"] = null;

            }
            return RedirectToAction("Index","Home");
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
            
            var proAddMulti = "";
            try
            {
                //Avatar
                string filename = Path.GetFileNameWithoutExtension(pROPERTY.ImageFile.FileName);
                string extension = Path.GetExtension(pROPERTY.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                pROPERTY.Avatar =  filename;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                if (Path.GetFileNameWithoutExtension(pROPERTY.ImageFile.FileName) == null)
                {
                    string s2 = "~/Images/ImagesNull.png";
                    pROPERTY.ImageFile.SaveAs(s2);
                }
                else
                {
                    pROPERTY.ImageFile.SaveAs(filename);
                }
                
                pROPERTY.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                String.Format("{0:M/d/yyyy}", pROPERTY.Created_at);
                pROPERTY.UserID = (int)Session["UserID"];
                pROPERTY.Status_ID = 1;
                pROPERTY.Sale_ID = 1;
                pROPERTY.UnitPrice = "USD";
                var model = new DAO();
                if (ModelState.IsValid)
                { 
                    long id = model.InsertProperty(pROPERTY);
                    var Features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var fea in Features)
                    {
                        var ids = int.Parse(fea.Split('_')[1]);
                        if (Request.Form[fea].StartsWith("true"))
                        {
                            db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                            {
                                Property_ID = (int)id,
                                Feature_ID = ids
                            });
                        }
                    }
                    var path = "";
                    foreach (var item in files)
                    {
                        if (item != null)
                        {
                            if (item.ContentLength > 0)
                            {
                                if (Path.GetExtension(item.FileName).ToLower() == ".jpg"
                                    || Path.GetExtension(item.FileName).ToLower() == ".png"
                                    || Path.GetExtension(item.FileName).ToLower() == ".gif"
                                    || Path.GetExtension(item.FileName).ToLower() == ".jpeg")
                                {
                                    var path0 = id + item.FileName;
                                    path = Path.Combine(Server.MapPath("~/MultipleImages"), path0);
                                    if (proAddMulti == "")
                                    {
                                        proAddMulti = path0;
                                    }
                                    else
                                    {
                                        proAddMulti = proAddMulti + "," + path0;
                                    }
                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }
                    var proMultiImage = db.PROPERTies.FirstOrDefault(x => x.ID == id);
                    proMultiImage.Images = proAddMulti;
                    db.SaveChanges();
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Client");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create không thành công");
                    }
                }
               
            }
            catch(NullReferenceException)
            {
               
                pROPERTY.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                String.Format("{0:M/d/yyyy}", pROPERTY.Created_at);
                pROPERTY.UserID = (int)Session["UserID"];
                pROPERTY.Status_ID = 1;
                pROPERTY.Sale_ID = 1;
                pROPERTY.UnitPrice = "USD";
                var model = new DAO();
                if (ModelState.IsValid)
                {
                    long id = model.InsertProperty(pROPERTY);
                    var Features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var fea in Features)
                    {
                        var ids = int.Parse(fea.Split('_')[1]);
                        if (Request.Form[fea].StartsWith("true"))
                        {
                            db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                            {
                                Property_ID = (int)id,
                                Feature_ID = ids
                            });
                        }
                    }
                    var path = "";
                    foreach (var item in files)
                    {
                        if (item != null)
                        {
                            if (item.ContentLength > 0)
                            {
                                if (Path.GetExtension(item.FileName).ToLower() == ".jpg"
                                    || Path.GetExtension(item.FileName).ToLower() == ".png"
                                    || Path.GetExtension(item.FileName).ToLower() == ".gif"
                                    || Path.GetExtension(item.FileName).ToLower() == ".jpeg")
                                {
                                    var path0 = id + item.FileName;
                                    path = Path.Combine(Server.MapPath("~/MultipleImages"), path0);
                                    if (proAddMulti == "")
                                    {
                                        proAddMulti = path0;
                                    }
                                    else
                                    {
                                        proAddMulti = proAddMulti + "," + path0;
                                    }
                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }
                    var proMultiImage = db.PROPERTies.FirstOrDefault(x => x.ID == id);
                    proMultiImage.Images = proAddMulti;
                    db.SaveChanges();
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Client");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create không thành công");
                    }
                }

            }

           

            return View(pROPERTY);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(product);

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DAO();
                if (dao.CheckUserName(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new USER();
                    user.Email = model.Email;
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    user.FullName = model.FullName;
                    user.Address = model.Address;
                    user.Role = "1";
                    user.Status = true;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng kí thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                }
            }
            return View(model);
        }
        public ActionResult ChangePassword()
        {
            int id = int.Parse(Session["UserID"].ToString());
            var userdetail = db.USERs.Where(x => x.ID == id);
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldPass, string newPass, string comPass)
        {
            int id = int.Parse(Session["UserID"].ToString());
            var userdetail = db.USERs.Find(id);
            if (userdetail.ID == id)
            {
                if (userdetail.Password == oldPass)
                {
                    if (newPass == comPass)
                    {
                        userdetail.Password = newPass;
                        db.SaveChanges();
                        ViewBag.mess = "success";
                        if (Session["Role"].Equals(1)) {
                            return RedirectToAction("Index", "Client", new { userid = int.Parse(Session["UserID"].ToString()) });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Admin/AdminProperty");
                        }
                    }
                    else
                    {
                        ViewBag.mess = "Mật khẩu xác nhận không đúng";
                        return View();
                    }

                }
                else
                {
                    ViewBag.mess = "Sai mật khẩu";
                    return View();
                }

            }
            else
            {

                return View();
            }
        }

        public void ListItem()
        {
            ViewBag.property_type = db.PROPERTY_TYPE.ToList();
            ViewBag.property_street = db.STREETs.OrderBy(x => x.StreetName).ToList();
            ViewBag.property_ward = db.WARDs.OrderBy(x => x.WardName).ToList();
            ViewBag.property_district = db.DISTRICTs.OrderBy(x => x.DistrictName).ToList();
            ViewBag.property_userid = db.USERs.OrderBy(x => x.FullName).ToList();
            ViewBag.property_status = db.PROJECT_STATUS.OrderBy(x => x.Status_Name).ToList();
            ViewBag.Feature_ID = db.FEATUREs.ToList();

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
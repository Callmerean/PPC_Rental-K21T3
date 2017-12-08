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
    public class PROPERTiesController : Controller
    {
        private DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();

        // GET: PROPERTies
        public ActionResult Index()
        {
            var pROPERTies = db.PROPERTies.Include(p => p.DISTRICT).Include(p => p.PROJECT_STATUS).Include(p => p.PROPERTY_TYPE).Include(p => p.STREET).Include(p => p.USER).Include(p => p.USER1).Include(p => p.WARD);
            return View(pROPERTies.ToList());
        }

        // GET: PROPERTies/Details/5
        public ActionResult Details(int? id)
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

        // GET: PROPERTies/Create
        public ActionResult Create()
        {
            ViewBag.District_ID = new SelectList(db.DISTRICTs, "ID", "DistrictName");
            ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name");
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType");
            ViewBag.Street_ID = new SelectList(db.STREETs, "ID", "StreetName");
            ViewBag.UserID = new SelectList(db.USERs, "ID", "Email");
            ViewBag.Sale_ID = new SelectList(db.USERs, "ID", "Email");
            ViewBag.Ward_ID = new SelectList(db.WARDs, "ID", "WardName");
            return View();
        }

        // POST: PROPERTies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PropertyName,Avatar,Images,PropertyType_ID,Content,Street_ID,Ward_ID,District_ID,Price,UnitPrice,Area,BedRoom,BathRoom,PackingPlace,UserID,Created_at,Create_post,Status_ID,Note,Updated_at,Sale_ID")] PROPERTY pROPERTY)
        {
            if (ModelState.IsValid)
            {
                db.PROPERTies.Add(pROPERTY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.District_ID = new SelectList(db.DISTRICTs, "ID", "DistrictName", pROPERTY.District_ID);
            ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", pROPERTY.Status_ID);
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", pROPERTY.PropertyType_ID);
            ViewBag.Street_ID = new SelectList(db.STREETs, "ID", "StreetName", pROPERTY.Street_ID);
            ViewBag.UserID = new SelectList(db.USERs, "ID", "Email", pROPERTY.UserID);
            ViewBag.Sale_ID = new SelectList(db.USERs, "ID", "Email", pROPERTY.Sale_ID);
            ViewBag.Ward_ID = new SelectList(db.WARDs, "ID", "WardName", pROPERTY.Ward_ID);
            return View(pROPERTY);
        }

        // GET: PROPERTies/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.District_ID = new SelectList(db.DISTRICTs, "ID", "DistrictName", pROPERTY.District_ID);
            ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", pROPERTY.Status_ID);
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", pROPERTY.PropertyType_ID);
            ViewBag.Street_ID = new SelectList(db.STREETs, "ID", "StreetName", pROPERTY.Street_ID);
            ViewBag.UserID = new SelectList(db.USERs, "ID", "Email", pROPERTY.UserID);
            ViewBag.Sale_ID = new SelectList(db.USERs, "ID", "Email", pROPERTY.Sale_ID);
            ViewBag.Ward_ID = new SelectList(db.WARDs, "ID", "WardName", pROPERTY.Ward_ID);
            return View(pROPERTY);
        }

        // POST: PROPERTies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PropertyName,Avatar,Images,PropertyType_ID,Content,Street_ID,Ward_ID,District_ID,Price,UnitPrice,Area,BedRoom,BathRoom,PackingPlace,UserID,Created_at,Create_post,Status_ID,Note,Updated_at,Sale_ID")] PROPERTY pROPERTY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROPERTY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.District_ID = new SelectList(db.DISTRICTs, "ID", "DistrictName", pROPERTY.District_ID);
            ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", pROPERTY.Status_ID);
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", pROPERTY.PropertyType_ID);
            ViewBag.Street_ID = new SelectList(db.STREETs, "ID", "StreetName", pROPERTY.Street_ID);
            ViewBag.UserID = new SelectList(db.USERs, "ID", "Email", pROPERTY.UserID);
            ViewBag.Sale_ID = new SelectList(db.USERs, "ID", "Email", pROPERTY.Sale_ID);
            ViewBag.Ward_ID = new SelectList(db.WARDs, "ID", "WardName", pROPERTY.Ward_ID);
            return View(pROPERTY);
        }

        // GET: PROPERTies/Delete/5
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

        // POST: PROPERTies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROPERTY pROPERTY = db.PROPERTies.Find(id);
            db.PROPERTies.Remove(pROPERTY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

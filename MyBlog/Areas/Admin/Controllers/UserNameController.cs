using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EntityF;

namespace MyBlog.Areas.Admin.Controllers
{
    public class UserNameController :BaseController
    {
        private MyblogDbContext db = new MyblogDbContext();

        // GET: Admin/UserName
        public ActionResult Index()
        {
            return View(db.tbl_UserName.ToList());
        }

        // GET: Admin/UserName/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserName tbl_UserName = db.tbl_UserName.Find(id);
            if (tbl_UserName == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserName);
        }

        // GET: Admin/UserName/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,PassWord,Avatar,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status,IsAdmin")] tbl_UserName tbl_UserName)
        {
            if (ModelState.IsValid)
            {
                db.tbl_UserName.Add(tbl_UserName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_UserName);
        }

        // GET: Admin/UserName/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserName tbl_UserName = db.tbl_UserName.Find(id);
            if (tbl_UserName == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserName);
        }

        // POST: Admin/UserName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,PassWord,Avatar,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status,IsAdmin")] tbl_UserName tbl_UserName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_UserName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_UserName);
        }

        // GET: Admin/UserName/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserName tbl_UserName = db.tbl_UserName.Find(id);
            if (tbl_UserName == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserName);
        }

        // POST: Admin/UserName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tbl_UserName tbl_UserName = db.tbl_UserName.Find(id);
            db.tbl_UserName.Remove(tbl_UserName);
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

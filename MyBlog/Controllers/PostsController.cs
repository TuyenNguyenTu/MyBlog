using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EntityF;

namespace MyBlog.Controllers
{
    public class PostsController : Controller
    {
        private MyblogDbContext db = new MyblogDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            var tbl_Posts = db.tbl_Posts.Include(t => t.tbl_CategoriesPosts);
            return View(tbl_Posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Posts tbl_Posts = db.tbl_Posts.Find(id);
            if (tbl_Posts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Posts);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.CategoriesID = new SelectList(db.tbl_CategoriesPosts, "ID", "CategoryName");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ContentPost,MetaTitle,DisplayOrder,CategoriesID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,Status,TagID")] tbl_Posts tbl_Posts)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Posts.Add(tbl_Posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriesID = new SelectList(db.tbl_CategoriesPosts, "ID", "CategoryName", tbl_Posts.CategoriesID);
            return View(tbl_Posts);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Posts tbl_Posts = db.tbl_Posts.Find(id);
            if (tbl_Posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriesID = new SelectList(db.tbl_CategoriesPosts, "ID", "CategoryName", tbl_Posts.CategoriesID);
            return View(tbl_Posts);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ContentPost,MetaTitle,DisplayOrder,CategoriesID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,Status,TagID")] tbl_Posts tbl_Posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesID = new SelectList(db.tbl_CategoriesPosts, "ID", "CategoryName", tbl_Posts.CategoriesID);
            return View(tbl_Posts);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Posts tbl_Posts = db.tbl_Posts.Find(id);
            if (tbl_Posts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Posts);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tbl_Posts tbl_Posts = db.tbl_Posts.Find(id);
            db.tbl_Posts.Remove(tbl_Posts);
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

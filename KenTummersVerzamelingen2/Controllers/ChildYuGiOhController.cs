using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KenTummersVerzamelingen2.Models;

namespace KenTummersVerzamelingen2.Controllers
{
    public class ChildYuGiOhController : Controller
    {
        private YuGiOhModel db = new YuGiOhModel();

        // GET: ChildYuGiOhs
        public ActionResult Index()
        {
            var childYuGiOh = db.ChildYuGiOh.Include(c => c.ParentYuGiOh);
            return View(childYuGiOh.ToList());
        }

        // GET: ChildYuGiOhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildYuGiOh childYuGiOh = db.ChildYuGiOh.Find(id);
            if (childYuGiOh == null)
            {
                return HttpNotFound();
            }
            return View(childYuGiOh);
        }

        // GET: ChildYuGiOhs/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.ParentYuGiOh, "ID", "Name");
            return View();
        }

        // POST: ChildYuGiOhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ParentID,Categorie,Waarde,Prijs,Type,Status")] ChildYuGiOh childYuGiOh)
        {
            if (ModelState.IsValid)
            {
                db.ChildYuGiOh.Add(childYuGiOh);
                db.SaveChanges();
                return RedirectToAction("../ParentYuGiOh/Index");
            }

            ViewBag.ParentID = new SelectList(db.ParentYuGiOh, "ID", "Name", childYuGiOh.ParentID);
            return View(childYuGiOh);
        }

        // GET: ChildYuGiOhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildYuGiOh childYuGiOh = db.ChildYuGiOh.Find(id);
            if (childYuGiOh == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.ParentYuGiOh, "ID", "Name", childYuGiOh.ParentID);
            return View(childYuGiOh);
        }

        // POST: ChildYuGiOhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ParentID,Categorie,Waarde,Prijs,Type,Status")] ChildYuGiOh childYuGiOh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childYuGiOh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../ParentYuGiOh/Index");
            }
            ViewBag.ParentID = new SelectList(db.ParentYuGiOh, "ID", "Name", childYuGiOh.ParentID);
            return View(childYuGiOh);
        }

        public ActionResult Akkorderen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildYuGiOh childYuGiOh = db.ChildYuGiOh.Find(id);
            if (childYuGiOh == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.ParentYuGiOh, "ID", "Name", childYuGiOh.ParentID);
            return View(childYuGiOh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Akkorderen([Bind(Include = "ID,Name,ParentID,Categorie,Waarde,Prijs,Type,Status")] ChildYuGiOh childYuGiOh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childYuGiOh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../ParentYuGiOh/Index");
            }
            ViewBag.ParentID = new SelectList(db.ParentYuGiOh, "ID", "Name", childYuGiOh.ParentID);
            return View(childYuGiOh);
        }

        // GET: ChildYuGiOhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildYuGiOh childYuGiOh = db.ChildYuGiOh.Find(id);
            if (childYuGiOh == null)
            {
                return HttpNotFound();
            }
            return View(childYuGiOh);
        }

        // POST: ChildYuGiOhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChildYuGiOh childYuGiOh = db.ChildYuGiOh.Find(id);
            db.ChildYuGiOh.Remove(childYuGiOh);
            db.SaveChanges();
            return RedirectToAction("../ParentYuGiOh/Index");
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

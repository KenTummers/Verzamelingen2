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
    public class ChildFishController : Controller
    {
        private VissenModel db = new VissenModel();

        // GET: ChildFish
        public ActionResult Index()
        {
            var childFish = db.ChildFish.Include(c => c.ParentFish);
            return View(childFish.ToList());
        }

        // GET: ChildFish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildFish childFish = db.ChildFish.Find(id);
            if (childFish == null)
            {
                return HttpNotFound();
            }
            return View(childFish);
        }

        // GET: ChildFish/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.ParentFish, "ID", "Name");
            return View();
        }

        // POST: ChildFish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ParentID,Categorie,Beschrijving,Waarde,Prijs,Gewicht,Kleur,Lengte,Status")] ChildFish childFish)
        {
            if (ModelState.IsValid)
            {
                db.ChildFish.Add(childFish);
                db.SaveChanges();
                return RedirectToAction("../ParentFish/Index");
            }

            ViewBag.ParentID = new SelectList(db.ParentFish, "ID", "Name", childFish.ParentID);
            return View(childFish);
        }

        // GET: ChildFish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildFish childFish = db.ChildFish.Find(id);
            if (childFish == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.ParentFish, "ID", "Name", childFish.ParentID);
            return View(childFish);
        }

        // POST: ChildFish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ParentID,Categorie,Beschrijving,Waarde,Prijs,Gewicht,Kleur,Lengte,Status")] ChildFish childFish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childFish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../ParentFish/Index");
            }
            ViewBag.ParentID = new SelectList(db.ParentFish, "ID", "Name", childFish.ParentID);
            return View(childFish);
        }

        // GET: ChildFish/Edit/5
        public ActionResult Akkorderen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildFish childFish = db.ChildFish.Find(id);
            if (childFish == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.ParentFish, "ID", "Name", childFish.ParentID);
            return View(childFish);
        }

        // POST: ChildFish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Akkorderen([Bind(Include = "ID,Name,ParentID,Categorie,Beschrijving,Waarde,Prijs,Gewicht,Kleur,Lengte,Status")] ChildFish childFish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childFish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../ParentFish/Index");
            }
            ViewBag.ParentID = new SelectList(db.ParentFish, "ID", "Name", childFish.ParentID);
            return View(childFish);
        }

        // GET: ChildFish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildFish childFish = db.ChildFish.Find(id);
            if (childFish == null)
            {
                return HttpNotFound();
            }
            return View(childFish);
        }

        // POST: ChildFish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChildFish childFish = db.ChildFish.Find(id);
            db.ChildFish.Remove(childFish);
            db.SaveChanges();
            return RedirectToAction("../ParentFish/Index");
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

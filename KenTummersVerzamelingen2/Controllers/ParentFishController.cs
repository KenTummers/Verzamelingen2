using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KenTummersVerzamelingen2.Models;
using KenTummersVerzamelingen2.ViewModels;

namespace KenTummersVerzamelingen2.Controllers
{
    public class ParentFishController : Controller
    {
        private VissenModel db = new VissenModel();

        // GET: tblParents
        public ActionResult Index(int? id)
        //public ActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.parentFish = db.ParentFish;

            if (id != null)
            {
                // Child objecten bij Parent objecten ophalen
                ViewBag.ParentID = id.Value;
                viewModel.childFish = viewModel.parentFish.Where(i => i.ID == id.Value).Single().ChildFish;
            }
            //return View(db.tblParent.ToList());
            return View(viewModel);
        }


        // GET: ParentFish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentFish parentFish = db.ParentFish.Find(id);
            if (parentFish == null)
            {
                return HttpNotFound();
            }
            return View(parentFish);
        }

        // GET: ParentFish/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentFish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Categorie,Status")] ParentFish parentFish)
        {
            if (ModelState.IsValid)
            {
                db.ParentFish.Add(parentFish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parentFish);
        }

        // GET: ParentFish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentFish parentFish = db.ParentFish.Find(id);
            if (parentFish == null)
            {
                return HttpNotFound();
            }
            return View(parentFish);
        }

        // POST: ParentFish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Categorie,Status")] ParentFish parentFish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentFish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentFish);
        }

        // GET: ParentFish/Edit/5
        public ActionResult Akkorderen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentFish parentFish = db.ParentFish.Find(id);
            if (parentFish == null)
            {
                return HttpNotFound();
            }
            return View(parentFish);
        }

        // POST: ParentFish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Akkorderen([Bind(Include = "ID,Name,Categorie,Status")] ParentFish parentFish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentFish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentFish);
        }

        // GET: ParentFish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentFish parentFish = db.ParentFish.Find(id);
            if (parentFish == null)
            {
                return HttpNotFound();
            }
            return View(parentFish);
        }

        // POST: ParentFish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParentFish parentFish = db.ParentFish.Find(id);
            db.ParentFish.Remove(parentFish);
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

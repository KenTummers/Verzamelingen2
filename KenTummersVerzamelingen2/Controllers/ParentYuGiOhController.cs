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
    public class ParentYuGiOhController : Controller
    {
        private YuGiOhModel db = new YuGiOhModel();

        // GET: tblParents
        public ActionResult Index(int? id)
        //public ActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.parentYuGiOh = db.ParentYuGiOh;

            if (id != null)
            {
                // Child objecten bij Parent objecten ophalen
                ViewBag.ParentID = id.Value;
                viewModel.childYuGiOh = viewModel.parentYuGiOh.Where(i => i.ID == id.Value).Single().ChildYuGiOh;
            }
            //return View(db.tblParent.ToList());
            return View(viewModel);
        }


        // GET: ParentYuGiOhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentYuGiOh parentYuGiOh = db.ParentYuGiOh.Find(id);
            if (parentYuGiOh == null)
            {
                return HttpNotFound();
            }
            return View(parentYuGiOh);
        }

        // GET: ParentYuGiOhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentYuGiOhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Status")] ParentYuGiOh parentYuGiOh)
        {
            if (ModelState.IsValid)
            {
                db.ParentYuGiOh.Add(parentYuGiOh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parentYuGiOh);
        }

        // GET: ParentYuGiOhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentYuGiOh parentYuGiOh = db.ParentYuGiOh.Find(id);
            if (parentYuGiOh == null)
            {
                return HttpNotFound();
            }
            return View(parentYuGiOh);
        }

        // POST: ParentYuGiOhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Status")] ParentYuGiOh parentYuGiOh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentYuGiOh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentYuGiOh);
        }

        public ActionResult Akkorderen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentYuGiOh parentYuGiOh = db.ParentYuGiOh.Find(id);
            if (parentYuGiOh == null)
            {
                return HttpNotFound();
            }
            return View(parentYuGiOh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Akkorderen([Bind(Include = "ID,Name,Status")] ParentYuGiOh parentYuGiOh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentYuGiOh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentYuGiOh);
        }

        // GET: ParentYuGiOhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentYuGiOh parentYuGiOh = db.ParentYuGiOh.Find(id);
            if (parentYuGiOh == null)
            {
                return HttpNotFound();
            }
            return View(parentYuGiOh);
        }

        // POST: ParentYuGiOhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParentYuGiOh parentYuGiOh = db.ParentYuGiOh.Find(id);
            db.ParentYuGiOh.Remove(parentYuGiOh);
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

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
    public class ParentPokemonController : Controller
    {
        private PokemonModel db = new PokemonModel();

        // GET: tblParents
        public ActionResult Index(int? id)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.parentPokemon = db.ParentPokemon;

            if (id != null)
            {
                // Child objecten bij Parent objecten ophalen
                ViewBag.ParentID = id.Value;
                viewModel.childPokemons = viewModel.parentPokemon.Where(i => i.ID == id.Value).Single().ChildPokemon;
            }
            //return View(db.tblParent.ToList());
            return View(viewModel);
        }

        // GET: ParentPokemons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentPokemon parentPokemon = db.ParentPokemon.Find(id);
            if (parentPokemon == null)
            {
                return HttpNotFound();
            }
            return View(parentPokemon);
        }

        // GET: ParentPokemons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentPokemons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Categorie,Status")] ParentPokemon parentPokemon)
        {
            if (ModelState.IsValid)
            {
                db.ParentPokemon.Add(parentPokemon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parentPokemon);
        }

        // GET: ParentPokemons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentPokemon parentPokemon = db.ParentPokemon.Find(id);
            if (parentPokemon == null)
            {
                return HttpNotFound();
            }
            return View(parentPokemon);
        }

        // POST: ParentPokemons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Categorie,Status")] ParentPokemon parentPokemon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentPokemon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentPokemon);
        }

        public ActionResult Akkorderen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentPokemon parentPokemon = db.ParentPokemon.Find(id);
            if (parentPokemon == null)
            {
                return HttpNotFound();
            }
            return View(parentPokemon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Akkorderen([Bind(Include = "ID,Name,Categorie,Status")] ParentPokemon parentPokemon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentPokemon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentPokemon);
        }

        // GET: ParentPokemons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentPokemon parentPokemon = db.ParentPokemon.Find(id);
            if (parentPokemon == null)
            {
                return HttpNotFound();
            }
            return View(parentPokemon);
        }

        // POST: ParentPokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParentPokemon parentPokemon = db.ParentPokemon.Find(id);
            db.ParentPokemon.Remove(parentPokemon);
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

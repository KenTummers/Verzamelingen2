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
    public class ChildPokemonController : Controller
    {
        private PokemonModel db = new PokemonModel();

        // GET: ChildPokemon
        public ActionResult Index()
        {
            var childPokemons = db.ChildPokemon.Include(c => c.ParentPokemon);
            return View(childPokemons.ToList());
        }

        // GET: ChildPokemon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildPokemon childPokemons = db.ChildPokemon.Find(id);
            if (childPokemons == null)
            {
                return HttpNotFound();
            }
            return View(childPokemons);
        }

        // GET: ChildPokemon/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.ParentPokemon, "ID", "Name");
            return View();
        }

        // POST: ChildPokemon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ParentID,Categorie,Waarde,Prijs,Type,Number,Status")] ChildPokemon childPokemons)
        {
            if (ModelState.IsValid)
            {
                db.ChildPokemon.Add(childPokemons);
                db.SaveChanges();
                return RedirectToAction("../ParentPokemon/Index");
            }

            ViewBag.ParentID = new SelectList(db.ParentPokemon, "ID", "Name", childPokemons.ParentID);
            return View(childPokemons);
        }

        // GET: ChildPokemon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildPokemon childPokemons = db.ChildPokemon.Find(id);
            if (childPokemons == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.ParentPokemon, "ID", "Name", childPokemons.ParentID);
            return View(childPokemons);
        }

        // POST: ChildPokemon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ParentID,Categorie,Waarde,Prijs,Type,Number,Status")] ChildPokemon childPokemons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childPokemons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../ParentPokemon/Index");
            }
            ViewBag.ParentID = new SelectList(db.ParentPokemon, "ID", "Name", childPokemons.ParentID);
            return View(childPokemons);
        }

        public ActionResult Akkorderen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildPokemon childPokemons = db.ChildPokemon.Find(id);
            if (childPokemons == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.ParentPokemon, "ID", "Name", childPokemons.ParentID);
            return View(childPokemons);
        }

        // POST: ChildPokemon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Akkorderen([Bind(Include = "ID,Name,ParentID,Categorie,Waarde,Prijs,Type,Number,Status")] ChildPokemon childPokemons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childPokemons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../ParentPokemon/Index");
            }
            ViewBag.ParentID = new SelectList(db.ParentPokemon, "ID", "Name", childPokemons.ParentID);
            return View(childPokemons);
        }

        // GET: ChildPokemon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildPokemon childPokemons = db.ChildPokemon.Find(id);
            if (childPokemons == null)
            {
                return HttpNotFound();
            }
            return View(childPokemons);
        }

        // POST: ChildPokemon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChildPokemon childPokemons = db.ChildPokemon.Find(id);
            db.ChildPokemon.Remove(childPokemons);
            db.SaveChanges();
            return RedirectToAction("../ParentPokemon/Index");
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

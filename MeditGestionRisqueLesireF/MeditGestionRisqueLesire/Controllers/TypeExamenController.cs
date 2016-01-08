using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeditGestionRisqueLesire.Models;

namespace MeditGestionRisqueLesire.Controllers
{
    public class TypeExamenController : Controller
    {
        private DBIG3A2Entities db = new DBIG3A2Entities();

        // GET: TypeExamen
        public ActionResult Index()
        {
            var typeExamen = db.TypeExamen.Include(t => t.Compte);
            return View(typeExamen.ToList());
        }

        // GET: TypeExamen/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeExaman typeExaman = db.TypeExamen.Find(id);
            if (typeExaman == null)
            {
                return HttpNotFound();
            }
            return View(typeExaman);
        }

        // GET: TypeExamen/Create
        public ActionResult Create()
        {
            ViewBag.IdCompte = new SelectList(db.Comptes, "IdCompte", "IdCompte");
            return View();
        }

        // POST: TypeExamen/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdExamen,PrixTravailleurSoumis,PrixTravailleurNonSoumis,IdCompte")] TypeExaman typeExaman)
        {
            if (ModelState.IsValid)
            {
                db.TypeExamen.Add(typeExaman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompte = new SelectList(db.Comptes, "IdCompte", "IdCompte", typeExaman.IdCompte);
            return View(typeExaman);
        }

        // GET: TypeExamen/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeExaman typeExaman = db.TypeExamen.Find(id);
            if (typeExaman == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompte = new SelectList(db.Comptes, "IdCompte", "IdCompte", typeExaman.IdCompte);
            return View(typeExaman);
        }

        // POST: TypeExamen/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdExamen,PrixTravailleurSoumis,PrixTravailleurNonSoumis,IdCompte")] TypeExaman typeExaman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeExaman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompte = new SelectList(db.Comptes, "IdCompte", "IdCompte", typeExaman.IdCompte);
            return View(typeExaman);
        }

        // GET: TypeExamen/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeExaman typeExaman = db.TypeExamen.Find(id);
            if (typeExaman == null)
            {
                return HttpNotFound();
            }
            return View(typeExaman);
        }

        // POST: TypeExamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TypeExaman typeExaman = db.TypeExamen.Find(id);
            db.TypeExamen.Remove(typeExaman);
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

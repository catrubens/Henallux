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
    public class TravailleursController : Controller
    {
        private DBIG3A2Entities db = new DBIG3A2Entities();

        // GET: Travailleurs
        public ActionResult Index()
        {
            var travailleurs = db.Travailleurs.Include(t => t.Adresse);
            return View(travailleurs.ToList());
        }

        // GET: Travailleurs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travailleur travailleur = db.Travailleurs.Find(id);
            if (travailleur == null)
            {
                return HttpNotFound();
            }
            return View(travailleur);
        }

        // GET: Travailleurs/Create
        public ActionResult Create()
        {
            ViewBag.IdAdresse = new SelectList(db.Adresses, "IdAdresse", "Numero");
            return View();
        }

        // POST: Travailleurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTravailleur,Nom,Prenom,NumeroDossier,IdAdresse")] Travailleur travailleur)
        {
            if (ModelState.IsValid)
            {
                db.Travailleurs.Add(travailleur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAdresse = new SelectList(db.Adresses, "IdAdresse", "Numero", travailleur.IdAdresse);
            return View(travailleur);
        }

        // GET: Travailleurs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travailleur travailleur = db.Travailleurs.Find(id);
            if (travailleur == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAdresse = new SelectList(db.Adresses, "IdAdresse", "Numero", travailleur.IdAdresse);
            return View(travailleur);
        }

        // POST: Travailleurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTravailleur,Nom,Prenom,NumeroDossier,IdAdresse")] Travailleur travailleur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travailleur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAdresse = new SelectList(db.Adresses, "IdAdresse", "Numero", travailleur.IdAdresse);
            return View(travailleur);
        }

        // GET: Travailleurs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travailleur travailleur = db.Travailleurs.Find(id);
            if (travailleur == null)
            {
                return HttpNotFound();
            }
            return View(travailleur);
        }

        // POST: Travailleurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Travailleur travailleur = db.Travailleurs.Find(id);
            db.Travailleurs.Remove(travailleur);
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

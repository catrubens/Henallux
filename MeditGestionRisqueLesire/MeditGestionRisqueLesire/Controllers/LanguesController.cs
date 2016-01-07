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
    public class LanguesController : Controller
    {
        private DBIG3A2Entities db = new DBIG3A2Entities();

        // GET: Langues
        public ActionResult Index()
        {
            ViewData["langues"] = new SelectList(db.Langues.ToList(), "IdLangue", "Nom");
            return View(new Models.ChoixLangue());
        }

        public ActionResult Select([Bind(Include = "IdLangue")]Models.ChoixLangue selection)
        {

            if (selection == null)
                return HttpNotFound();
            Langue langue = db.Langues.Find(selection.IdLangue);
            if (langue == null)
                return HttpNotFound();
         
            Session["selectionLangue"] = selection.IdLangue;
            return View("ConfirmationSelectionLangue", langue);
        }

        // GET: Langues/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langues.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            return View(langue);
        }

        // GET: Langues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Langues/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLangue,Nom")] Langue langue)
        {
            if (ModelState.IsValid)
            {
                db.Langues.Add(langue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(langue);
        }

        // GET: Langues/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langues.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            return View(langue);
        }

        // POST: Langues/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLangue,Nom")] Langue langue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(langue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(langue);
        }

        // GET: Langues/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langues.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            return View(langue);
        }

        // POST: Langues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Langue langue = db.Langues.Find(id);
            db.Langues.Remove(langue);
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

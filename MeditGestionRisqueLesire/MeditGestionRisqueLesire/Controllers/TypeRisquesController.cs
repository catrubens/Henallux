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
    public class TypeRisquesController : Controller
    {
        private DBIG3A2Entities db = new DBIG3A2Entities();

        // GET: TypeRisques
        public ActionResult Index()
        {
           return View(db.TypeRisques.ToList());
        }

        // GET: TypeRisques/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRisque typeRisque = db.TypeRisques.Find(id);
            if (typeRisque == null)
            {
                return HttpNotFound();
            }
            return View(typeRisque);
        }

        // GET: TypeRisques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeRisques/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRisque")] TypeRisque typeRisque)
        {
            if (ModelState.IsValid)
            {
                db.TypeRisques.Add(typeRisque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeRisque);
        }

        // GET: TypeRisques/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRisque typeRisque = db.TypeRisques.Find(id);
            if (typeRisque == null)
            {
                return HttpNotFound();
            }
            return View(typeRisque);
        }

        // POST: TypeRisques/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRisque")] TypeRisque typeRisque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeRisque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeRisque);
        }

        // GET: TypeRisques/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRisque typeRisque = db.TypeRisques.Find(id);
            if (typeRisque == null)
            {
                return HttpNotFound();
            }
            return View(typeRisque);
        }

        // POST: TypeRisques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TypeRisque typeRisque = db.TypeRisques.Find(id);
            db.TypeRisques.Remove(typeRisque);
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

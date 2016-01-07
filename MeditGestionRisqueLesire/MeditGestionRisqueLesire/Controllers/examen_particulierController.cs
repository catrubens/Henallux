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
    public class examen_particulierController : Controller
    {
        private DBIG3A2Entities db = new DBIG3A2Entities();

        // GET: examen_particulier
        public ActionResult Index()
        {
            var emploisSoumis = db.Emplois.Where(x => x.TypeTravail.Equals("soumis")).ToList();
            var TraductionProfession = db.TraductionProfessions.ToList();
            var liste = new List<MeditGestionRisqueLesire.Models.TraductionProfession>();

            foreach (var es in emploisSoumis)
            {
                foreach (var tp in TraductionProfession)
                {
                    if (tp.CodeAlpha.Equals(es.CodeAlpha))
                        liste.Add(tp);
                }
            }

            ViewData["Entreprise"] = new SelectList(db.Entreprises.ToList().OrderBy(x => x.Denomination), "Numero", "Denomination");
            ViewData["Examen"] = new SelectList(db.TraductionExamen.ToList().Where(f => f.IdLangue == (Decimal)Session["selectionLangue"]).OrderBy(x => x.Denomination), "IdTraductionExemen", "Denomination");

            return View(new Models.ChoixAssocier());
        }

        public JsonResult GetEmploi(int id)
        {
            var liste = new List<MeditGestionRisqueLesire.Models.TraductionProfession>();
            var TraductionProfession = db.TraductionProfessions.ToList();
            var emploisSoumis = db.Emplois.Where(x => x.TypeTravail.Equals("soumis")).ToList();
            var emploisSoumisEntreprise = emploisSoumis.Where(x => x.Numero == (Decimal)id);

            foreach (var es in emploisSoumisEntreprise)
            {
                foreach (var tp in TraductionProfession)
                {
                    if (tp.CodeAlpha.Equals(es.CodeAlpha))
                        liste.Add(tp);
                }
            }
            return Json(new SelectList(liste.Where(f => f.IdLangue == (Decimal)Session["selectionLangue"]).Distinct(), "IdTraductionProfession", "LibelleProfession"));
        }

        public JsonResult GetTravailleur(string emploi, int idEntreprise)
        {
            var liste = new List<MeditGestionRisqueLesire.Models.Travailleur>();
            var emploisSoumis = db.Emplois.Where(x => x.TypeTravail.Equals("soumis") && x.Entreprise.Numero == (Decimal)idEntreprise).ToList();
            var traduction = db.TraductionProfessions.Where(x => x.LibelleProfession.Equals(emploi)).Select(i => i.CodeAlpha).ToList();
            foreach (var es in emploisSoumis)
            {
                if (es.CodeAlpha.Equals(traduction[0]))
                    liste.Add(es.Travailleur);
            }
            return Json(new SelectList(liste.OrderBy(x => x.Nom).Distinct(), "IdTravailleur", ToString().ToList()));
        }

        // GET: examen_particulier/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examen_particulier examen_particulier = db.examen_particulier.Find(id);
            if (examen_particulier == null)
            {
                return HttpNotFound();
            }
            return View(examen_particulier);
        }

        // GET: examen_particulier/Create
        public ActionResult Create()
        {
            ViewBag.IdEmploi = new SelectList(db.Emplois, "IdEmploi", "TypeTravail");
            ViewBag.IdExamen = new SelectList(db.TypeExamen, "IdExamen", "IdExamen");
            return View();
        }

        // POST: examen_particulier/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Travailleur,IdEntreprise,StringEmploi")] ChoixAssocier selection)
        {
            if (ModelState.IsValid)
            {
                var examen = new examen_particulier();

                var idprofession = db.TraductionProfessions.Where(x => x.LibelleProfession.Equals(selection.StringEmploi)).Select(i => i.CodeAlpha).First();

                var nomEtPrenom = selection.Travailleur.Split();
                var nom = nomEtPrenom[0].ToString();
                var prenom = nomEtPrenom[1].ToString();
                var travailleur = db.Travailleurs.Where(x => x.Nom.Equals(nom) && x.Prenom.Equals(prenom)).First();
                var emploi = db.Emplois.Where(x => x.Numero == selection.IdEntreprise && x.CodeAlpha.Equals(idprofession) && x.IdTravailleur == travailleur.IdTravailleur).First();
                var typeExamen = db.TraductionExamen.Where(e => e.IdTraductionExemen == selection.Id).Select(x=>x.TypeExaman).First();
                examen.IdExamen = typeExamen.IdExamen;
                examen.IdEmploi = emploi.IdEmploi;
                db.examen_particulier.Add(examen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
        // GET: examen_particulier/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examen_particulier examen_particulier = db.examen_particulier.Find(id);
            if (examen_particulier == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmploi = new SelectList(db.Emplois, "IdEmploi", "TypeTravail", examen_particulier.IdEmploi);
            ViewBag.IdExamen = new SelectList(db.TypeExamen, "IdExamen", "IdExamen", examen_particulier.IdExamen);
            return View(examen_particulier);
        }

        // POST: examen_particulier/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdExamenParticulier,IdExamen,IdEmploi")] examen_particulier examen_particulier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examen_particulier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmploi = new SelectList(db.Emplois, "IdEmploi", "TypeTravail", examen_particulier.IdEmploi);
            ViewBag.IdExamen = new SelectList(db.TypeExamen, "IdExamen", "IdExamen", examen_particulier.IdExamen);
            return View(examen_particulier);
        }

        // GET: examen_particulier/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examen_particulier examen_particulier = db.examen_particulier.Find(id);
            if (examen_particulier == null)
            {
                return HttpNotFound();
            }
            return View(examen_particulier);
        }

        // POST: examen_particulier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            examen_particulier examen_particulier = db.examen_particulier.Find(id);
            db.examen_particulier.Remove(examen_particulier);
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

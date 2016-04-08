using BibliothequeLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIBibliotheque.Models;

namespace WebAPIBibliotheque.Controllers
{
    public class categoriesController : ApiController
    {
        private bibliothequeEntities1 db = new bibliothequeEntities1();

        // GET: api/categories
        public IEnumerable<Categorie> Getcategories()
        {
            var queryResult = db.categories.ToList();

            List<Categorie> listCategorie = new List<Categorie>();

            foreach (var c in queryResult)
            {
                Categorie categorie = new Categorie();
                categorie.CodeCategorie = c.CodeCategorie;
                categorie.LibelleCategorie = c.LibelleCategorie;
                listCategorie.Add(categorie);
            }

            return listCategorie;
        }
        /*

        // GET: api/categories/5
        [ResponseType(typeof(categorie))]
        public IHttpActionResult Getcategorie(string id)
        {
            categorie categorie = db.categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            return Ok(categorie);
        }

        // PUT: api/categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcategorie(string id, categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorie.CodeCategorie)
            {
                return BadRequest();
            }

            db.Entry(categorie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categorieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/categories
        [ResponseType(typeof(categorie))]
        public IHttpActionResult Postcategorie(categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.categories.Add(categorie);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (categorieExists(categorie.CodeCategorie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categorie.CodeCategorie }, categorie);
        }

        // DELETE: api/categories/5
        [ResponseType(typeof(categorie))]
        public IHttpActionResult Deletecategorie(string id)
        {
            categorie categorie = db.categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            db.categories.Remove(categorie);
            db.SaveChanges();

            return Ok(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categorieExists(string id)
        {
            return db.categories.Count(e => e.CodeCategorie == id) > 0;
        }
        */
    }
}
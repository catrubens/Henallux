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
    public class borrowersController : ApiController
    {
        private bibliothequeEntities1 db = new bibliothequeEntities1();

        [HttpGet, ActionName("searchBorrowerByEmail")]
        public Borrower searchBorrowerByEmailInDataBase(string email)
        {
            var queryResult = (from bo in db.borrowers
                               where bo.Email == email
                               select bo).Single();

            Borrower borrower = new Borrower();
            borrower.Adresse = queryResult.Adresse;
            borrower.Email = queryResult.Email;
            borrower.FirstNameBorrower = queryResult.FirstNameBorrower;
            borrower.Gsm = queryResult.GSM;
            borrower.NameBorrower = queryResult.NameBorrower;
            borrower.NumTelephone = queryResult.NumTelephone;
            borrower.Password = queryResult.Password;

            return borrower;
        }

        /*
        // GET: api/borrowers
        public IQueryable<borrower> Getborrowers()
        {
            return db.borrowers;
        }

        // GET: api/borrowers/5
        [ResponseType(typeof(borrower))]
        public IHttpActionResult Getborrower(string id)
        {
            borrower borrower = db.borrowers.Find(id);
            if (borrower == null)
            {
                return NotFound();
            }

            return Ok(borrower);
        }

        // PUT: api/borrowers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putborrower(string id, borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != borrower.Email)
            {
                return BadRequest();
            }

            db.Entry(borrower).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!borrowerExists(id))
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

        // POST: api/borrowers
        [ResponseType(typeof(borrower))]
        public IHttpActionResult Postborrower(borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.borrowers.Add(borrower);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (borrowerExists(borrower.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = borrower.Email }, borrower);
        }

        // DELETE: api/borrowers/5
        [ResponseType(typeof(borrower))]
        public IHttpActionResult Deleteborrower(string id)
        {
            borrower borrower = db.borrowers.Find(id);
            if (borrower == null)
            {
                return NotFound();
            }

            db.borrowers.Remove(borrower);
            db.SaveChanges();

            return Ok(borrower);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool borrowerExists(string id)
        {
            return db.borrowers.Count(e => e.Email == id) > 0;
        }
        */
    }
}
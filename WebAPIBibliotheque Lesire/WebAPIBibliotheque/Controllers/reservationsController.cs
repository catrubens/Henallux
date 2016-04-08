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
    public class reservationsController : ApiController
    {
        private bibliothequeEntities1 db = new bibliothequeEntities1();

        [HttpPost, ActionName("addReservation")]
        public IHttpActionResult addReservationInDataBase(string email, string content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            reservation reservation = new reservation();
            reservation.Email = email;
            reservation.DateReservation = DateTime.Now;

            var listBook = new List<book>();
            List<string> listNumBook = (List<string>)Newtonsoft.Json.JsonConvert.DeserializeObject(content, typeof(List<string>));

            
            foreach ( var bookAdd in listNumBook)
            {
                var bookSearch = (from b in db.books
                                  where b.NumBook == bookAdd
                                  select b).First();

                listBook.Add(bookSearch);
            }

            reservation.books = listBook;
            db.reservations.Add(reservation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = reservation.NumReservation }, content);
        }

        /*
        // GET: api/reservations
        public IQueryable<reservation> Getreservations()
        {
            return db.reservations;
        }

        // GET: api/reservations/5
        [ResponseType(typeof(reservation))]
        public IHttpActionResult Getreservation(int id)
        {
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/reservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putreservation(int id, reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.NumReservation)
            {
                return BadRequest();
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reservationExists(id))
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

        // POST: api/reservations
        [ResponseType(typeof(reservation))]
        public IHttpActionResult Postreservation(reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.reservations.Add(reservation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (reservationExists(reservation.NumReservation))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reservation.NumReservation }, reservation);
        }

        // DELETE: api/reservations/5
        [ResponseType(typeof(reservation))]
        public IHttpActionResult Deletereservation(int id)
        {
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            db.reservations.Remove(reservation);
            db.SaveChanges();

            return Ok(reservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool reservationExists(int id)
        {
            return db.reservations.Count(e => e.NumReservation == id) > 0;
        }
        */
    }
}
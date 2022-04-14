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
using ApiFarmacia.Models;

namespace ApiFarmacia.Controllers
{
    public class EstantesController : ApiController
    {
        private ModelFarmacia db = new ModelFarmacia();

        // GET: api/Estantes
        public IQueryable<Estante> GetEstante()
        {
            return db.Estante;
        }

        // GET: api/Estantes/5
        [ResponseType(typeof(Estante))]
        public IHttpActionResult GetEstante(int id)
        {
            Estante estante = db.Estante.Find(id);
            if (estante == null)
            {
                return NotFound();
            }

            return Ok(estante);
        }

        // PUT: api/Estantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstante(int id, Estante estante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estante.Id)
            {
                return BadRequest();
            }

            db.Entry(estante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstanteExists(id))
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

        // POST: api/Estantes
        [ResponseType(typeof(Estante))]
        public IHttpActionResult PostEstante(Estante estante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estante.Add(estante);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EstanteExists(estante.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estante.Id }, estante);
        }

        // DELETE: api/Estantes/5
        [ResponseType(typeof(Estante))]
        public IHttpActionResult DeleteEstante(int id)
        {
            Estante estante = db.Estante.Find(id);
            if (estante == null)
            {
                return NotFound();
            }

            db.Estante.Remove(estante);
            db.SaveChanges();

            return Ok(estante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstanteExists(int id)
        {
            return db.Estante.Count(e => e.Id == id) > 0;
        }
    }
}
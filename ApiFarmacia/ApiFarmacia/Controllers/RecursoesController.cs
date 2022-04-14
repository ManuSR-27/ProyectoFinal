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
    public class RecursoesController : ApiController
    {
        private ModelFarmacia db = new ModelFarmacia();

        // GET: api/Recursoes
        public IQueryable<Recurso> GetRecurso()
        {
            return db.Recurso;
        }

        // GET: api/Recursoes/5
        [ResponseType(typeof(Recurso))]
        public IHttpActionResult GetRecurso(int id)
        {
            Recurso recurso = db.Recurso.Find(id);
            if (recurso == null)
            {
                return NotFound();
            }

            return Ok(recurso);
        }

        // PUT: api/Recursoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecurso(int id, Recurso recurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recurso.Id)
            {
                return BadRequest();
            }

            db.Entry(recurso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(id))
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

        // POST: api/Recursoes
        [ResponseType(typeof(Recurso))]
        public IHttpActionResult PostRecurso(Recurso recurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recurso.Add(recurso);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RecursoExists(recurso.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = recurso.Id }, recurso);
        }

        // DELETE: api/Recursoes/5
        [ResponseType(typeof(Recurso))]
        public IHttpActionResult DeleteRecurso(int id)
        {
            Recurso recurso = db.Recurso.Find(id);
            if (recurso == null)
            {
                return NotFound();
            }

            db.Recurso.Remove(recurso);
            db.SaveChanges();

            return Ok(recurso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecursoExists(int id)
        {
            return db.Recurso.Count(e => e.Id == id) > 0;
        }
    }
}
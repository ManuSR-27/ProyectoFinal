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
    public class DomiciliarioController : ApiController
    {
        private ModelFarmacia db = new ModelFarmacia();

        // GET: api/Domiciliario
        public IQueryable<Domiciliario> GetDomiciliario()
        {
            return db.Domiciliario;
        }

        // GET: api/Domiciliario/5
        [ResponseType(typeof(Domiciliario))]
        public IHttpActionResult GetDomiciliario(int id)
        {
            Domiciliario domiciliario = db.Domiciliario.Find(id);
            if (domiciliario == null)
            {
                return NotFound();
            }

            return Ok(domiciliario);
        }

        // PUT: api/Domiciliario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDomiciliario(int id, Domiciliario domiciliario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != domiciliario.Id)
            {
                return BadRequest();
            }

            db.Entry(domiciliario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomiciliarioExists(id))
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

        // POST: api/Domiciliario
        [ResponseType(typeof(Domiciliario))]
        public IHttpActionResult PostDomiciliario(Domiciliario domiciliario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Domiciliario.Add(domiciliario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DomiciliarioExists(domiciliario.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = domiciliario.Id }, domiciliario);
        }

        // DELETE: api/Domiciliario/5
        [ResponseType(typeof(Domiciliario))]
        public IHttpActionResult DeleteDomiciliario(int id)
        {
            Domiciliario domiciliario = db.Domiciliario.Find(id);
            if (domiciliario == null)
            {
                return NotFound();
            }

            db.Domiciliario.Remove(domiciliario);
            db.SaveChanges();

            return Ok(domiciliario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DomiciliarioExists(int id)
        {
            return db.Domiciliario.Count(e => e.Id == id) > 0;
        }
    }
}
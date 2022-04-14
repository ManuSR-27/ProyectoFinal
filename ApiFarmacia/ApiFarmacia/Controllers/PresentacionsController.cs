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
    public class PresentacionsController : ApiController
    {
        private ModelFarmacia db = new ModelFarmacia();

        // GET: api/Presentacions
        public IQueryable<Presentacion> GetPresentacion()
        {
            return db.Presentacion;
        }

        // GET: api/Presentacions/5
        [ResponseType(typeof(Presentacion))]
        public IHttpActionResult GetPresentacion(int id)
        {
            Presentacion presentacion = db.Presentacion.Find(id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return Ok(presentacion);
        }

        // PUT: api/Presentacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPresentacion(int id, Presentacion presentacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != presentacion.Id)
            {
                return BadRequest();
            }

            db.Entry(presentacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentacionExists(id))
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

        // POST: api/Presentacions
        [ResponseType(typeof(Presentacion))]
        public IHttpActionResult PostPresentacion(Presentacion presentacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Presentacion.Add(presentacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PresentacionExists(presentacion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = presentacion.Id }, presentacion);
        }

        // DELETE: api/Presentacions/5
        [ResponseType(typeof(Presentacion))]
        public IHttpActionResult DeletePresentacion(int id)
        {
            Presentacion presentacion = db.Presentacion.Find(id);
            if (presentacion == null)
            {
                return NotFound();
            }

            db.Presentacion.Remove(presentacion);
            db.SaveChanges();

            return Ok(presentacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PresentacionExists(int id)
        {
            return db.Presentacion.Count(e => e.Id == id) > 0;
        }
    }
}
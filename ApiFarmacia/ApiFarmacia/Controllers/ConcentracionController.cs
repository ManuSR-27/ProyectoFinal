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
    public class ConcentracionController : ApiController
    {
        private ModelFarmacia db = new ModelFarmacia();

        // GET: api/Concentracion
        public IQueryable<Concentracion> GetConcentracion()
        {
            return db.Concentracion;
        }

        // GET: api/Concentracion/5
        [ResponseType(typeof(Concentracion))]
        public IHttpActionResult GetConcentracion(int id)
        {
            Concentracion concentracion = db.Concentracion.Find(id);
            if (concentracion == null)
            {
                return NotFound();
            }

            return Ok(concentracion);
        }

        // PUT: api/Concentracion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConcentracion(int id, Concentracion concentracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != concentracion.Id)
            {
                return BadRequest();
            }

            db.Entry(concentracion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcentracionExists(id))
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

        // POST: api/Concentracion
        [ResponseType(typeof(Concentracion))]
        public IHttpActionResult PostConcentracion(Concentracion concentracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Concentracion.Add(concentracion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ConcentracionExists(concentracion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = concentracion.Id }, concentracion);
        }

        // DELETE: api/Concentracion/5
        [ResponseType(typeof(Concentracion))]
        public IHttpActionResult DeleteConcentracion(int id)
        {
            Concentracion concentracion = db.Concentracion.Find(id);
            if (concentracion == null)
            {
                return NotFound();
            }

            db.Concentracion.Remove(concentracion);
            db.SaveChanges();

            return Ok(concentracion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConcentracionExists(int id)
        {
            return db.Concentracion.Count(e => e.Id == id) > 0;
        }
    }
}
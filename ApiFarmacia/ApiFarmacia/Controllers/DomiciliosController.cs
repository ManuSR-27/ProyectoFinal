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
    public class DomiciliosController : ApiController
    {
        private ModelFarmacia db = new ModelFarmacia();

        // GET: api/Domicilios
        public IQueryable<Domicilio> GetDomicilio()
        {
            return db.Domicilio;
        }

        // GET: api/Domicilios/5
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult GetDomicilio(int id)
        {
            Domicilio domicilio = db.Domicilio.Find(id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return Ok(domicilio);
        }

        // PUT: api/Domicilios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDomicilio(int id, Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            db.Entry(domicilio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomicilioExists(id))
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

        // POST: api/Domicilios
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult PostDomicilio(Domicilio domicilio)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Domicilio.Add(domicilio);

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    String err = ex.Message;
                }
            }
            catch (Exception ex)
            {

                string err = ex.Message;
            }
          

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/Domicilios/5
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult DeleteDomicilio(int id)
        {
            Domicilio domicilio = db.Domicilio.Find(id);
            if (domicilio == null)
            {
                return NotFound();
            }

            db.Domicilio.Remove(domicilio);
            db.SaveChanges();

            return Ok(domicilio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DomicilioExists(int id)
        {
            return true;
        }
    }
}
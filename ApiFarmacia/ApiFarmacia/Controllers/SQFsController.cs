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
    public class SQFsController : ApiController
    {
        private ModelFarmacia db = new ModelFarmacia();

        // GET: api/SQFs
        public IQueryable<SQF> GetSQF()
        {
            return db.SQF;
        }

        // GET: api/SQFs/5
        [ResponseType(typeof(SQF))]
        public IHttpActionResult GetSQF(int id)
        {
            SQF sQF = db.SQF.Find(id);
            if (sQF == null)
            {
                return NotFound();
            }

            return Ok(sQF);
        }

        // PUT: api/SQFs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSQF(int id, SQF sQF)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sQF.Id)
            {
                return BadRequest();
            }

            db.Entry(sQF).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SQFExists(id))
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

        // POST: api/SQFs
        [ResponseType(typeof(SQF))]
        public IHttpActionResult PostSQF(SQF sQF)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SQF.Add(sQF);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SQFExists(sQF.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sQF.Id }, sQF);
        }

        // DELETE: api/SQFs/5
        [ResponseType(typeof(SQF))]
        public IHttpActionResult DeleteSQF(int id)
        {
            SQF sQF = db.SQF.Find(id);
            if (sQF == null)
            {
                return NotFound();
            }

            db.SQF.Remove(sQF);
            db.SaveChanges();

            return Ok(sQF);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SQFExists(int id)
        {
            return db.SQF.Count(e => e.Id == id) > 0;
        }
    }
}
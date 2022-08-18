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
using SessionMobileAPI.Models;

namespace SessionMobileAPI.Controllers
{
    public class RelatosController : ApiController
    {
        private SessaoMobileEntities db = new SessaoMobileEntities();

        // GET: api/Relatos
        public IQueryable<Relatos> GetRelatos()
        {
            return db.Relatos;
        }

        // GET: api/Relatos/5
        [ResponseType(typeof(Relatos))]
        public IHttpActionResult GetRelatos(int id)
        {
            Relatos relatos = db.Relatos.Find(id);
            if (relatos == null)
            {
                return NotFound();
            }

            return Ok(relatos);
        }

        // PUT: api/Relatos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelatos(int id, Relatos relatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relatos.id)
            {
                return BadRequest();
            }

            db.Entry(relatos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelatosExists(id))
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

        // POST: api/Relatos
        [ResponseType(typeof(Relatos))]
        public IHttpActionResult PostRelatos(Relatos relatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Relatos.Add(relatos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = relatos.id }, relatos);
        }

        // DELETE: api/Relatos/5
        [ResponseType(typeof(Relatos))]
        public IHttpActionResult DeleteRelatos(int id)
        {
            Relatos relatos = db.Relatos.Find(id);
            if (relatos == null)
            {
                return NotFound();
            }

            db.Relatos.Remove(relatos);
            db.SaveChanges();

            return Ok(relatos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelatosExists(int id)
        {
            return db.Relatos.Count(e => e.id == id) > 0;
        }
    }
}
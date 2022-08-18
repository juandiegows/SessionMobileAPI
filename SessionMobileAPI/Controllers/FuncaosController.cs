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
    public class FuncaosController : ApiController
    {
        private SessaoMobileEntities db = new SessaoMobileEntities();

        // GET: api/Funcaos
        public IQueryable<VFuncao> GetFuncao()
        {

            return db.VFuncao;
        }

        // GET: api/Funcaos/5
        [ResponseType(typeof(VFuncao))]
        public IHttpActionResult GetFuncao(int id)
        {
            VFuncao funcao = db.VFuncao.Find(id);
            if (funcao == null)
            {
                return NotFound();
            }

            return Ok(funcao);
        }

        // PUT: api/Funcaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncao(int id, Funcao funcao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcao.id)
            {
                return BadRequest();
            }

            db.Entry(funcao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncaoExists(id))
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

        // POST: api/Funcaos
        [ResponseType(typeof(Funcao))]
        public IHttpActionResult PostFuncao(Funcao funcao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Funcao.Add(funcao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = funcao.id }, funcao);
        }

        // DELETE: api/Funcaos/5
        [ResponseType(typeof(Funcao))]
        public IHttpActionResult DeleteFuncao(int id)
        {
            Funcao funcao = db.Funcao.Find(id);
            if (funcao == null)
            {
                return NotFound();
            }

            db.Funcao.Remove(funcao);
            db.SaveChanges();

            return Ok(funcao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncaoExists(int id)
        {
            return db.Funcao.Count(e => e.id == id) > 0;
        }
    }
}
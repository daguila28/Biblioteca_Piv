using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Http.Description;

namespace Biblioteca.Host.Controllers
{
    public class EditorialController : ApiController
    {
        BibliotecaContext bibliotecacontext = new BibliotecaContext("BibliotecaLocal1");

        protected override void Dispose(bool disposing)
        {
           if(disposing)
            {
                bibliotecacontext.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: api/Editorial
        public IEnumerable<Editorial> Get()
        {
           return bibliotecacontext.Editoriales;
            
        }

        // GET: api/Editorial/5
        [ResponseType(typeof(Editorial))]

        public IHttpActionResult Get(int id)
        {
          var editorial =  bibliotecacontext.Editoriales.Find(id);
          if(editorial == null)
            {
               return NotFound();
            }
            else
            {
               return Ok(editorial);
            }
        }

        // POST: api/Editorial
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Post(Editorial nuevoEditorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bibliotecacontext.Editoriales.Add(nuevoEditorial);
            bibliotecacontext.SaveChanges();
            return Ok(nuevoEditorial);

        }

        // PUT: api/Editorial/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Put(int id, Editorial editorial)
        {
            if(id != editorial.Id)
            {
             return  BadRequest(ModelState);
            }
            bibliotecacontext.Entry(editorial).State = System.Data.Entity.EntityState.Modified;
            bibliotecacontext.SaveChanges();
            return Ok(editorial);
        }

        // DELETE: api/Editorial/5
        public IHttpActionResult Delete(int id)
        {
            var editorial = bibliotecacontext.Editoriales.Find(id);
            if(editorial == null)
            {
                return NotFound();
            }
            bibliotecacontext.Editoriales.Remove(editorial);
            bibliotecacontext.SaveChanges();
            return Ok();
        }
    }
}

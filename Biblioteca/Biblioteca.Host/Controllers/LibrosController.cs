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
    public class LibrosController : ApiController
    {
        BibliotecaContext bibliotecacontex = new BibliotecaContext("bliotecaLocal1");
        // GET: api/Libros
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Libros/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Libros
        [ResponseType(typeof(Libro))]
        public IHttpActionResult Post(Libro nuevoLibro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bibliotecacontex.Libros.Add(nuevoLibro);
            bibliotecacontex.SaveChanges();
            return Ok(nuevoLibro);
        }

        // PUT: api/Libros/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Libros/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Biblioteca.Data.Modelos;

namespace Biblioteca.Data
{
    public class BibliotecaContext:DbContext
    {
        public BibliotecaContext() { }
        public BibliotecaContext(String ConnectionName):base(ConnectionName)//le envia connectionName al padre, osea al program.cs
        {

        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales{ get; set; }
    }
}

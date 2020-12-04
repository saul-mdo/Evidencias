using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaModoDesconectado.Models;

namespace LibreriaModoDesconectado.Repositories
{
    public class LibrosRepository
    {
        bdlibrodescEntities contexto = new bdlibrodescEntities();

        public IEnumerable<libro> GetAll()
        {
            return contexto.libro.OrderBy(x => x.Titulo);
        }

        public void Add(libro L)
        {
            contexto.libro.Add(L);
            contexto.SaveChanges();
        }

        public void Delete(libro L)
        {
            var lib = contexto.libro.FirstOrDefault(x => x.IdLibro == L.IdLibro);
            if(lib!=null)
            {
                contexto.libro.Remove(lib);
                contexto.SaveChanges();
            }
        }

        public void Update(libro L)
        {
            var lib = contexto.libro.FirstOrDefault(x => x.IdLibro == L.IdLibro);
            if(lib != null)
            {
                lib.Titulo = L.Titulo;
                lib.Autor = L.Autor;
                lib.NUmPaginas = L.NUmPaginas;
                lib.Editorial = L.Editorial;
                contexto.SaveChanges();
            }
        }

    }
}

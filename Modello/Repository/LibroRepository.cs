using Libri_application.Models.Context;
using Libri_application.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Repository
{
    public class LibroRepository : GenericRepository<Libro>
    {
        public LibroRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public override Libro Get(object id)
        {
            return _ctx.Set<Libro>().Include(c=>c.categorie).Include(x =>x.autori).Where(x => x.id == id).FirstOrDefault();
        }

        public bool Contains(string isbn)
        {
                return _ctx.Set<Libro>().Where(c => c.isbn.Replace(" ", "") == isbn.Replace(" ", "").Replace("-", "")).ToList().Count>0;
        }
        public bool ContainsId(string id)
        {
            return _ctx.Set<Libro>().Where(c => c.id.Replace(" ", "") == id.Replace(" ", "")).ToList().Count > 0;
        }
        public List<Libro> GetLibriByCategoria(string categoria)
        {
            return _ctx.Set<Libro>().Include(x=> x.autori).Include(x=>x.categorie).Where(x => x.categorie.Any(y => y.nome.ToLower().Trim().Contains(categoria.ToLower().Trim()))).ToList();
        }

        public List<Libro> GetLibriByAutore(string autore)
        {
            return _ctx.Set<Libro>().Include(x => x.autori).Include(x => x.categorie).Where(x => x.autori.Any(y => y.nome.Replace(" ", "").ToLower().Contains(autore.Replace(" ", "").ToLower()))).ToList();
        }

        public List<Libro> GetLibriByTitolo(string titolo)
        {
            return _ctx.Set<Libro>().Include(x=>x.autori).Where(x => x.titolo.ToLower().Replace(" ", "").Contains(titolo.ToLower().Replace(" ", ""))).ToList();
        }

        public Libro GetLibroByIsbn(string isbn)
        {
            return _ctx.Libro.Include(x=>x.categorie).Where(x => x.isbn == isbn.Replace(" ", "").Replace("-", "")).FirstOrDefault();
        }
    }
    
}

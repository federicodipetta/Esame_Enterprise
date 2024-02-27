using Libri_application.Models.Context;
using Libri_application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public bool Contains(string nome)
        {
            return _ctx.Set<Categoria>().Where(c => c.nome == nome).Count()>=1;
        }

    }
}

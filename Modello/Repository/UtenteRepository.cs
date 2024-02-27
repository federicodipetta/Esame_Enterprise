using Libri_application.Models.Context;
using Libri_application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Repository
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public Utente GetByLogin(string login)
        {
            return _ctx.Utente.FirstOrDefault(u => u.login == login);
        }

        public Utente Get(string id)
        {
            return this.Get(int.Parse(id));
        }


    }
}

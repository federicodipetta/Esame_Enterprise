using Libri_application.App.Abstractions.Services;
using Libri_application.Models.Entities;
using Libri_application.Models.Repository;

namespace Libri_application.App.Services
{
    public class UtenteService : IUtenteService
    {

        private readonly UtenteRepository _repoU;
        public UtenteService(UtenteRepository repoU)
        {
            _repoU = repoU;
        }
        public Utente GetUtente(string id)
        {
            return _repoU.Get(id);
        }
    }
}

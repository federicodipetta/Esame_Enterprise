using Libri_application.Models.Entities;

namespace Libri_application.App.Abstractions.Services
{
    public interface IUtenteService
    {
        Utente GetUtente(string id);
    }
}

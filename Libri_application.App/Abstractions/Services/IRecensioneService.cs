using Libri_application.Models.Entities;

namespace Libri_application.App.Abstractions.Services
{
    public interface IRecensioneService
    {
        List<Recensione> GetRecensioni(int idUtente);
        Recensione GetRecensioneByLibro(int idUtente,string idLibro);
        Task<bool> AggiungiRecensione(string isbn,Recensione recensione);
        bool EliminaRecensione(Recensione recensione);
        bool ModificaRecensione(Recensione recensione);

    }
}

using Libri_application.App.Abstractions.Services;
using Libri_application.LibriService;
using Libri_application.Models.Entities;
using Libri_application.Models.Repository;

namespace Libri_application.App.Services
{
    public class RecensioneService : IRecensioneService
    {
        private readonly RecensioneRepository _repoR;
        private readonly LibroRepository _repoL;
        private readonly UtenteRepository _repoU;
        private readonly ILibroService _libroService;
        public RecensioneService(RecensioneRepository repoR, LibroRepository repoL, UtenteRepository repoU
           ,ILibroService libroService)
        {
            _repoL = repoL;
            _repoR = repoR;
            _repoU = repoU;
            _libroService = libroService;
        }

        public async Task<bool>  AggiungiRecensione(string isbn, Recensione recensione)
        {
            if(_repoL.GetLibroByIsbn(isbn) == null)
            {
                await _libroService.AggiungiLibro(isbn);
                
            }
            var libro = _repoL.GetLibroByIsbn(isbn);
            recensione.idLibro = libro.id;
            recensione.libro = libro;
            _repoR.Add(recensione);
            _repoL.Save();
            return true;
        }

        public bool EliminaRecensione(Recensione recensione)
        {
            _repoR.Delete(recensione);
            _repoR.Save();
            return true;
        }

        public Recensione GetRecensioneByLibro(int idUtente, string idLibro)
        {
            return _repoR.GetRecensioneByUtenteByLibro(idUtente,idLibro);
        }

        public List<Recensione> GetRecensioni(int idUtente)
        {
            return _repoR.GetRecensioneByUtente(idUtente);
        }

        public bool ModificaRecensione(Recensione recensione)
        {
            var x = _repoR.GetRecensioneByUtenteByLibro(recensione.idUtente, recensione.idLibro);
            if (x == null) return false;
            x.recensione = recensione.recensione;
            x.voto = recensione.voto;
            x.periodo = recensione.periodo;
            x.stato = recensione.stato;
            _repoR.Update(x);

            _repoR.Save();
            return true;
        }
    }
}

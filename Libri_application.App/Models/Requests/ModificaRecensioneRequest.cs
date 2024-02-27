using Libri_application.Models.Entities;

namespace Libri_application.App.Models.Requests
{
    public class ModificaRecensioneRequest
    {
        public string idLibro { get; set; }
        public string recensione { get; set; }
        public int voto { get; set; }

        public StatoRecensione stato { get; set; }

        public string periodo { get; set; }

        public Recensione ToRecensione(int idUtente)
        {
            Recensione recensione = new Recensione();
            recensione.idUtente= idUtente;
            recensione.idLibro = idLibro;
            recensione.voto = voto;
            recensione.stato = stato;
            recensione.periodo = periodo;
            recensione.recensione = this.recensione;
            return recensione;
        }
    }
}

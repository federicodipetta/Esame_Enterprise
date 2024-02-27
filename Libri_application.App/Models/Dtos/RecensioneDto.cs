using Libri_application.Models.Entities;

namespace Libri_application.App.Models.Dtos
{
    public class RecensioneDto
    {
        public int voto { get; set; } = 0;
        public string recensione { get; set; } = string.Empty;
        public string periodo { get; set; }
        public StatoRecensione stato { get; set; }
        
        public RecensioneDto(Recensione recensione)
        {
            voto = recensione.voto;
            this.recensione = recensione.recensione;
            periodo = recensione.periodo;
            stato = recensione.stato;
        }
    }
}

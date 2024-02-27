using Libri_application.App.Models.Dtos;

namespace Libri_application.App.Models.Responses
{
    public class RecensioneCompletaResonse
    {
        public RecensioneDto recensione { get; set; }
        public UtenteOutDto utente { get; set; }
        public LibroDto libro { get; set; }
    }
}

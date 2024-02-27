using Libri_application.LibriService.models;
using Libri_application.Models.Entities;

namespace Libri_application.App.Models.Dtos
{
    public class RecensioneRidottaDto
    {

        public string idLibro { get; set; }
        public int idUtente { get; set; }
        public LibroRidottoDto libro { get; set; }
        public int voto { get; set; }

        public RecensioneRidottaDto()
        {

        }

        public RecensioneRidottaDto(Recensione recensione)
        {
            idLibro = recensione.idLibro;
            idUtente = recensione.idUtente;
            libro = new LibroRidottoDto(recensione.libro);
            voto = recensione.voto;
        }

    }
}

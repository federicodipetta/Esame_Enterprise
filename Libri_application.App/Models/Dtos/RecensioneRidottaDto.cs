using Libri_application.LibriService.models;
using Libri_application.Models.Entities;

namespace Libri_application.App.Models.Dtos
{
    public class RecensioneRidottaDto
    {

        public LibroRidottoDto libro { get; set; }
        public int voto { get; set; }

        public RecensioneRidottaDto()
        {

        }

        public RecensioneRidottaDto(Recensione recensione)
        {
            libro = new LibroRidottoDto(recensione.libro);
            voto = recensione.voto;
        }

    }
}

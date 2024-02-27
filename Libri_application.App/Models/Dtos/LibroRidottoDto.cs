using Libri_application.Models.Entities;

namespace Libri_application.App.Models.Dtos
{
    public class LibroRidottoDto
    {
        public string id { get; set; }
        public string titolo { get; set; }

        public string[] autori { get; set; }

        public string urlImg { get; set; }

        public LibroRidottoDto()
        {

        }
        public LibroRidottoDto(Libro libro)
        {
            id = libro.id;
            titolo = libro.titolo;
            autori = libro.autori.Split(',');
            urlImg = libro.img;
        }

    }
}

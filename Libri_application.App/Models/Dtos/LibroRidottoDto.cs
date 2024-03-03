using Libri_application.LibriService.models;
using Libri_application.Models.Entities;

namespace Libri_application.App.Models.Dtos
{
    public class LibroRidottoDto
    {
        public string id { get; set; }
        public string titolo { get; set; }

        public string[] autori { get; set; }

        public string urlImg { get; set; }
        public string isbn { get; set; }

        public LibroRidottoDto()
        {

        }
        public LibroRidottoDto(Libro libro)
        {
            id = libro.id;
            titolo = libro.titolo;
            autori = libro.autori.Select(x=>x.nome).ToArray();
            urlImg = libro.img;
            isbn = libro.isbn;
        }
        public LibroRidottoDto(LibroRidotto libro)
        {
            id = libro.id;
            titolo = libro.titolo;
            autori = libro.autori.Select(x=>x.nome).ToArray();
            urlImg = libro.urlImmagine;
            isbn = libro.isbn;
            
        }
    }
}

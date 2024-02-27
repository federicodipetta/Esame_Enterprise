using Libri_application.Models.Entities;

namespace Libri_application.App.Models.Dtos
{
    public class LibroDto
    {
        public string id { get; set; }
        public string titolo { get; set; }
        public string[] autori { get; set; }
        public string urlImg { get; set; }

        public string isbn { get; set; }
        public string descrizione { get; set; }
        public string editore { get; set; }
        public string anno { get; set; }
        public string[] categorie { get; set; }
        public LibroDto(Libro libro)
        {
            id = libro.id;
            titolo = libro.titolo;
            autori = libro.autori.Split(",");
            urlImg = libro.img;
            isbn = libro.isbn;
            descrizione = libro.descrizione;
            editore = libro.editore;
            anno = libro.anno;
            categorie = libro.categorie.Select(c => c.nome).ToArray();

        }
    }
}

using Libri_application.LibriService.models;
using Libri_application.Models.Entities;

namespace Libri_application.App.Abstractions.Services
{
    public interface ILibroService
    {
        Task<bool> AggiungiLibro(string isbn);
        Libro GetLibro(string id);
        Libro GetLibroByIsbn(string isbn);
        List<Libro> GetLibri();
        List<Libro> GetLibriByAutore(string autore);
        List<Libro> GetLibriByCategoria(string categoria);
        List<LibroRidotto> GetLibriByTitolo(string titolo);

    }
}

using Libri_application.LibriService.models;
using Libri_application.Models.Entities;

namespace Libri_application.App.Abstractions.Services
{
    public interface ILibroService
    {
        Task<bool> AggiungiLibro(string isbn);
        Task<Libro> GetLibro(string id);
        Task<Libro> GetLibroByIsbn(string isbn);
        List<Libro> GetLibriByAutore(string autore);
        List<Libro> GetLibriByCategoria(string categoria);
        Task<List<LibroRidotto>> GetLibriByTitolo(string titolo);

    }
}

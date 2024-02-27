using Libri_application.LibriService.models;
using Libri_application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.LibriService.abstraction
{
    internal interface ILibriService
    {
        Task<Libro> GetLibro(string isbn);
        Task<Libro> GetLibroById(string id);
        Task<List<LibroRidotto>> GetLibri(string nome);
    }
}

using Libri_application.App.Abstractions.Services;
using Libri_application.App.Models.Dtos;
using Libri_application.LibriService.models;
using Libri_application.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libri_application.App.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        [Route("GetLibroIsbn/{isbn}")]
        public LibroRidottoDto GetLibri(string isbn)
        {
            return new LibroRidottoDto(_libroService.GetLibroByIsbn(isbn));
        }

        [HttpGet]
        [Route("GetLibro/{id}")]
        public LibroDto GetLibro(string id)
        {
            return new LibroDto(_libroService.GetLibro(id));
        }

        [HttpGet]
        [Route("GetLibri/{titolo}")]
        public List<LibroRidotto> GetLibriByTitoloOnline(string titolo)
        {
            return new List<LibroRidotto> (_libroService.GetLibriByTitolo(titolo));
        }

        [HttpGet]
        [Route("GetLibri/{categoria}")]
        public List<Libro> GetLibriByCategoria(string categoria)
        {
            return _libroService.GetLibriByCategoria(categoria);
        }

        [HttpGet]
        [Route("GetLibri/{autore}")]
        public List<Libro> GetLibriByAutore(string autore)
        {
            return _libroService.GetLibriByAutore(autore);
        }

        [HttpPost]
        [Route("AddLibro")]
        public async Task<IActionResult> AddLibro(string isbn)
        {
            bool a = await _libroService.AggiungiLibro(isbn);
            return a ? Ok(): BadRequest();
        }
    }
}

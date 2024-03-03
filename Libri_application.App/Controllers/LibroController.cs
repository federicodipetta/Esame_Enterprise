using Libri_application.App.Abstractions.Services;
using Libri_application.App.Factorys;
using Libri_application.App.Models.Dtos;
using Libri_application.LibriService.models;
using Libri_application.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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
        public async Task<LibroRidottoDto> GetLibri(string isbn)
        {
            return new LibroRidottoDto(await _libroService.GetLibroByIsbn(isbn));
        }

        [HttpGet]
        [Route("GetLibro/{id}")]
        public async Task<LibroDto> GetLibro(string id)
        {
            return new LibroDto(await _libroService.GetLibro(id));
        }

        [HttpGet]
        [Route("GetLibriTitolo/{titolo}")]
        public async Task<List<LibroRidottoDto>> GetLibriByTitoloOnline([FromRoute]string titolo)
        {
            titolo = HttpUtility.UrlDecode(titolo);
            var libri = await _libroService.GetLibriByTitolo(titolo);
            return libri.Select(x => new LibroRidottoDto(x)).ToList();
        }

        [HttpGet]
        [Route("GetLibriCategoria/{categoria}")]
        public List<LibroDto> GetLibriByCategoria(string categoria)
        {

            categoria = HttpUtility.UrlDecode(categoria);
            return _libroService.GetLibriByCategoria(categoria).Select(x=> new LibroDto(x)).ToList();
        }

        [HttpGet]
        [Route("GetLibriAutore/{autore}")]
        public List<LibroDto> GetLibriByAutore(string autore)
        {
            return _libroService.GetLibriByAutore(autore).Select(x => new LibroDto(x)).ToList();
        }

        [HttpPost]
        [Route("AddLibro")]
        public async Task<IActionResult> AddLibro(string isbn)
        {
            try
            {
                bool a = await _libroService.AggiungiLibro(isbn);
                return a ? Ok(ResponseFactory.WithSuccess("libro aggiunto"))
                :
                BadRequest(ResponseFactory.WithError("libro presente o isbn errato"));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseFactory.WithError(e));
            }
            
        }
    }
}

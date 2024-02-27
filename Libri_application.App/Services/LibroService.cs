using global::Libri_application.App.Abstractions.Services;
using global::Libri_application.Models.Context;
using global::Libri_application.Models.Entities;
using Libri_application.LibriService.models;
using Libri_application.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Libri_application.App.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibroRepository _repo;
        private readonly CategoriaRepository _repoC;
        public LibroService(LibroRepository repo, CategoriaRepository repoC)
        {
            _repo = repo;
            _repoC = repoC;
        }
        public async Task<bool> AggiungiLibro(string isbn)
        {

            if (_repo.Contains(isbn))
            {
                // Il libro è già presente nel database
                return false;
            }
            else
            {
                // Il libro non è presente nel database
                var libriService = new LibriService.LibriService();
                Libro libro = await libriService.GetLibro(isbn);
                var categorie = libro.categorie
                    .Where(x => _repoC.Contains(x.nome))
                    .Select(x => _repoC.Get(x.nome)).ToList();
                libro.categorie=categorie
                    .Concat(
                    libro.categorie.Where(x => !_repoC.Contains(x.nome))
                    ).Distinct().ToList();
                    
                

                _repo.Add(libro);
                _repo.Save();
                return true;
            }
        }

        public bool EliminaLibro(Libro libro)
        {
           return EliminaLibro(libro.id);
        }

        public bool EliminaLibro(string id)
        {
            if(_repo.Get(id)==null)
            {
                _repo.Delete(_repo.Get(id));
                _repo.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Libro> GetLibri()
        {
            return _repo.GetAll().ToList();
        }

        public List<Libro> GetLibriByGenere(string genere)
        {
            
            throw new NotImplementedException();
        }

        public List<LibroRidotto> GetLibriByTitolo(string titolo)
        {
            List<Libro> libri = _repo.GetLibriByTitolo(titolo);
            if(libri.Count == 0)
            {
                // Il libro non è presente nel database
                var service = new LibriService.LibriService();
                return service.GetLibri(titolo).Result;
            }
            else
            {
                // Il libro è presente nel database
                return  LibroToRidotto(_repo.GetLibriByTitolo(titolo));
            }
        }
        private List<LibroRidotto> LibroToRidotto(List<Libro> libro)
        {
            List<LibroRidotto> libriRidotti = new List<LibroRidotto>();
            foreach (var l in libro)
            {
                LibroRidotto ridotto = new LibroRidotto();
                ridotto.id = l.id;
                ridotto.autore = l.autori;
                ridotto.titolo = l.titolo;
                ridotto.urlImmagine = l.img;
                libriRidotti.Add(ridotto);
            }
            return libriRidotti;
        }

        public Libro GetLibro(string id)
        {
            if (_repo.Get(id) == null)
            {
                var service = new LibriService.LibriService();
                var libro = service.GetLibro(id).Result;
                return libro;
            }
            else
            {
                return _repo.Get(id);
            }
        }

        public Libro GetLibroByIsbn(string isbn)
        {
            if (_repo.GetLibroByIsbn(isbn) == null)
            {
                var service = new LibriService.LibriService();
                var libro = service.GetLibro(isbn).Result;
                return libro;
            }
            else
            {
                return _repo.GetLibroByIsbn(isbn);
            }
        }
    }
}

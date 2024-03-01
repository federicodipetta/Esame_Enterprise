﻿using global::Libri_application.App.Abstractions.Services;

using global::Libri_application.Models.Entities;
using Libri_application.LibriService.models;
using Libri_application.Models.Repository;

namespace Libri_application.App.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibroRepository _repo;
        private readonly CategoriaRepository _repoC;
        private readonly AutoreRepository _repoA;
        public LibroService(LibroRepository repo, CategoriaRepository repoC, AutoreRepository repoA)
        {
            _repo = repo;
            _repoC = repoC;
            _repoA = repoA;
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
                var categorieEsistenti = libro.categorie
                    .Where(x => _repoC.Contains(x.nome))
                    .Select(x => _repoC.Get(x.nome)).ToList();

                libro.categorie = categorieEsistenti
                    .Concat(
                    libro.categorie.Where(x => !categorieEsistenti.Select(y => y.nome.Trim()).Any(z => z == x.nome))
                    ).ToList();

                var autori = libro.autori
                .Where(x => _repoA.Contains(x.nome))
                .Select(x => _repoA.Get(x.nome)).ToList();
                libro.autori = autori
                    .Concat(
                    libro.autori.Where(x => !autori.Select(y => y.nome.Trim()).Any(z => z == x.nome))
                    ).ToList();

                _repo.Add(libro);
                _repo.Save();
                return true;
            }
        }
        


        public List<Libro> GetLibri()
        {
            return _repo.GetAll().ToList();
        }

        public List<Libro> GetLibriByCategoria(string categoria)
        {
            return  _repo.GetLibriByCategoria(categoria);
        }
        public List<Libro> GetLibriByAutore(string autore)
        {
            return _repo.GetLibriByAutore(autore);
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
                ridotto.autori = l.autori;
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

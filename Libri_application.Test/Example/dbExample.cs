using Libri_application.Models.Context;
using Libri_application.Models.Entities;
using Libri_application.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Test.Example
{
    internal class dbExample
    {
        public void Run()
        {
            var ctx = new MyDbContext();
            Libro libro = new Libro();
            libro.id = "9";
            var f = new Autore() { nome = "autore1" };
            var g = new Autore() { nome = "autore2" };
         
            libro.autori = new List<Autore> {f, g};
            libro.titolo = "titolo";
            libro.editore = "editore";
            libro.anno = "2024";
            libro.descrizione = "descrizione";
            libro.isbn = "isbn";
            libro.img = "img";
            CategoriaRepository categoriaRepository = new CategoriaRepository(ctx);
            //sono già presenti nel db
            var c = new Categoria() { nome = "banana"};
            libro.categorie = new List<Categoria> {c};
            LibroRepository libroRepository = new LibroRepository(ctx);
            libroRepository.Add(libro);
            libroRepository.Save();

        }
    }
}

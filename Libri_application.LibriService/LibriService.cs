using Libri_application.LibriService.abstraction;
using Libri_application.LibriService.models;
using Libri_application.LibriService.models.LibroDettagliato;
using Libri_application.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Libri_application.LibriService
{
    public class LibriService : ILibriService
    {
        string urlISBN = "https://www.googleapis.com/books/v1/volumes?q=isbn:";
        string urlId = "https://www.googleapis.com/books/v1/volumes/";
        string urlTitolo = "https://www.googleapis.com/books/v1/volumes?q=";
        string maxResult = "&maxResults=";
        public LibriService()
        {
        }
        public async Task<Libro> GetLibro(string isbn)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(urlISBN + isbn);
            HttpContent content = response.Content;       
            string data = await content.ReadAsStringAsync();
            var libro = JsonSerializer.Deserialize<models.LibroService>(data);
            if(libro==null || libro.items==null || libro.items[0]==null || libro.items[0].id==null) throw new Exception("Libro non presente");
            HttpResponseMessage httpResponseMessage = await client.GetAsync(urlId + libro.items[0].id);
            HttpContent httpContent = httpResponseMessage.Content;
            string data2 = await httpContent.ReadAsStringAsync();
            var libro2 = JsonSerializer.Deserialize<LibroDettagliato>(data2);
            return CreaLibro(libro2);
        }

        public async Task<Libro> GetLibroById(string id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.GetAsync(urlId + id);
            HttpContent httpContent = httpResponseMessage.Content;
            string data = await httpContent.ReadAsStringAsync();
            var libro = JsonSerializer.Deserialize<LibroDettagliato>(data);
            return CreaLibro(libro);
        }
        private Libro CreaLibro(LibroDettagliato libro)
        {
            if(libro==null || libro.volumeInfo==null) throw new Exception("Libro non presente");
            var l = new Libro();
            l.id = libro.id;
            l.autori = libro.volumeInfo.authors.ToList().Select(x =>
            {
                var c = new Autore();
                c.nome = x;
                return c;
            }).ToList();
            l.titolo = libro.volumeInfo.title;
            l.editore = libro.volumeInfo.publisher;
            l.anno = libro.volumeInfo.publishedDate == null ? "" : libro.volumeInfo.publishedDate.Substring(0, 4);
            l.descrizione = libro.volumeInfo.description == null ? "" : libro.volumeInfo.description;
            l.img = libro.volumeInfo.imageLinks == null ? "" : libro.volumeInfo.imageLinks.smallThumbnail;
            l.isbn = libro.volumeInfo.industryIdentifiers == null ? "" 
                : libro.volumeInfo.industryIdentifiers.FirstOrDefault(x=>x.type=="ISBN_13")?.identifier??"";
            l.categorie = libro.volumeInfo.categories == null ? new List<Categoria>() : libro.volumeInfo.categories.
                ToList().Select(x =>
                {
                    var c = new Categoria();
                    c.nome = x;
                    return c;
                }).ToList();
            return l;
        }

        public async Task<List<LibroRidotto>> GetLibri(string titolo)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(urlTitolo+titolo+maxResult+"5");
            HttpContent content = response.Content;
            string data = await content.ReadAsStringAsync();
            var libri = JsonSerializer.Deserialize<models.LibroService>(data);
            List<LibroRidotto> libriRidotti = new List<LibroRidotto>();
            if (libri.items == null)
            {
                return libriRidotti;
            }
            foreach (var libro in libri.items)
            {
                var l = new LibroRidotto();
                l.id = libro.id;
                l.autori = libro.volumeInfo.authors.ToList().Select(x =>
                {
                    var c = new Autore();
                    c.nome = x;
                    return c;
                }).ToList();
                l.titolo = libro.volumeInfo.title ?? "";
                l.urlImmagine = libro.volumeInfo.imageLinks == null ? "" :
                    libro.volumeInfo.imageLinks.smallThumbnail;
                l.isbn = libro.volumeInfo.industryIdentifiers == null ? 
                    "" :
                    libro.volumeInfo.industryIdentifiers.FirstOrDefault(x => x.type == "ISBN_13")?.identifier 
                    ?? "";
                libriRidotti.Add(l);
            }
            return libriRidotti;
        }
    }
}

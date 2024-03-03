using Libri_application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.LibriService.models
{
    public class LibroRidotto
    {
        public string id { get; set; }
        public ICollection<Autore> autori { get; set; }
        public string titolo { get; set; }
        public string urlImmagine { get; set; }
        public string isbn { get; set; }
    }
}

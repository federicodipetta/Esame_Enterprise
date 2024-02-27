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
        public string autore { get; set; }
        public string titolo { get; set; }
        public string urlImmagine { get; set; }
    }
}

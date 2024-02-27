using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Entities
{
    public class Recensione
    {
        public string idLibro { get; set; }
        public int idUtente { get; set; }
        public Libro libro { get; set; }
        public Utente utente { get; set; }
        public string recensione { get; set; }

        public int voto { get; set; }

        public string periodo { get; set; }

        public StatoRecensione stato { get; set; }

        

    }
}

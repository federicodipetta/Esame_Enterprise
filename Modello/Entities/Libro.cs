using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Entities
{
    public class Libro
    {
        
        public string id { get; set; }
        public string autori { get; set; }
        public string titolo { get; set; }
        public string editore { get; set; }
        public string anno { get; set; }
        public string descrizione { get; set; }
        public string isbn { get; set; }
        public string img { get; set; }

        public virtual ICollection<Categoria> categorie{ get; set; }
    }
}

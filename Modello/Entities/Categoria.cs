using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Entities
{
    public class Categoria
    {
        public string nome { get; set; }
        public virtual List<Libro> libri { get; set; }
         
    }
}

using Libri_application.LibriService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Test.Example
{
    internal class ServiceExample
    {
        public void Run()
        {
            var service = new LibriService.LibriService();
            var libro = service.GetLibro("9788804668237").Result;
            Console.WriteLine(libro.titolo);
            Console.WriteLine(service.GetLibroById(libro.id).Result);
            Console.WriteLine(service.GetLibri("Harry Potter").Result.Count);
        }
    }
}

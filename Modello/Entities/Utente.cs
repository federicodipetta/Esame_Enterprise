
namespace Libri_application.Models.Entities
{
    public class Utente
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string salt { get; set; }

    }
}

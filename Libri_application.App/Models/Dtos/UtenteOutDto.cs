using Libri_application.Models.Entities;

namespace Libri_application.App.Models.Dtos
{
    public class UtenteOutDto
    {
        public string email { get; set; }
        public string login { get; set; }

        public UtenteOutDto(Utente u)
        {
            email = u.email;
            login = u.login;
        }
    }
}

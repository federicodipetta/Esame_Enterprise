using Libri_application.App.Abstractions.Services;
using Libri_application.App.Models.Exception;
using Libri_application.App.Options;
using Libri_application.Models.Entities;
using Libri_application.Models.Repository;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Libri_application.App.Services
{

    public class AutenticazioneService : IAutenticazioneService
    {
        private readonly UtenteRepository _repoU ;
        private readonly JwtOption _jwt ;

        public AutenticazioneService(UtenteRepository repository, IOptions<JwtOption> option)
        {
            _repoU = repository;
            _jwt = option.Value;

        }
        public string Login(string username, string password)
        {
            var utente = _repoU.GetByLogin(username);
            if(utente == null)
            {
                throw new MyException("utente non trovato");
            }
            if (CheckPassword(password,utente.salt,utente.password))
            {
                return GenerateToken(utente);
            }else throw new MyException("utente corretto ma password errata");
           
        }
        public string Register(string username, string password, string mail)
        {
            var hash = new HMACSHA256();
            var salt = hash.Key;
            var passwordHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            var utente = new Utente();
            utente.login = username;
            utente.password = Convert.ToBase64String(passwordHash); // Convert to Base64 string
            utente.email = mail;
            utente.salt = Convert.ToBase64String(salt); // Convert to Base64 string
            _repoU.Add(utente);
            _repoU.Save();
            return GenerateToken(_repoU.GetByLogin(username));
        }
    



        private bool CheckPassword(string password, string salt, string pass)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var passwordHash = new HMACSHA256(saltBytes).ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(passwordHash) == pass; // Compare Base64 strings
        }


        private string GenerateToken(Utente utente)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, utente.login),
                new Claim(ClaimTypes.Email, utente.email),
                new Claim("Id", utente.id.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securtyyoken = new JwtSecurityToken(
                _jwt.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials :creds
                );
            return new JwtSecurityTokenHandler().WriteToken(securtyyoken);
        }

    }


}

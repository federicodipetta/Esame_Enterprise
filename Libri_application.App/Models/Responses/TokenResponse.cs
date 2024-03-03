namespace Libri_application.App.Models.Responses
{
    public class TokenResponse
    {
        public string token { get; set; }

        public TokenResponse(string token)
        {
            this.token = token;
        }
    }
}

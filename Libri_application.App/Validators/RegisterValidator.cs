using FluentValidation;
using Libri_application.App.Models.Requests;

namespace Libri_application.App.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.email).NotEmpty().EmailAddress();
            RuleFor(x => x.password).NotEmpty()
                .MinimumLength(8)
                .Custom(CheckPassword);
            RuleFor(x => x.username).NotEmpty().MinimumLength(4);
        }

        public void CheckPassword(string pass, ValidationContext<RegisterRequest> context)
        {
            if(pass == context.InstanceToValidate.username)
            {
                context.AddFailure("La password non può essere uguale all'username");
            }   
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecial = false;
            foreach (char c in pass)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                if (char.IsLower(c)) hasLowerCase = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (char.IsPunctuation(c) || char.IsSymbol(c)) hasSpecial = true;
            }
            if (!hasUpperCase || !hasLowerCase || !hasDigit || !hasSpecial)
            {
                context.AddFailure("La password deve contenere almeno una lettera maiuscola, una minuscola, un numero e un carattere speciale");
            }
        }   
    }
}

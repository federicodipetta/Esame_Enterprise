using FluentValidation;
using Libri_application.App.Models.Requests;

namespace Libri_application.App.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.login).
                NotNull().
                WithMessage("Il campo non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo login non può essere vuoto");
                
            RuleFor(x => x.password).
                NotNull().
                WithMessage("Il campo non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo password non può essere vuoto");
        }
    }
}

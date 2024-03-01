using FluentValidation;
using Libri_application.App.Models.Requests;

namespace Libri_application.App.Validators
{
    public class RecensioneRequestValidator : AbstractValidator<RecensioneRequest>
    {
        public RecensioneRequestValidator()
        {
            RuleFor(x => x.isbn)
                .NotEmpty()
                .WithMessage("isbn è richiesto");
            RuleFor(x => x.Testo)
                .NotEmpty()
                .WithMessage("Testo è richiesto");
            RuleFor(x => x.Voto)
                .NotEmpty()
                .WithMessage("Voto è richiesto");
            RuleFor(x => x.Stato)
                .NotNull()
                .WithMessage("Stato è richiesto");
            RuleFor(x => x.periodo)
                .NotEmpty()
                .WithMessage("periodo è richiesto");
           
        }
    }
}

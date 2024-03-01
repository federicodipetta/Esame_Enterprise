using FluentValidation;
using Libri_application.App.Models.Requests;

namespace Libri_application.App.Validators
{
    public class RecensioneDeleteValidator : AbstractValidator<RecensioneDelete>
    {
        public RecensioneDeleteValidator()
        {
            RuleFor(x => x.idLibro)
                .NotNull()
                .WithMessage("Il campo non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo login non può essere vuoto");
        }
    }
}

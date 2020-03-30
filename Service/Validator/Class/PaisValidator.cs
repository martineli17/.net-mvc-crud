using Domain.DTO;
using FluentValidation;

namespace Service.Validator.Class
{
    public class PaisValidator : AbstractValidator<PaisDTO>
    {
        public PaisValidator()
        {
            RuleFor(p => p.Descricao).NotNull().WithMessage(MensagensValidator.DescricaoInvalida).NotEmpty().WithMessage(MensagensValidator.DescricaoInvalida);
        }
    }
}

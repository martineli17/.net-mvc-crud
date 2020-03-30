using Domain.DTO;
using FluentValidation;

namespace Service.Validator.Class
{
    public class CidadeValidator : AbstractValidator<CidadeDTO>
    {
        public CidadeValidator()
        {
            RuleFor(c => c.Descricao).NotEmpty().WithMessage(MensagensValidator.DescricaoInvalida).NotNull().WithMessage(MensagensValidator.DescricaoInvalida);
            RuleFor(c => c.IdEstado).NotEmpty().WithMessage("Identificador do Estado é necessário.").NotNull().WithMessage("Identificador do Estado é necessário.");
        }
    }
}

using Domain.DTO;
using FluentValidation;

namespace Service.Validator.Class
{
    public class EstadoValidator : AbstractValidator<EstadoDTO>
    {
        public EstadoValidator()
        {
            RuleFor(e => e.Descricao).NotEmpty().WithMessage(MensagensValidator.DescricaoInvalida).NotNull().WithMessage(MensagensValidator.DescricaoInvalida);
            RuleFor(e => e.IdPais).NotEmpty().WithMessage("Identificador do País é necessário.").NotNull().WithMessage("Identificador do País é necessário.");
        }
    }
}

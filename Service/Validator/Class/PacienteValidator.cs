using Domain.DTO;
using FluentValidation;
using Service.Validator.Functions;

namespace Service.Validator.Class
{
    public class PacienteValidator : AbstractValidator<PacienteDTO>
    {
        public PacienteValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().WithMessage(MensagensValidator.NomeInvalido).NotNull().WithMessage(MensagensValidator.NomeInvalido);
            RuleFor(p => p.Cpf).NotEmpty().WithMessage(MensagensValidator.CpfNaoInformado).NotNull().WithMessage(MensagensValidator.CpfNaoInformado).Must(ValidatorFunctions.CpfValidation).WithMessage(MensagensValidator.CpfInvalido);
            RuleFor(p => p.IdCidade).NotEmpty().WithMessage("Identificador da Cidade precisa ser informado.").NotNull().WithMessage("Identificador da Cidade precisa ser informado.");
            RuleFor(p => p.IdEstado).NotEmpty().WithMessage("Identificador da Estado precisa ser informado.").NotNull().WithMessage("Identificador da Estado precisa ser informado.");
            RuleFor(p => p.IdPais).NotEmpty().WithMessage("Identificador do País precisa ser informado.").NotNull().WithMessage("Identificador da País precisa ser informado.");
        }
    }
}

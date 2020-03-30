using FluentValidation;

namespace Service.Validator.Interface
{
    public interface IExecuteValidation
    {
        bool ExecuteValidatorClass<Validator, Entidade>(Validator validator, Entidade entidade) where Validator : AbstractValidator<Entidade> where Entidade : class;
    }
}

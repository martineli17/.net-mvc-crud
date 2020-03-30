using Crosscuting.Notification;
using FluentValidation;
using Service.Validator.Interface;

namespace Service.Validator.Base
{
    public class ExecuteValidator : IExecuteValidation
    {
        private readonly INotify _notify;
        public ExecuteValidator(INotify notify)
        {
            _notify = notify;
        }
        public bool ExecuteValidatorClass<Validator, Entidade>(Validator validator, Entidade entidade) where Validator : AbstractValidator<Entidade> where Entidade : class
        {
            var resultValidator = validator.Validate(entidade);
            if (!resultValidator.IsValid) _notify.AddNotification(resultValidator);
            return resultValidator.IsValid;
        }
    }
}

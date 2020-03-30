using AutoMapper;
using Crosscuting.Notification;
using Domain.Interfaces.UnitOfWork;
using Service.Validator.Interface;
using System;

namespace Service.Crud
{
    public  abstract class ServiceBase
    {
        protected readonly IMapper _mapper;
        protected readonly IExecuteValidation _executeValidation;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly INotify _notify;

        public ServiceBase(IServiceProvider service)
        {
            _mapper = (IMapper) service.GetService(typeof(IMapper));
            _unitOfWork = (IUnitOfWork)service.GetService(typeof(IUnitOfWork));
            _executeValidation = (IExecuteValidation)service.GetService(typeof(IExecuteValidation));
            _notify = (INotify)service.GetService(typeof(INotify));
        }
    }
}

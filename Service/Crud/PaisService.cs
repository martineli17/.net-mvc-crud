using Crosscuting.Notification;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Service.Validator.Class;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Crud
{
    public class PaisService : ServiceBase, IPaisService
    {
        private readonly IPaisRepository _paisRepository;
        public PaisService(IServiceProvider service, IPaisRepository paisRepository) : base(service)
        {
            _paisRepository = paisRepository;
        }

        public async Task<bool> AddAsync(PaisDTO entityDTO)
        {
            if (!_executeValidation.ExecuteValidatorClass(new PaisValidator(), entityDTO)) return false;
            if (await _paisRepository.Exists(entityDTO.Descricao))
            {
                _notify.AddNotification(new NotificationMessage("País informado já está registrado."));
                return false;
            }
            await _paisRepository.AddAsync(_mapper.Map<Pais>(entityDTO));
            return await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<PaisDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PaisDTO>>(await _paisRepository.GetAllAsync());
        }

        public async Task<PaisDTO> GetIdAsync(Guid id)
        {
            return _mapper.Map<PaisDTO>(await _paisRepository.GetIdAsync(id));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await _paisRepository.RemoveAsync(id);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> UpdateAsync(PaisDTO entityDTO)
        {
            if (!_executeValidation.ExecuteValidatorClass(new PaisValidator(), entityDTO)) return false;
            if (await _paisRepository.Exists(entityDTO.Descricao))
            {
                _notify.AddNotification(new NotificationMessage("País informado já está registrado."));
                return false;
            }
            await _paisRepository.UpdateAsync(_mapper.Map<Pais>(entityDTO));
            return await _unitOfWork.Commit();
        }
    }
}

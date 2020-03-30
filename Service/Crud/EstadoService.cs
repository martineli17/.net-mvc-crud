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
    public class EstadoService : ServiceBase, IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        public EstadoService(IServiceProvider service, IEstadoRepository estadoRepository) : base(service)
        {
            _estadoRepository = estadoRepository;
        }

        public async Task<bool> AddAsync(EstadoDTO entityDTO)
        {
            if (!_executeValidation.ExecuteValidatorClass(new EstadoValidator(), entityDTO)) return false;
            if (await _estadoRepository.Exists(entityDTO.Descricao, entityDTO.IdPais))
            {
                _notify.AddNotification(new NotificationMessage("Estado informado já está registrado."));
                return false;
            }
            await _estadoRepository.AddAsync(_mapper.Map<Estado>(entityDTO));
            return await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<EstadoDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EstadoDTO>>(await _estadoRepository.GetAllAsync());
        }

        public async Task<EstadoDTO> GetIdAsync(Guid id)
        {
            return _mapper.Map<EstadoDTO>(await _estadoRepository.GetIdAsync(id));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await _estadoRepository.RemoveAsync(id);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> UpdateAsync(EstadoDTO entityDTO)
        {
            if (!_executeValidation.ExecuteValidatorClass(new EstadoValidator(), entityDTO)) return false;
            if (await _estadoRepository.Exists(entityDTO.Descricao, entityDTO.IdPais))
            {
                _notify.AddNotification(new NotificationMessage("Estado informado já está registrado."));
                return false;
            }
            await _estadoRepository.UpdateAsync(_mapper.Map<Estado>(entityDTO));
            return await _unitOfWork.Commit();
        }
    }
}

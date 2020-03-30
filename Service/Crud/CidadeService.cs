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
    public class CidadeService : ServiceBase, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        public CidadeService(IServiceProvider service, ICidadeRepository cidadeRepository) : base(service)
        {
            _cidadeRepository = cidadeRepository;
        }

        public async Task<bool> AddAsync(CidadeDTO entityDTO)
        {
            if (!_executeValidation.ExecuteValidatorClass(new CidadeValidator(), entityDTO)) return false;
            if (await _cidadeRepository.Exists(entityDTO.Descricao, entityDTO.IdEstado))
            {
                _notify.AddNotification(new NotificationMessage("Cidade informada já está registrada."));
                return false;
            }
            await _cidadeRepository.AddAsync(_mapper.Map<Cidade>(entityDTO));
            return await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<CidadeDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CidadeDTO>>(await _cidadeRepository.GetAllAsync());
        }

        public async Task<CidadeDTO> GetIdAsync(Guid id)
        {
            return _mapper.Map<CidadeDTO>(await _cidadeRepository.GetIdAsync(id));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await _cidadeRepository.RemoveAsync(id);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> UpdateAsync(CidadeDTO entityDTO)
        {
            if (!_executeValidation.ExecuteValidatorClass(new CidadeValidator(), entityDTO)) return false;
            if (await _cidadeRepository.Exists(entityDTO.Descricao, entityDTO.IdEstado))
            {
                _notify.AddNotification(new NotificationMessage("Cidade informada já está registrada."));
                return false;
            }
            await _cidadeRepository.UpdateAsync(_mapper.Map<Cidade>(entityDTO));
            return await _unitOfWork.Commit();
        }
    }
}

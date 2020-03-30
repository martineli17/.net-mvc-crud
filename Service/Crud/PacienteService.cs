using Crosscuting.Notification;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Service.Validator.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Crud
{
    public class PacienteService : ServiceBase, IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteService(IServiceProvider service, IPacienteRepository pacienteRepository) : base(service)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<bool> AddAsync(PacienteDTO entityDTO)
        {
            if (!_executeValidation.ExecuteValidatorClass(new PacienteValidator(), entityDTO)) return false;
            if (await _pacienteRepository.Exists(entityDTO.Cpf))
            {
                _notify.AddNotification(new NotificationMessage("Paciente informado já está registrado."));
                return false;
            }
            await _pacienteRepository.AddAsync(_mapper.Map<Paciente>(entityDTO));
            return await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<PacienteDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PacienteDTO>>(await _pacienteRepository.GetAllAsync());
        }

        public async Task<PacienteDTO> GetIdAsync(Guid id)
        {
            return _mapper.Map<PacienteDTO>(await _pacienteRepository.GetIdAsync(id));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await _pacienteRepository.RemoveAsync(id);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> UpdateAsync(PacienteDTO entityDTO)
        {
            if (!_executeValidation.ExecuteValidatorClass(new PacienteValidator(), entityDTO)) return false;
            if (await _pacienteRepository.Exists(entityDTO.Cpf))
            {
                var paciente = _mapper.Map<PacienteDTO>(_pacienteRepository.GetWithQueryAsync(p => p.Cpf.Equals(entityDTO.Cpf)).Result.FirstOrDefault());
                if (!paciente.Id.Equals(entityDTO.Id))
                {
                    _notify.AddNotification(new NotificationMessage("Paciente informado já está registrado."));
                    return false;
                }
                paciente.Nome = entityDTO.Nome;
                paciente.Cpf = entityDTO.Cpf;
                paciente.IdCidade = entityDTO.IdCidade;
                paciente.IdEstado = entityDTO.IdEstado;
                paciente.IdPais = entityDTO.IdPais;
                await _pacienteRepository.UpdateAsync(_mapper.Map<Paciente>(paciente));
            }
            else await _pacienteRepository.UpdateAsync(_mapper.Map<Paciente>(entityDTO));
            return await _unitOfWork.Commit();
        }
    }
}

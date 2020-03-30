using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.DTO
{
    public  class CidadeDTO : BaseDTO
    {
        public Guid IdEstado { get; set; }
        public EstadoDTO Estado { get; set; }
        public IEnumerable<PacienteDTO> Pacientes { get; set; }
    }
}

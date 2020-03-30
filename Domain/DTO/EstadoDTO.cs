using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class EstadoDTO : BaseDTO
    {
        public Guid IdPais { get; set; }
        public PaisDTO Pais { get; set; }
        public IEnumerable<CidadeDTO> Cidades { get; set; }
        public IEnumerable<PacienteDTO> Pacientes { get; set; }

    }
}

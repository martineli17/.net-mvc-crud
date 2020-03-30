using System.Collections.Generic;

namespace Domain.DTO
{
    public class PaisDTO : BaseDTO
    {
        public IEnumerable<PacienteDTO> Pacientes { get; set; }
        public IEnumerable<EstadoDTO> Estados { get; set; }
    }
}

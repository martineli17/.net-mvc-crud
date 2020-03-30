using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Cidade : EntityBase
    {
        public Guid IdEstado { get; private set; }
        public Estado Estado { get; private set; }
        public IEnumerable<Paciente> Pacientes { get; private set; }

        public Cidade()
        {

        }

        public Cidade(string pDescricao, Estado pEstado)
        {
            Id = Guid.NewGuid();
            Descricao = pDescricao;
            Estado = pEstado;
        }
    }
}

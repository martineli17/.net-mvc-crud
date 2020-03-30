using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pais : EntityBase
    {
        public Guid IdEstado { get; private set; }
        public IEnumerable<Paciente> Pacientes { get; private set; }
        public IEnumerable<Estado> Estados { get; private set; }
        public Pais()
        {

        }

        public Pais(string pDescricao)
        {
            Id = Guid.NewGuid();
            Descricao = pDescricao;
        }
    }
}

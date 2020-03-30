using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Estado : EntityBase
    {
        public Guid IdPais { get; private set; }
        public Pais Pais { get; private set; }
        public IEnumerable<Cidade> Cidades { get; private set; }
        public IEnumerable<Paciente> Pacientes { get; private set; }
        public Estado()
        {

        }

        public Estado(string pDescricao, Pais pPais)
        {
            Id = Guid.NewGuid();
            Descricao = pDescricao;
            Pais = pPais;
        }
    }
}

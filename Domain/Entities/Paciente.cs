using System;

namespace Domain.Entities
{
    public class Paciente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Guid Id { get; private set; }
        public Guid IdPais { get; private set; }
        public Guid IdEstado { get; private set; }
        public Guid IdCidade { get; private set; }
        public Pais Pais { get; private set; }
        public Estado Estado { get; private set; }
        public Cidade Cidade { get; private set; }
        public Paciente()
        {

        }

        public Paciente(string pNome, string pCpf, Guid pPais, Guid pEstado, Guid pCidade)
        {
            Id = Guid.NewGuid();
            Nome = pNome;
            Cpf = pCpf;
            IdPais = pPais;
            IdEstado = pEstado;
            IdCidade = pCidade;
        }
    }
}

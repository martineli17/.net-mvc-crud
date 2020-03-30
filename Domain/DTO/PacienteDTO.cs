using Domain.Entities;
using System;

namespace Domain.DTO
{
    public class PacienteDTO
    {
        public string Nome { get;  set; }
        public string Cpf { get;  set; }
        public Guid Id { get;  set; }
        public Guid IdEstado { get;  set; }
        public Guid IdCidade { get;  set; }
        public Guid IdPais { get;  set; }
        public PaisDTO Pais { get;  set; }
        public EstadoDTO Estado { get;  set; }
        public CidadeDTO Cidade { get;  set; }
    }
}

using System;

namespace Apresentation.Models.Paciente
{
    public class PacienteViewModelPost
    {
        public string Nome { get;  set; }
        public string Cpf { get;  set; }
        public Guid IdEstado { get; set; }
        public Guid IdCidade { get; set; }
        public Guid IdPais { get; set; }
    }

    public class PacienteViewModelGet
    {
        public Guid Id { get;  set; }
        public Guid IdCidade { get;  set; }
        public Guid IdEstado { get;  set; }
        public Guid IdPais { get;  set; }
        public string Nome { get;  set; }
        public string Cpf { get;  set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
    }

    public class PacienteViewModelPut
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid IdEstado { get; set; }
        public Guid IdCidade { get; set; }
        public Guid IdPais { get; set; }
    }
}

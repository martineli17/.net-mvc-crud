using System;

namespace Apresentation.Models.Cidade
{
    public class CidadeViewModelPost
    {
        public string Descricao { get; set; }
        public Guid IdEstado { get; set; }
    }

    public class CidadeViewModelGet : CidadeViewModelPost
    {
        public string Estado { get; set; }
        public Guid IdEstado { get; set; }
        public Guid Id { get; set; }
    }

    public class CidadeViewModelPut
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IdEstado { get; set; }
    }
}

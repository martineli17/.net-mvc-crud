using Apresentation.Models.Pais;
using System;

namespace Apresentation.Models.Estado
{
    public class EstadoViewModelPost
    {
        public string Descricao { get; set; }
        public Guid IdPais { get; set; }
    }

    public class EstadoViewModelGet
    {
        public string Descricao { get; set; }
        public Guid Id { get; set; }
        public Guid IdPais { get; set; }
        public string Pais { get; set; }
    }

    public class EstadoViewModelPut
    {
        public string Descricao { get; set; }
        public Guid Id { get; set; }
        public Guid IdPais { get; set; }
    }
}

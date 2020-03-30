using Domain.DTO;
using System;
using System.Collections.Generic;

namespace Apresentation.Models.Pais
{
    public class PaisViewModelPost
    {
        public string Descricao { get; set; }
        public Guid Id { get; set; }
    }

    public class PaisViewModelGet
    {
        public string Descricao { get; set; }
        public Guid Id { get; set; }
    }
}

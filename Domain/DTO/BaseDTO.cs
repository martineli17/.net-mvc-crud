using System;

namespace Domain.DTO
{
    public abstract class BaseDTO
    {
        public string Descricao { get; set; }
        public Guid Id { get; set; }
    }
}

using System;

namespace Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
    }
}

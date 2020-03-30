namespace Domain.Entities
{
    public abstract class EntityBasePessoa
    {
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
    }
}

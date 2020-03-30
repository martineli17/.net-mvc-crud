using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Mapping;

namespace Repository.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Pais> Pais { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PaisMapping());
            builder.ApplyConfiguration(new EstadoMapping());
            builder.ApplyConfiguration(new CidadeMapping());
            builder.ApplyConfiguration(new PacienteMapping());
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id);
            builder.HasIndex(p => p.Cpf);
            builder.Property(p => p.Id).HasColumnName("id").HasColumnType("varchar(500)").IsUnicode(false).IsRequired();
            builder.Property(p => p.Nome).HasColumnName("nome").HasColumnType("varchar(100)").IsUnicode(false).IsRequired();
            builder.Property(p => p.Cpf).HasColumnName("cpf").HasColumnType("varchar(11)").IsUnicode(false).IsRequired();
            builder.Property(p => p.IdCidade).HasColumnName("idCidade").HasColumnType("varchar(500)").IsUnicode(true).IsRequired();
            builder.Property(p => p.IdEstado).HasColumnName("idEstado").HasColumnType("varchar(500)").IsUnicode(true).IsRequired();
            builder.Property(p => p.IdPais).HasColumnName("idPais").HasColumnType("varchar(500)").IsUnicode(true).IsRequired();
            builder.HasOne(p => p.Cidade).WithMany(c => c.Pacientes).HasForeignKey(p => p.IdCidade);
            builder.HasOne(p => p.Estado).WithMany(e => e.Pacientes).HasForeignKey(p => p.IdEstado);
            builder.HasOne(p => p.Pais).WithMany(p => p.Pacientes).HasForeignKey(p => p.IdPais);
        }
    }

}

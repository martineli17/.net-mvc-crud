using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c=> c.Id);
            builder.HasIndex(c=> c.Descricao);
            builder.Property(c=> c.Id).HasColumnName("id").HasColumnType("varchar(500)").IsUnicode(true).IsRequired();
            builder.Property(c=> c.Descricao).HasColumnName("descricao").HasColumnType("varchar(100)").IsUnicode(false).IsRequired();
            builder.Property(c=> c.IdEstado).HasColumnName("idEstado").HasColumnType("varchar(500)").IsUnicode(true).IsRequired();
            builder.HasOne(c => c.Estado).WithMany(e => e.Cidades).HasForeignKey(c => c.IdEstado);
        }
    }
}

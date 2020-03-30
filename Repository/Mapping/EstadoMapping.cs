using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id);
            builder.HasIndex(p => p.Descricao);
            builder.Property(p => p.Id).HasColumnName("id").HasColumnType("varchar(500)").IsUnicode(true).IsRequired();
            builder.Property(p => p.Descricao).HasColumnName("descricao").HasColumnType("varchar(100)").IsUnicode(false).IsRequired();
            builder.Property(p => p.IdPais).HasColumnName("idPais").HasColumnType("varchar(500)").IsUnicode(true).IsRequired();
            builder.HasOne(e => e.Pais).WithMany(p => p.Estados).HasForeignKey(p => p.IdPais);
        }
    }
}

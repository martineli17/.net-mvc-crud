using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    public class PaisMapping : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id);
            builder.HasIndex(p => p.Descricao);
            builder.Property(p => p.Id).HasColumnName("id").HasColumnType("varchar(500)").IsUnicode(true).IsRequired();
            builder.Property(p => p.Descricao).HasColumnName("descricao").HasColumnType("varchar(100)").IsUnicode(false).IsRequired();
            builder.HasMany(p => p.Estados).WithOne(e => e.Pais).HasForeignKey(e => e.IdPais);
        }
    }
}

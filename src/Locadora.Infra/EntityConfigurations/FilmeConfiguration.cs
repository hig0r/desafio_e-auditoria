using Locadora.Domain.FilmeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.EntityConfigurations;

public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
{
    public void Configure(EntityTypeBuilder<Filme> builder)
    {
        builder.Property(x => x.Titulo).HasColumnType("VARCHAR(100)");
        builder.HasIndex(x => x.Lancamento, "idx_Lancamento");
        builder.HasIndex(x => x.Titulo, "idx_Titulo");
    }
}
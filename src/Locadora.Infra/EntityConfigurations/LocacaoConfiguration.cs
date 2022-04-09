using Locadora.Domain.LocacaoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.EntityConfigurations;

public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
{
    public void Configure(EntityTypeBuilder<Locacao> builder)
    {
        builder.ToTable("Locacoes");
        builder.HasOne(x => x.Filme).WithMany(x => x.Locacoes);
        builder.HasOne(x => x.Cliente).WithMany(x => x.Locacoes);
        builder.HasIndex(x => x.ClienteId, "FK_Cliente_idx");
        builder.HasIndex(x => x.FilmeId, "FK_Filme_idx");
    }
}
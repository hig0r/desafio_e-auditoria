using Locadora.Domain.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.EntityConfigurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.Property(x => x.Nome).HasColumnType("VARCHAR(200)");
        builder.Property(x => x.Cpf)
            .HasColumnType("VARCHAR(11)")
            .HasConversion(
                x => x.Value,
                x => new Cpf(x));
        builder.HasIndex(x => x.Cpf, "idx_Cpf").IsUnique();
        builder.HasIndex(x => x.Nome, "idx_Nome");
    }
}
using System.Reflection;
using Locadora.Domain.ClienteAggregate;
using Locadora.Domain.FilmeAggregate;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra;

public class LocadoraDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Filme> Filmes { get; set; }
    
    public LocadoraDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(LocadoraDbContext))!);
        base.OnModelCreating(modelBuilder);
    }
}
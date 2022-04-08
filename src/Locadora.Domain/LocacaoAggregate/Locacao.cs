using Locadora.Domain.ClienteAggregate;
using Locadora.Domain.Common;
using Locadora.Domain.FilmeAggregate;

namespace Locadora.Domain.LocacaoAggregate;

public class Locacao : Entity
{
    private Locacao()
    {
    }
    
    public Locacao(Filme filme, Cliente cliente)
    {
        Filme = filme;
        Cliente = cliente;
    }

    public Cliente Cliente { get; private set; }
    public int ClienteId { get; private set; }
    public Filme Filme { get; private set; }
    public int FilmeId { get; private set; }
    public DateTime DataLocacao { get; private set; } = DateTime.Today;

    public DateTime DataDevolucao
    {
        get => DataLocacao.AddDays(Filme.Lancamento ? 2 : 3);
        set { }
    }
}
using Locadora.Domain.ClienteAggregate;
using Locadora.Domain.Common;
using Locadora.Domain.LocacaoAggregate;

namespace Locadora.Domain.FilmeAggregate;

public class Filme : Entity
{
    private List<Locacao> _locacoes = new();
    private string _titulo;
    private int _classificacaoIndicativa;

    public string Titulo
    {
        get => _titulo;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _titulo = value;
        }
    }

    public int ClassificacaoIndicativa
    {
        get => _classificacaoIndicativa;
        set
        {
            if (value is not 0 or 10 or 12 or 14 or 16 or 18)
                throw new ArgumentException("Classificação indicativa deve ser 0 (L), 10, 12, 14, 16 ou 18");
            _classificacaoIndicativa = value;
        }
    }

    public bool Lancamento { get; set; }

    public IReadOnlyCollection<Locacao> Locacoes => _locacoes.AsReadOnly();

    public void AdicionarLocacao(Cliente cliente)
    {
        _locacoes.Add(new Locacao(this, cliente));
    }
}
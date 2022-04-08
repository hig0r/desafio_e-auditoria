using Locadora.Domain.Common;

namespace Locadora.Domain.FilmeAggregate;

public class Filme : Entity
{
    private Filme()
    {
    }

    public Filme(string titulo, int classificacaoIndicativa, bool lancamento)
    {
        ArgumentNullException.ThrowIfNull(titulo);
        if (classificacaoIndicativa is not 0 or 10 or 12 or 14 or 16 or 18)
            throw new ArgumentException("Classificação indicativa deve ser 0 (L), 10, 12, 14, 16 ou 18");
        Titulo = titulo;
        ClassificacaoIndicativa = classificacaoIndicativa;
        Lancamento = lancamento;
    }

    public string Titulo { get; private set; }
    public int ClassificacaoIndicativa { get; private set; }
    public bool Lancamento { get; private set; }
}
using Locadora.Domain.Common;
using Locadora.Domain.LocacaoAggregate;

namespace Locadora.Domain.ClienteAggregate;

public class Cliente : Entity
{
    private List<Locacao> _locacoes = new();
    private string _nome = null!;
    private DateTime _dataNascimento;
    private Cpf _cpf = null!;

    private Cliente()
    {
    }

    public Cliente(string nome, Cpf cpf, DateTime dataNascimento)
    {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
    }

    public string Nome
    {
        get => _nome;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _nome = value;
        }
    }

    public Cpf Cpf
    {
        get => _cpf;
        private init
        {
            ArgumentNullException.ThrowIfNull(value);
            _cpf = value;
        }
    }

    public DateTime DataNascimento
    {
        get => _dataNascimento;
        set
        {
            if (value == default)
                throw new ArgumentException("Especifique uma data.");
            if (value.Date > DateTime.Today)
                throw new ArgumentException("Data de nascimento não pode ser maior que hoje");
            _dataNascimento = value.Date;
        }
    }

    public ICollection<Locacao> Locacoes => _locacoes.AsReadOnly();
}
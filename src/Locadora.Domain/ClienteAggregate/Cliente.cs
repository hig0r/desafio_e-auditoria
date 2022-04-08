using Locadora.Domain.Common;

namespace Locadora.Domain.ClienteAggregate;

public class Cliente : Entity
{
    private Cliente()
    {
    }

    public Cliente(string nome, Cpf cpf, DateTime dataNascimento)
    {
        ArgumentNullException.ThrowIfNull(nome);
        ArgumentNullException.ThrowIfNull(cpf);
        if (dataNascimento.Date > DateTime.Today)
            throw new ArgumentException("Data de nascimento não pode ser maior que hoje");
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento.Date;
    }
    
    public string Nome { get; private set; } = null!;
    public Cpf Cpf { get; private set; } = null!;
    public DateTime DataNascimento { get; private set; }
}
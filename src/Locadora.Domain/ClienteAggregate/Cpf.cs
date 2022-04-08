using System.Text.RegularExpressions;

namespace Locadora.Domain.ClienteAggregate;

public class Cpf
{
    private Cpf()
    {
    }

    public Cpf(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value.Length is not 11) throw new ArgumentException("Cpf deve ter 11 caracteres");
        if (!Regex.IsMatch(value, "^[0-9]*$")) throw new ArgumentException("Cpf deve conter somente dígitos");
        // Validar dígito verificador
        Value = value;
    }
    
    public string Value { get; } = null!;
}
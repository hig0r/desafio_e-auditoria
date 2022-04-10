using System.Text.Json;
using System.Text.Json.Serialization;
using Locadora.Domain.ClienteAggregate;

namespace Locadora.Api.Converters;

public class CpfJsonConverter : JsonConverter<Cpf>
{
    public override Cpf Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new Cpf(reader.GetString() ?? "");
    }

    public override void Write(Utf8JsonWriter writer, Cpf cpf, JsonSerializerOptions options)
    {
        writer.WriteStringValue(cpf.Value);
    }
}
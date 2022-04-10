namespace Locadora.Application.Common.Exceptions;

public class EntityNotFoundException<T> : Exception
{
    public EntityNotFoundException(object key) : 
        base($"Entidade {typeof(T).Name} com o id {key} não foi encontrada.")
    {
    }
}
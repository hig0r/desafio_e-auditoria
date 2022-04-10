using Locadora.Application.Common.Exceptions;
using Locadora.Domain.ClienteAggregate;
using Locadora.Infra;
using Mapster;
using MediatR;

namespace Locadora.Application.Clientes.Commands;

public class AlterarClienteCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public class AlterarClienteCommandHandler : IRequestHandler<AlterarClienteCommand, int>
    {
        private readonly LocadoraDbContext _dbContext;

        public AlterarClienteCommandHandler(LocadoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<int> Handle(AlterarClienteCommand request, CancellationToken ct)
        {
            var cliente = await _dbContext.Clientes.FindAsync(request.Id);
            if (cliente == null)
                throw new EntityNotFoundException<Cliente>(request.Id);
            request.Adapt(cliente);
            await _dbContext.SaveChangesAsync(ct);
            return cliente.Id;
        }
    }
}
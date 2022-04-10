using Locadora.Application.Common.Exceptions;
using Locadora.Domain.ClienteAggregate;
using Locadora.Infra;
using MediatR;

namespace Locadora.Application.Clientes.Queries;

public class GetClienteByIdQuery : IRequest<Cliente>
{
    public int Id { get; set; }
    
    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
    {
        private readonly LocadoraDbContext _dbContext;

        public GetClienteByIdQueryHandler(LocadoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _dbContext.Clientes.FindAsync(request.Id);
            if (cliente is null)
                throw new EntityNotFoundException<Cliente>(request.Id);
            return cliente;
        }
    }
}
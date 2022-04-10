using Locadora.Domain.ClienteAggregate;
using Locadora.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Application.Clientes.Queries;

public class GetAllClientes : IRequest<IEnumerable<Cliente>>
{
    public class GetAllClientesHandler : IRequestHandler<GetAllClientes, IEnumerable<Cliente>>
    {
        private readonly LocadoraDbContext _dbContext;

        public GetAllClientesHandler(LocadoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> Handle(GetAllClientes request, CancellationToken ct)
        {
            return await _dbContext.Clientes.ToListAsync(ct);
        }
    }
}
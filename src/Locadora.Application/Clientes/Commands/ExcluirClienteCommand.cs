using Locadora.Infra;
using MediatR;

namespace Locadora.Application.Clientes.Commands;

public class ExcluirClienteCommand : IRequest
{
    public int Id { get; set; }

    public class ExcluirClienteCommandHandler : IRequestHandler<ExcluirClienteCommand>
    {
        private readonly LocadoraDbContext _dbContext;

        public ExcluirClienteCommandHandler(LocadoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Unit> Handle(ExcluirClienteCommand request, CancellationToken ct)
        {
            var cliente = await _dbContext.Clientes.FindAsync(request.Id);
            if (cliente is null) return default;
            _dbContext.Remove(cliente);
            await _dbContext.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
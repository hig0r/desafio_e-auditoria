using FluentValidation;
using Locadora.Domain.ClienteAggregate;
using Locadora.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Application.Clientes.Commands;

public class NovoClienteCommand : IRequest<int>
{
    public string Nome { get; set; }
    public Cpf Cpf { get; set; }
    public DateTime DataNascimento { get; set; }

    public class NovoClienteCommandHandler : IRequestHandler<NovoClienteCommand, int>
    {
        private readonly LocadoraDbContext _dbContext;

        public NovoClienteCommandHandler(LocadoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(NovoClienteCommand request, CancellationToken ct)
        {
            var cliente = new Cliente(request.Nome, request.Cpf, request.DataNascimento);
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync(ct);
            return cliente.Id;
        }
    }

    public class NovoClienteCommandValidator : AbstractValidator<NovoClienteCommand>
    {
        public NovoClienteCommandValidator(LocadoraDbContext dbContext)
        {
            RuleFor(x => x.Cpf)
                .MustAsync(async (cpf, ct) =>
                {
                    var c = await dbContext.Clientes.FirstOrDefaultAsync(x => x.Cpf == cpf, ct);
                    return c == null;
                })
                .WithMessage("Já existe um cliente cadastrado com este CPF.");
        }
    }
}
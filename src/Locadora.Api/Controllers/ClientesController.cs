using Locadora.Application.Clientes.Commands;
using Locadora.Application.Clientes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers;

public class ClientesController : ApiController
{
    private readonly IMediator _mediator;

    public ClientesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetAllClientes()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _mediator.Send(new GetClienteByIdQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post(NovoClienteCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, AlterarClienteCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new ExcluirClienteCommand { Id = id });
        return NoContent();
    }
}
using application.Clientes.Commands.CreateCliente;
using application.Clientes.Commands.DeleteCliente;
using application.Clientes.Commands.UpdateCliente;
using application.Clientes.Queries.GetClienteById;
using application.Clientes.Queries.GettAllClientes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace rev.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController: ControllerBase
{
    private readonly IMediator _mediator;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllClientesQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetClienteByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClienteCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateClienteCommand command)
    {
        if (id != command.id) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteClienteCommand(id));
        return NoContent();
    }
}
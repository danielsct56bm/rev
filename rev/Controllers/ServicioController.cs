using application.Servicios.Commands.CreateServicio;
using application.Servicios.Commands.DeleteServicio;
using application.Servicios.Commands.UpdateServicio;
using application.Servicios.Queries.GetAllServicios;
using application.Servicios.Queries.GetServicioById;
using application.Servicios.Queries.GetServicioByIdCliente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace rev.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicioController: ControllerBase
{
    private readonly IMediator _mediator;

    public ServicioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllServiciosQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetServicioByIdQuery(id));
        return Ok(result);
    }

    [HttpGet("{idCliente}")]
    public async Task<IActionResult> GetByIdCliente(int id)
    {
        var result = await _mediator.Send(new GetServicioByIdClienteQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServicioCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateServicioCommand command)
    {
        if (id != command.id) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteServicioCommand(id));
        return NoContent();
    }
    
}
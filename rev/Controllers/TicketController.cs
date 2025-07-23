using application.Tickets.Commands.CreateTicket;
using application.Tickets.Commands.DeleteTicket;
using application.Tickets.Commands.UpdateTicket;
using application.Tickets.Queries.GetAllTickets;
using application.Tickets.Queries.GetTicketById;
using application.Tickets.Queries.GetTicketByIdCliente;
using application.Tickets.Queries.GetTicketByIdServicio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace rev.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController: ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllTicketsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetTicketByIdQuery(id));
        return Ok(result);
    }
    
    [HttpGet("{idCliente}")]
    public async Task<IActionResult> GetByIdCliente(int idCliente)
    {
        var result = await _mediator.Send(new GetTicketByIdClienteQuery(idCliente));
        return Ok(result);
    }
    
    [HttpGet("{idServicio}")]
    public async Task<IActionResult> GetByIdServicio(int id)
    {
        var result = await _mediator.Send(new GetTicketByIdServicioQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTicketCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTicketCommand command)
    {
        if (id != command.id) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteTicketCommand(id));
        return NoContent();
    }
    
}
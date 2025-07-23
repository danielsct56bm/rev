using application.common.Interfaces;
using application.Tickets.Dtos;
using MediatR;

namespace application.Tickets.Queries.GetTicketByIdCliente;

public class GetTicketByIdClienteHandler:IRequestHandler<GetTicketByIdClienteQuery, TicketDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketByIdClienteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TicketDto> Handle(GetTicketByIdClienteQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.Tickets.GetTicketByClientIdAsync(request.idCliente);

        return new TicketDto()
        {
            asunto = ticket.asunto,
            fechaFin = ticket.fechaFin,
            fechaInicio = ticket.fechaInicio,
            id = ticket.id,
            idCliente = ticket.idCliente,
            idServicio = ticket.idServicio,
            status = ticket.status,
            statusFinal = ticket.statusFinal,
            ticket = ticket.ticket,
        };
    }
}
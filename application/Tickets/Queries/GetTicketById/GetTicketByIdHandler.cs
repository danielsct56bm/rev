using application.common.Interfaces;
using application.Tickets.Dtos;
using MediatR;

namespace application.Tickets.Queries.GetTicketById;

public class GetTicketByIdHandler: IRequestHandler<GetTicketByIdQuery, TicketDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.Tickets.GetTicketByIdAsync(request.id);
        if (ticket == null) throw new KeyNotFoundException("ticket no encontrado");
        
        return new TicketDto()
        {
            id = ticket.id,
            asunto = ticket.asunto,
            fechaFin = ticket.fechaFin,
            fechaInicio = ticket.fechaInicio,
            idCliente = ticket.idCliente,
            idServicio = ticket.idServicio,
            status = ticket.status ?? "?",
            statusFinal = ticket.statusFinal ?? "?",
            ticket = ticket.ticket,
        };
    }
}
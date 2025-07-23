using application.common.Interfaces;
using application.Tickets.Dtos;
using MediatR;

namespace application.Tickets.Queries.GetTicketByIdServicio;

public class GetTicketByIdServicioHandler: IRequestHandler<GetTicketByIdServicioQuery, TicketDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketByIdServicioHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TicketDto> Handle(GetTicketByIdServicioQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.Tickets.GetTicketByServiceIdAsync(request.idServicio);
        if (ticket == null) throw new KeyNotFoundException("Ticket no encontrado");

        return new TicketDto()
        {
            asunto = ticket.asunto,
            fechaInicio = ticket.fechaInicio,
            fechaFin = ticket.fechaFin,
            id = ticket.id,
            idCliente = ticket.idCliente,
            idServicio = ticket.idServicio,
            status = ticket.status,
            statusFinal = ticket.statusFinal,
            ticket = ticket.ticket,
        };
    }
}
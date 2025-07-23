using application.common.Interfaces;
using application.Tickets.Dtos;
using MediatR;

namespace application.Tickets.Queries.GetAllTickets;

public class GetAllTicketHandler:IRequestHandler<GetAllTicketsQuery, List<TicketDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTicketHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _unitOfWork.Tickets.GetTicketsAsync();

        return tickets.Select(x => new TicketDto
        {
            id = x.id,
            asunto = x?.asunto,
            fechaInicio = x?.fechaInicio,
            fechaFin = x?.fechaFin,
            idCliente = x?.idCliente,
            idServicio = x?.idServicio,
            status = x?.status,
            statusFinal = x?.statusFinal,
            ticket = x.ticket,
        }).ToList();
    }
}
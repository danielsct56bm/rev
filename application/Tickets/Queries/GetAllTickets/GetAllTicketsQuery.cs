using application.Tickets.Dtos;
using MediatR;

namespace application.Tickets.Queries.GetAllTickets;

public class GetAllTicketsQuery:IRequest<List<TicketDto>> 
{
    
}
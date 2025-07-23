using application.Tickets.Dtos;
using MediatR;

namespace application.Tickets.Queries.GetTicketById;

public class GetTicketByIdQuery:IRequest<TicketDto>
{
    public int id { get; set; }

    public GetTicketByIdQuery(int id)
    {
        this.id = id;
    }
}
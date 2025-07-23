using application.Tickets.Dtos;
using MediatR;

namespace application.Tickets.Queries.GetTicketByIdServicio;

public class GetTicketByIdServicioQuery: IRequest<TicketDto>
{
    public int idServicio { get; set; }

    public GetTicketByIdServicioQuery(int id)
    {
        this.idServicio = id;
    }
}
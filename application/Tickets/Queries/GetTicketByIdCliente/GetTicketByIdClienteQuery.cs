using application.Tickets.Dtos;
using MediatR;

namespace application.Tickets.Queries.GetTicketByIdCliente;

public class GetTicketByIdClienteQuery:IRequest<TicketDto>
{
    public int idCliente { get; set; }

    public GetTicketByIdClienteQuery(int id)
    {
        this.idCliente = id;
    }
}
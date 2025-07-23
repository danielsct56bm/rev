using MediatR;

namespace application.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommand:IRequest<Unit>
{
    public int id { get; set; }
}
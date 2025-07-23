using MediatR;

namespace application.Tickets.Commands.CreateTicket;

public class CreateTicketCommand: IRequest<Unit>
{
    public int? idCliente { get; set; }
    public string ticket { get; set; } = null!;
    public string? asunto { get; set; }
    public DateTime? fechaInicio { get; set; }
    public string? status { get; set; }
    public int? idServicio { get; set; }
    public DateTime? fechaFin { get; set; }
    public string? statusFinal { get; set; }
}
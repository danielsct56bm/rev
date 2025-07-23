using application.common.Interfaces;
using domain.Entities;
using MediatR;

namespace application.Tickets.Commands.CreateTicket;

public class CreateTicketHandler: IRequestHandler<CreateTicketCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new tickets
        {
            idCliente = request.idCliente,
            ticket = request.ticket,
            asunto = request.asunto,
            fechaInicio = request.fechaInicio,
            status = request.status,
            idServicio = request.idServicio,
            fechaFin = request.fechaFin,
            statusFinal = request.statusFinal,
        };
        
        await _unitOfWork.Tickets.AddTicketAsync(ticket);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}
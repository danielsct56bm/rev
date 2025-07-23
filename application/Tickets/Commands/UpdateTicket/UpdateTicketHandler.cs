using application.common.Interfaces;
using MediatR;

namespace application.Tickets.Commands.UpdateTicket;

public class UpdateTicketHandler:IRequestHandler<UpdateTicketCommand,Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.Tickets.GetTicketByIdAsync(request.id);
        if (ticket == null) throw new KeyNotFoundException("ticket no encontrado");
        
        if(request.idCliente.HasValue) ticket.idCliente=request.idCliente;
        if (!string.IsNullOrWhiteSpace(request.ticket))
            ticket.ticket = request.ticket;

        if (!string.IsNullOrWhiteSpace(request.asunto))
            ticket.asunto = request.asunto;

        if (request.fechaInicio.HasValue)
            ticket.fechaInicio = request.fechaInicio.Value;

        if (!string.IsNullOrWhiteSpace(request.status))
            ticket.status = request.status;

        if (request.idServicio.HasValue)
            ticket.idServicio = request.idServicio.Value;

        if (request.fechaFin.HasValue)
            ticket.fechaFin = request.fechaFin.Value;

        if (!string.IsNullOrWhiteSpace(request.statusFinal))
            ticket.statusFinal = request.statusFinal;

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
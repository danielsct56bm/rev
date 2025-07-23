using application.common.Interfaces;
using application.Tickets.Commands.UpdateTicket;
using MediatR;

namespace application.Tickets.Commands.DeleteTicket;

public class DeleteTicketHandler:IRequestHandler<UpdateTicketCommand,Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.Tickets.GetTicketByIdAsync(request.id);
        if (ticket == null) throw new KeyNotFoundException("Ticket no encontrado");
        
        await _unitOfWork.Tickets.DeleteTicketAsync(request.id);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}
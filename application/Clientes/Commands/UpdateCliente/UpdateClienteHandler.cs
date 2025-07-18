using application.common.Interfaces;
using MediatR;

namespace application.Clientes.Commands.UpdateCliente;

public class UpdateClienteHandler: IRequestHandler<UpdateClienteCommand,Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClienteHandler(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(request.id);
        if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado");
        
        if (request.nombre != null) cliente.nombre = request.nombre;
        if (request.correo != null) cliente.correo = request.correo;
        
        await _unitOfWork.Clientes.UpdateAsync(cliente);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}
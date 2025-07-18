using application.common.Interfaces;
using MediatR;

namespace application.Clientes.Commands.DeleteCliente;

public class DeleteClienteHandler: IRequestHandler<DeleteClienteCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClienteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(request.id);
        if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado");

        await _unitOfWork.Clientes.DeleteAsync(request.id);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}
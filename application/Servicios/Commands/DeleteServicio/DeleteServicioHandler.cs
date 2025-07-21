using application.common.Interfaces;
using MediatR;

namespace application.Servicios.Commands.DeleteServicio;

public class DeleteServicioHandler: IRequestHandler<DeleteServicioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServicioHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteServicioCommand request, CancellationToken cancellationToken)
    {
        var servicio = await _unitOfWork.Servicios.GetByIdAsync(request.Id);
        if (servicio == null) throw new NullReferenceException("Servicio no encontrado");
        
        await _unitOfWork.Servicios.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
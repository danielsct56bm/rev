using application.common.Interfaces;
using MediatR;

namespace application.Servicios.Commands.UpdateServicio;

public class UpdateServicioHandler: IRequestHandler<UpdateServicio.UpdateServicioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateServicioHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(UpdateServicio.UpdateServicioCommand request, CancellationToken cancellationToken)
    {
        var servicio = await _unitOfWork.Servicios.GetByIdAsync(request.id);
        if (servicio == null) throw new KeyNotFoundException("servicio no encontrado");
        
        if (request.idCliente != null) servicio.idCliente = request.idCliente;
        if (request.servicio != null) servicio.servicio = request.servicio;
        if (request.fechaRenovacion != null) servicio.fechaRenovacion = request.fechaRenovacion;
        if (request.monto != null) servicio.monto = request.monto;
        
        await _unitOfWork.Servicios.UpdateAsync(servicio);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}
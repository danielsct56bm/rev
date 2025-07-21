using application.common.Interfaces;
using domain.Entities;
using MediatR;

namespace application.Servicios.Commands.CreateServicio;

public class CreateServicioHandler: IRequestHandler<CreateServicioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServicioHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(CreateServicioCommand request, CancellationToken cancellationToken)
    {
        var servicio = new servicios
        {
            idCliente = request.idCliente,
            servicio = request.servicio,
            fechaRenovacion = request.fechaRenovacion,
            monto = request.monto
        };
        await _unitOfWork.Servicios.AddAsync(servicio);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}
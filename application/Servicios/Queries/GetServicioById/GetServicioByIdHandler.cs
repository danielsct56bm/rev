using application.common.Interfaces;
using MediatR;

namespace application.Servicios.Queries.GetServicioById;

public class GetServicioByIdHandler:IRequestHandler<GetServicioByIdQuery,ServicioDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServicioByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ServicioDto> Handle(GetServicioByIdQuery request, CancellationToken cancellationToken)
    {
        var servicio = await _unitOfWork.Servicios.GetByIdAsync(request.id);
        if (servicio == null) throw new KeyNotFoundException("servicio no encontrado");
        
        return new ServicioDto
        {
            id = request.id,
            idCliente = servicio.idCliente,
            servicio = servicio.servicio,
            fechaInicio = servicio.fechaInicio ?? DateTime.Today,
            fechaRenovacion = servicio.fechaRenovacion,
            monto = servicio.monto,
        };
    }
}
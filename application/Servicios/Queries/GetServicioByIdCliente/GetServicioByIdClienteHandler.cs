using application.common.Interfaces;
using MediatR;

namespace application.Servicios.Queries.GetServicioByIdCliente;

public class GetServicioByIdClienteHandler: IRequestHandler<GetServicioByIdClienteQuery, ServicioDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServicioByIdClienteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ServicioDto> Handle(GetServicioByIdClienteQuery request, CancellationToken cancellationToken)
    {
        var servicio = await _unitOfWork.Servicios.GetByClientIdAsync(request.idCliente);
        if (servicio == null) throw new KeyNotFoundException("servicio no encontrado");

        return new ServicioDto()
        {
            id = servicio.id,
            idCliente = servicio.idCliente,
            servicio = servicio.servicio,
            fechaInicio = servicio.fechaInicio ?? DateTime.Today,
            fechaRenovacion = servicio.fechaRenovacion,
            monto = servicio.monto,
        };
    }
}
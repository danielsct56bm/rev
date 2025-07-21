using application.common.Interfaces;
using MediatR;

namespace application.Servicios.Queries.GetAllServicios;

public class GetAllServiciosHandler:IRequestHandler<GetAllServiciosQueries,List<ServicioDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllServiciosHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<ServicioDto>> Handle(GetAllServiciosQueries request, CancellationToken cancellationToken)
    {
        var servicios = await _unitOfWork.Servicios.GetAllAsync();
        return servicios.Select(x=> new ServicioDto
        {
            id = x.id,
            idCliente = x.idCliente,
            fechaInicio = x.fechaInicio ?? DateTime.Now,
            fechaRenovacion = x.fechaRenovacion,
            monto = x.monto,
        }).ToList();
    }
}
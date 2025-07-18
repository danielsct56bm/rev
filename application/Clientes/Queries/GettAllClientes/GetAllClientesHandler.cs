using application.Clientes.Dtos;
using application.common.Interfaces;
using MediatR;

namespace application.Clientes.Queries.GettAllClientes;

public class GetAllClientesHandler:IRequestHandler<GetAllClientesQuery, List<ClienteDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllClientesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<ClienteDto>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
    {
        var clientes = await _unitOfWork.Clientes.ListAsync();

        return clientes.Select(c => new ClienteDto
        {
            id = c.id,
            nombre = c.nombre,
            correo = c.correo,
            fechaRegistro = c.fechaRegistro
        }).ToList();
    }
}
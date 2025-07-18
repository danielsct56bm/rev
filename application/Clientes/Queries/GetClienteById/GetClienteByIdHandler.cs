using application.Clientes.Dtos;
using application.common.Interfaces;
using MediatR;

namespace application.Clientes.Queries.GetClienteById;

public class GetClienteByIdHandler: IRequestHandler<GetClienteByIdQuery, ClienteDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClienteByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ClienteDto> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(request.Id);
        if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado");

        return new ClienteDto
        {
            id = cliente.id,
            nombre = cliente.nombre,
            correo = cliente.correo,
            fechaRegistro = cliente.fechaRegistro,
        };
    }
}
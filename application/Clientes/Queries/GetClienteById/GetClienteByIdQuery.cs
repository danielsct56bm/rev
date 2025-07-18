using application.Clientes.Dtos;
using MediatR;

namespace application.Clientes.Queries.GetClienteById;

public class GetClienteByIdQuery: IRequest<ClienteDto>
{
    public int Id { get; set; }

    public GetClienteByIdQuery(int Id)
    {
        this.Id = Id;
    }
}
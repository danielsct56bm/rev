using application.Clientes.Dtos;
using MediatR;

namespace application.Clientes.Queries.GettAllClientes;

public class GetAllClientesQuery:IRequest<List<ClienteDto>>
{
    
}
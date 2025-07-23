using MediatR;

namespace application.Servicios.Queries.GetServicioByIdCliente;

public class GetServicioByIdClienteQuery: IRequest<ServicioDto>
{
    public int idCliente { get; set; }

    public GetServicioByIdClienteQuery(int id)
    {
        this.idCliente = id;
    }
}
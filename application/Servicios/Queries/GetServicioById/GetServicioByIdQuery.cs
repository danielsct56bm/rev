using MediatR;

namespace application.Servicios.Queries.GetServicioById;

public class GetServicioByIdQuery:IRequest<ServicioDto>
{
    public int id { get; set; }

    public GetServicioByIdQuery(int id)
    {
        this.id = id;
    }
    
}
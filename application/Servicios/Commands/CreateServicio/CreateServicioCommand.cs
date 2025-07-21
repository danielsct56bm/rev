using MediatR;

namespace application.Servicios.Commands.CreateServicio;

public class CreateServicioCommand: IRequest<Unit>
{
    public int idCliente { get; set; }
    public string servicio { get; set; }
    public DateTime? fechaRenovacion { get; set; }
    public decimal monto { get; set; }
    
}
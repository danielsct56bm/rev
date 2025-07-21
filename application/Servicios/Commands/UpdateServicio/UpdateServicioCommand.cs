using MediatR;

namespace application.Servicios.Commands.UpdateServicio;

public class UpdateServicioCommand: IRequest<Unit>
{
    public int id { get; set; }
    public int? idCliente { get; set; }
    public string? servicio { get; set; }
    public DateTime? fechaRenovacion { get; set; }
    public decimal? monto { get; set; }
}
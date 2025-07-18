using MediatR;

namespace application.Clientes.Commands.UpdateCliente;

public class UpdateClienteCommand:IRequest<Unit>
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public string? correo { get; set; }
}
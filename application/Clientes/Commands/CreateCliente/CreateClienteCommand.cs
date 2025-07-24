using MediatR;

namespace application.Clientes.Commands.CreateCliente;

public class CreateClienteCommand: IRequest<Unit>
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
}
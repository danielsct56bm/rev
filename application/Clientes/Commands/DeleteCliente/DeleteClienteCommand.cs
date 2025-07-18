using MediatR;

namespace application.Clientes.Commands.DeleteCliente;

public class DeleteClienteCommand: IRequest<Unit>
{
    public int id { get; set; }

    public DeleteClienteCommand(int id)
    {
        this.id = id;
    }
}
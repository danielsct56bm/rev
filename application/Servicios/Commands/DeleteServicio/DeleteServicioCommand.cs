using MediatR;

namespace application.Servicios.Commands.DeleteServicio;

public class DeleteServicioCommand: IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteServicioCommand(int id)
    {
        this.Id = id;
    }
}
using domain.Interfaces;

namespace application.Interfaces;

public interface IUnitOfWork
{
    IClienteRepository Clientes { get; }
    IServicioRepository Servicios { get; }
    ITicketRepository Tickets { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
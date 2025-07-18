using domain.Interfaces;

namespace application.common.Interfaces;

public interface IUnitOfWork
{
    IClienteRepository Clientes { get; }
    IServicioRepository Servicios { get; }
    ITicketRepository Tickets { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
using application.Interfaces;
using domain.Interfaces;
using infrastructure.Data.EF;

namespace infrastructure.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public IClienteRepository Clientes { get; }
    public IServicioRepository Servicios { get; }
    public ITicketRepository Tickets { get; }

    public UnitOfWork(ApplicationDbContext context, IClienteRepository clientes, IServicioRepository servicios, ITicketRepository tickets)
    {
        _context = context;
        Clientes = clientes;
        Servicios = servicios;
        Tickets = tickets;
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
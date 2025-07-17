using domain.Entities;
using domain.Interfaces;
using infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class TicketRepository: ITicketRepository
{
    public readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<tickets>> GetTicketsAsync()
    {
        var results = await _context.tickets
            .FromSqlInterpolated($"CALL ObtenerTickets()")
            .AsNoTracking()
            .ToListAsync();
        return results;
    }

    public async Task<tickets> GetTicketByIdAsync(int id)
    {
        var result = await _context.tickets
            .FromSqlInterpolated($"CALL ObtenerTicketPorId({id})")
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task<tickets> GetTicketByClientIdAsync(int clientId)
    {
        var result = await _context.tickets
            .FromSqlInterpolated($"CALL ObtenerTicketPorClienteId({clientId})")
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task<tickets> GetTicketByServiceIdAsync(int serviceId)
    {
        var result = await _context.tickets
            .FromSqlInterpolated($"CALL ObtenerTicketPorServicioId({serviceId})")
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task AddTicketAsync(tickets ticket)
    {
        await _context.Database
            .ExecuteSqlAsync(
                $"CALL InsertarTicket({ticket.idCliente},{ticket.ticket},{ticket.asunto},{ticket.status},{ticket.idServicio},{ticket.fechaFin},{ticket.statusFinal})");
    }

    public async Task UpdateTicketAsync(tickets ticket)
    {
        await _context.Database
            .ExecuteSqlAsync(
                $"CALL ActualizarTicket({ticket.id},{ticket.idCliente},{ticket.ticket},{ticket.asunto},{ticket.status},{ticket.idServicio},{ticket.fechaFin},{ticket.statusFinal})");
    }

    public async Task DeleteTicketAsync(int id)
    {
        await _context.Database
            .ExecuteSqlAsync($"CALL EliminarTicket({id})");
    }
}
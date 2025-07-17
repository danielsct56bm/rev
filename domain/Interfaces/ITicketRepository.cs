using domain.Entities;

namespace domain.Interfaces;

public interface ITicketRepository
{
    Task<IEnumerable<tickets>> GetTicketsAsync();
    Task<tickets> GetTicketByIdAsync(int id);
    Task<tickets> GetTicketByClientIdAsync(int clientId);
    Task<tickets> GetTicketByServiceIdAsync(int serviceId);
    Task AddTicketAsync(tickets ticket);
    Task UpdateTicketAsync(tickets ticket);
    Task DeleteTicketAsync(int id);
}
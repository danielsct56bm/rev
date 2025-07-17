using domain.Entities;

namespace domain.Interfaces;

public interface IServicioRepository
{
    Task<IEnumerable<servicios>> GetAllAsync();
    Task<servicios> GetByIdAsync(int id);
    Task<servicios> GetByClientIdAsync(int clientId);
    Task AddAsync(servicios servicios);
    Task UpdateAsync(servicios servicios);
    Task DeleteAsync(int id);
}
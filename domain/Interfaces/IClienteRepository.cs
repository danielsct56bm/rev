using domain.Entities;

namespace domain.Interfaces;

public interface IClienteRepository
{
    Task<IReadOnlyCollection<clientes>> ListAsync();
    Task<clientes> GetByIdAsync(int id);
    Task AddAsync(clientes cliente);
    Task UpdateAsync(clientes cliente);
    Task DeleteAsync(int id);
}
using domain.Entities;
using domain.Interfaces;
using infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class ClienteRepository: IClienteRepository
{
    public readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyCollection<clientes>> ListAsync()
    {
        var results = await _context.clientes
            .FromSqlInterpolated($"CALL ObtenerClientes()")
            .AsNoTracking()
            .ToListAsync();
        return results;
    }

    public async Task<clientes> GetByIdAsync(int id)
    {
        var result = await _context.clientes
            .FromSqlInterpolated($"CALL ObtenerClientePorId({id})")
            .AsNoTracking()
            .ToListAsync();
        
        return result.FirstOrDefault();
    }

    public async Task AddAsync(clientes cliente)
    {
        await _context.Database.ExecuteSqlAsync($"CALL InsertarCliente({cliente.nombre},{cliente.correo})");
    }

    public async Task UpdateAsync(clientes cliente)
    {
        await _context.Database.ExecuteSqlAsync($"CALL ActualizarClientePorId({cliente.id}, '{cliente.nombre}', '{cliente.correo}')");
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Database.ExecuteSqlAsync($"CALL EliminarCliente({id})");
    }
}
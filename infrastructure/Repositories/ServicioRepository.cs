using domain.Entities;
using domain.Interfaces;
using infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class ServicioRepository: IServicioRepository
{
    public readonly ApplicationDbContext _context;

    public ServicioRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<servicios>> GetAllAsync()
    {
        var results = await _context.servicios
            .FromSqlInterpolated($"CALL ObtenerServicios()")
            .AsNoTracking()
            .ToListAsync();
        return results;
    }

    public async Task<servicios> GetByIdAsync(int id)
    {
        var result = await _context.servicios
            .FromSqlInterpolated($"CALL ObtenerServicioPorId({id})")
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task<servicios> GetByClientIdAsync(int clientId)
    {
        var result = await _context.servicios
            .FromSqlInterpolated($"CALL ObtenerServicioPorClienteId({clientId})")
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task AddAsync(servicios servicios)
    {
        await _context.Database
            .ExecuteSqlAsync($"CALL InsertarServicio({servicios.idCliente},{servicios.servicio},{servicios.fechaRenovacion},{servicios.monto})");
    }

    public async Task UpdateAsync(servicios servicios)
    {
        await _context.Database
            .ExecuteSqlAsync($"CALL ActualizarServicio({servicios.id},{servicios.idCliente},{servicios.servicio},{servicios.fechaRenovacion},{servicios.monto})");
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Database.ExecuteSqlAsync($"CALL EliminarServicio({id})");
    }
}
using application.Interfaces;
using domain.Interfaces;
using infrastructure.Data.EF;
using infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MYSQL_CONNECTION_STRING");
        
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IServicioRepository, ServicioRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
        return services;
    }
}
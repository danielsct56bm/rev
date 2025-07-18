using System.ComponentModel.DataAnnotations;
using application.Clientes.Commands.CreateCliente;
using application.common.Behavor;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateClienteCommand).Assembly));
        
        services.AddValidatorsFromAssembly(typeof(CreateClienteValidator).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    } 
}
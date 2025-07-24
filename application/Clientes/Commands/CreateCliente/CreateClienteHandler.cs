﻿using application.common.Interfaces;
using domain.Entities;
using domain.Interfaces;
using MediatR;

namespace application.Clientes.Commands.CreateCliente;

public class CreateClienteHandler: IRequestHandler<CreateClienteCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new clientes
        {
            nombre = request.Nombre,
            correo = request.Correo
        };
        
        await _unitOfWork.Clientes.AddAsync(cliente);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
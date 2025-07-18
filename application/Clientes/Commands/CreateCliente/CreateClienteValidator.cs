using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace application.Clientes.Commands.CreateCliente;

public class CreateClienteValidator: AbstractValidator<CreateClienteCommand>
{
    public CreateClienteValidator()
    {
        RuleFor(x=>x.Nombre)
            .NotEmpty().WithMessage("nombre es requerido")
            .MaximumLength(64);
        
        RuleFor(x => x.Correo)
            .NotEmpty().WithMessage("correo es requerido")
            .EmailAddress().WithMessage("Debe ser un correo válido")
            .MaximumLength(32);
    }
}
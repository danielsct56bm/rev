using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace application.Clientes.Commands.CreateCliente;

public class CreateClienteValidator: AbstractValidator<CreateClienteCommand>
{
    public CreateClienteValidator()
    {
        RuleFor(x=>x.Nombre)
            .NotEmpty().NotNull().WithMessage("nombre es requerido")
            .MaximumLength(64);
        
        RuleFor(x => x.Correo)
            .NotEmpty().NotNull().WithMessage("correo es requerido")
            .EmailAddress().WithMessage("Debe ser un correo válido")
            .MaximumLength(32);
    }
}
using FluentValidation;

namespace application.Clientes.Commands.UpdateCliente;

public class UpdateClienteValidator: AbstractValidator<UpdateClienteCommand>
{
    public UpdateClienteValidator()
    {
        RuleFor(x=>x.id)
            .NotEmpty().WithMessage("El Id es requerido")
            .GreaterThan(0).WithMessage("El Id debe ser mayor a 0");

        RuleFor(x => x.nombre)
            .MaximumLength(64);
        
        RuleFor(x => x.correo)
            .MaximumLength(32);
    }
}
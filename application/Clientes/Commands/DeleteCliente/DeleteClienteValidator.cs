using FluentValidation;

namespace application.Clientes.Commands.DeleteCliente;

public class DeleteClienteValidator: AbstractValidator<DeleteClienteCommand>
{
    public DeleteClienteValidator()
    {
        RuleFor(x => x.id)
            .NotNull().WithMessage("Ingrese el Id")
            .GreaterThan(0).WithMessage("Ingrese un Id mayor a 0");
    }
}
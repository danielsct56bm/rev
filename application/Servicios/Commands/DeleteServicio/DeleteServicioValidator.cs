using FluentValidation;

namespace application.Servicios.Commands.DeleteServicio;

public class DeleteServicioValidator: AbstractValidator<DeleteServicioCommand>
{
    public DeleteServicioValidator()
    {
        RuleFor(servicio => servicio.Id)
            .NotNull().NotEmpty().WithMessage("id es obligatorio")
            .GreaterThan(0).WithMessage("Ingrese un Id mayor que 0");
    }
    
}
using FluentValidation;

namespace application.Servicios.Commands.UpdateServicio;

public class UpdateServicioValidator: AbstractValidator<UpdateServicio.UpdateServicioCommand>
{
    public UpdateServicioValidator()
    {
        RuleFor(x => x.id)
            .NotNull().NotEmpty().WithMessage("id es obligatorio")
            .GreaterThan(0).WithMessage("id debe ser mayor 0");
        
        RuleFor(x => x.servicio)
            .MaximumLength(32).WithMessage("");
        
        RuleFor(x => x.idCliente)
            .GreaterThan(0).WithMessage("idCliente es obligatorio");
        
        RuleFor(x => x.fechaRenovacion)
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("fechaRenovacion debe ser posterior al dia de hoy");
        
        RuleFor(x => x.monto)
            .GreaterThanOrEqualTo(0).WithMessage("monto debe ser mayor o igual a 0");
    }
}
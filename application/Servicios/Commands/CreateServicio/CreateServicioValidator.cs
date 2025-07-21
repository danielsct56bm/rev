using FluentValidation;

namespace application.Servicios.Commands.CreateServicio;

public class CreateServicioValidator: AbstractValidator<CreateServicioCommand>
{
    public CreateServicioValidator()
    {
        RuleFor(x => x.idCliente)
            .NotNull().NotEmpty().WithMessage("clienete requerido")
            .GreaterThan(0).WithMessage("id del cliente deve ser mayor que 0");
        
        RuleFor(x => x.servicio)
            .NotNull().NotEmpty().WithMessage("servicio deve ser informado")
            .MaximumLength(32).WithMessage("servicio no debe exceder de 32 caracteres");
        
        RuleFor(x => x.fechaRenovacion)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("fecha renovacion deve ser porlomenos hoy");
        
        RuleFor(x => x.monto)
            .NotNull().NotEmpty().WithMessage("monto deve ser informado")
            .GreaterThan(0).WithMessage("monto deve ser mayor que 0");
    }
}
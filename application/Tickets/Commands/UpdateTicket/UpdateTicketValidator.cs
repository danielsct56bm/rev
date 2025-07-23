using FluentValidation;

namespace application.Tickets.Commands.UpdateTicket;

public class UpdateTicketValidator : AbstractValidator<UpdateTicketCommand>
{
    public UpdateTicketValidator()
    {
        RuleFor(x => x.id)
            .NotNull().NotEmpty().WithMessage("El id es obligatorio")
            .GreaterThan(0).WithMessage("El ID del ticket debe ser válido");

        RuleFor(x => x.idCliente)
            .NotNull().WithMessage("El cliente es obligatorio");

        RuleFor(x => x.ticket)
            .NotEmpty().WithMessage("El código del ticket es obligatorio");

        RuleFor(x => x.idServicio)
            .NotNull().WithMessage("El servicio es obligatorio");

        RuleFor(x => x.fechaInicio)
            .NotNull().WithMessage("La fecha de inicio es obligatoria");

        RuleFor(x => x.fechaFin)
            .Must((command, fechaFin) =>
            {
                if (command.fechaInicio == null || fechaFin == null)
                    return true;

                return (fechaFin - command.fechaInicio)?.TotalDays <= 30;
            })
            .WithMessage("La fecha final no puede superar los 30 días desde la fecha de inicio");
    }
}
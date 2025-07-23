using FluentValidation;

namespace application.Tickets.Commands.CreateTicket;

public class CreateTicketValidator: AbstractValidator<CreateTicketCommand>
{
    public CreateTicketValidator()
    {
        RuleFor(x => x.idCliente)
            .NotNull().WithMessage("El cliente es obligatorio");

        RuleFor(x => x.ticket)
            .NotEmpty().WithMessage("El código del ticket no puede estar vacío");

        RuleFor(x => x.idServicio)
            .NotNull().WithMessage("El servicio es obligatorio");

        RuleFor(x => x.fechaInicio)
            .NotNull().WithMessage("La fecha de inicio es obligatoria");

        RuleFor(x => x.fechaFin)
            .Must((command, fechaFin) =>
            {
                if (command.fechaInicio == null || fechaFin == null)
                    return true; // No se valida si alguno es null

                return (fechaFin - command.fechaInicio)?.TotalDays <= 30;
            })
            .WithMessage("La fecha final no puede ser mayor a 30 días desde la fecha de inicio");
    }
}
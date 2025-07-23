using FluentValidation;

namespace application.Tickets.Commands.DeleteTicket;

public class DeleteTicketValidator:AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketValidator()
    {
        RuleFor(x => x.id).NotNull().NotEmpty().WithMessage("id es obligatorio")
            .GreaterThan(0).WithMessage("id debe ser mayor que 0");
    }
    
}
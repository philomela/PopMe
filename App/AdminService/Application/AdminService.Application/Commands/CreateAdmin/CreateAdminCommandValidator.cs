using FluentValidation;

namespace AdminService.Application.Commands.CreateAdmin;

public class CreateAdminCommandValidator : AbstractValidator<CreateAdminCommand>
{
    public CreateAdminCommandValidator()
    {
        // RuleFor(command => command.CreateDate)
        //     .Must(x => x.HasValue ? x.Value >= DateTime.Now : false)
        //     .WithMessage("DateTime in CreateTransaction not valid");
    }
}

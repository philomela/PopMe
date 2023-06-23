using MediatR;

namespace PresenterService.Application.Commands.UpdatePresenter;

public record UpdatePresenterCommand : IRequest<Guid>
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? NameReceiver { get; init; }

    public string? PhoneNumber { get; init; }

    public string? PhoneNumberReceiver { get; init; }

    public DateTime? SurpriseDate { get; init; }
}

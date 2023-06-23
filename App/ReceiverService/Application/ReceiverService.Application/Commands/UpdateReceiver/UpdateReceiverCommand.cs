using MediatR;

namespace ReceiverService.Application.Commands.UpdateReceiver;

public record UpdateReceiverCommand : IRequest<Unit>
{
    public Guid UniqKey { get; init; }
    public string? Name { get; init; }

    public string? PhoneNumber { get; init; }

    public DateTime? SurpriseDate { get; init; }
}

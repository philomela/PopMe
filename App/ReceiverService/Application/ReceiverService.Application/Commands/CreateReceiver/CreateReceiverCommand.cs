using MediatR;

namespace ReceiverService.Application.Commands.CreateReceiver;

public record CreateReceiverCommand : IRequest<Unit>
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public Guid UniqKey { get; init; } = Guid.NewGuid();
}

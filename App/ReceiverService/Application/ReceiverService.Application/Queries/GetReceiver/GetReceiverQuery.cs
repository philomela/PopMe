using MediatR;

namespace ReceiverService.Application.Queries.GetReceiver;

public record GetReceiverQuery : IRequest<ReceiverVm>
{
    public Guid Id { get; init; }
}

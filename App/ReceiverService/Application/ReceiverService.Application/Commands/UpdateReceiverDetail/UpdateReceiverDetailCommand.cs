using MediatR;

namespace ReceiverService.Application.Commands.UpdateReceiverDetail;

public record UpdateReceiverDetailCommand : IRequest<Guid>
{
    public Guid UniqKey { get; init; }
    public string? TextCongratulations { get; init; }

    public Guid VideoId { get; init; }
}

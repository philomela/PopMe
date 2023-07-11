using MediatR;

namespace ReceiverService.Application.Commands.UpdateReceiverDetail;

public record UpdateReceiverDetailCommand : IRequest<Unit>
{
    public Guid UniqKey { get; init; }
    public string? TextCongratulations { get; init; }

    public string VideoId { get; init; }
}

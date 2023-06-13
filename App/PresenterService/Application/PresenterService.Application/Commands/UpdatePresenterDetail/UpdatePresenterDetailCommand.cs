using MediatR;

namespace PresenterService.Application.Commands.UpdatePresenterDetail;

public record UpdatePresenterDetailCommand : IRequest<Guid>
{
    public Guid Id { get; init; }

    public string? TextCongratulations { get; init; }

    public Guid VideoId { get; init; }
}

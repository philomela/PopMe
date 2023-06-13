using MediatR;

namespace PresenterService.Application.Commands.CreatePresenter;

public record CreatePresenterCommand : IRequest<Unit>
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public Guid UniqKey { get; init; } = Guid.NewGuid();

}

using MediatR;

namespace PresenterService.Application.Queries.GetPresenter;

public record GetPresenterQuery : IRequest<PresenterVm>
{
    public Guid Id { get; init; }
}

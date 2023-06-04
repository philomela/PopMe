using MediatR;
using PresenterService.Domain.Core;

namespace PresenterService.Application.Commands.CreatePresenter
{
    public record CreatePresenterCommand : IRequest<Unit>
    {
        public Guid Id { get; init; } = Guid.NewGuid();

    }
}

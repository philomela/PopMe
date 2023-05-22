using MediatR;

namespace PresenterService.Application.Commands.UpdatePresenter;

internal class UpdatePresenterCommandHandler : IRequestHandler<UpdatePresenterCommand, Unit>
{
    public async Task<Unit> Handle(UpdatePresenterCommand request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => Unit.Value);
    }
}

using MediatR;

namespace PresenterService.Application.Commands.UpdatePresenter;

public record UpdatePresenterCommand : IRequest<Unit>
{

}

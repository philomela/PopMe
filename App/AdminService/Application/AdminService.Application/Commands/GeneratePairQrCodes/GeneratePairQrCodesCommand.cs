using MediatR;

namespace AdminService.Application.Commands.GeneratePairQrCodes;

public record GeneratePairQrCodesCommand : IRequest<Unit>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid PresenterData { get; set; } = Guid.NewGuid();

    public Guid ReceiverData { get; set; } = Guid.NewGuid();
}

using MediatR;

namespace AdminService.Application.Commands.GeneratePairQrCodes;

public record GeneratePairQrCodesCommand : IRequest<Unit>
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public Guid PresenterData { get; init; } = Guid.NewGuid();

    public Guid ReceiverData { get; init; } = Guid.NewGuid();

    public Guid UniqKey { get; init; } = Guid.NewGuid();
}

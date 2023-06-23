using MediatR;

namespace AdminService.Application.Commands.GeneratePairQrCodes;

public record GeneratePairQrCodesCommand : IRequest<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTime CreateDate { get; init; } = DateTime.Now;

    public Guid PresenterData { get; init; } = Guid.NewGuid();

    public Guid ReceiverData { get; init; } = Guid.NewGuid();

    public Guid UniqKey { get; init; } = Guid.NewGuid();
}

namespace AdminService.Domain.Core;

public record PairQrCodes
{
    public Guid Id { get; init; }

    public string PresenterDataBase64 { get; init; }

    public string ReceiverDataBase64 { get; init; }
}

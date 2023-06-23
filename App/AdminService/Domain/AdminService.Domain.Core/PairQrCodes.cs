namespace AdminService.Domain.Core;

public record PairQrCodes
{
    public Guid Id { get; set; }

    public DateTime CreateDate { get; set; }

    public string PresenterDataBase64 { get; set; }

    public string ReceiverDataBase64 { get; set; }

    public Guid UniqKey { get; set; }
}

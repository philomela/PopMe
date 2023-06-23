namespace AdminService.Application.Queries.GetInfoPairsQrCodes;

public record InfoPairsQrCodesDto
{
    public long CountPairsQrCodes { get; set; }

    public DateTime LastDateTimeCreated { get; set; }
}

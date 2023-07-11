namespace EventBus.Messages;

public record UpdatedPresenterDetailEvent // : IntegrationBaseEvent
{
    public Guid UniqKey { get; init; }

    public string? TextCongratulations { get; init; }

    public string VideoId { get; init; }
}

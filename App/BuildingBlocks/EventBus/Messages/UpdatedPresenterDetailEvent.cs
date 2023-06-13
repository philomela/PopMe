namespace EventBus.Messages;

public record UpdatedPresenterDetailEvent // : IntegrationBaseEvent
{
    public Guid UniqKey { get; init; }

    public string? TextCongratulations { get; init; }

    public Guid VideoId { get; init; }
}

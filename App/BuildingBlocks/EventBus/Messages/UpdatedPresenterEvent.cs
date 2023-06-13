namespace EventBus.Messages;

public record UpdatedPresenterEvent
{
    public Guid UniqKey { get; init; }
    public string? NameReceiver { get; init; }

    public string? PhoneNumberReceiver { get; init; }

    public DateTime? BirthDateReceiver { get; init; }
}
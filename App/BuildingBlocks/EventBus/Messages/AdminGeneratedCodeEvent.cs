namespace EventBus.Messages;

public record AdminGeneratedCodeEvent
{
    public Guid Id { get; init; }

    public Guid PresenterData { get; init; }

    public Guid ReceiverData { get; init; }
}

namespace ReceiverService.Domain.Core;

public record Meme
{
    public Guid Id { get; init; }

    public string? TextСongratulations { get; init; }

    public Guid VideoId { get; init; }
}

namespace ReceiverService.Domain.Core;

public record Meme
{
    public Guid Id { get; set; }

    public Receiver? Receiver { get; set; }

    public string? TextСongratulations { get; set; }

    public string VideoId { get; set; }
}

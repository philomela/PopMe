namespace ReceiverService.Domain.Core;

public record Receiver
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? SurpriseDate { get; set; }

    public Meme? Meme { get; set; }

    public Guid UniqKey { get; set; }
}

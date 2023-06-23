namespace PresenterService.Domain.Core;

public record Meme
{
    public Guid Id { get; set; }

    public Presenter? Presenter { get; set; }

    public string? TextСongratulations { get; set; }

    public Guid VideoId { get; set; } 
}

namespace PresenterService.Domain.Core;

public record Presenter
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    //public Meme Meme { get; init; }
}

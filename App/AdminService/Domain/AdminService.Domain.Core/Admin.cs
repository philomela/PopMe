namespace AdminService.Domain.Core;

public record Admin
{
    public Guid Id { get; init; }

    public string NickName { get; init; }

    public string Name { get; init; }

    public string LastName { get; init; }

    public string MiddleName { get; init; }

    public string Email { get; init; }
}
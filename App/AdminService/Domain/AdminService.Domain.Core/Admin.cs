namespace AdminService.Domain.Core;

public record Admin
{
    public Guid Id { get; set; }

    public string NickName { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string Email { get; set; }
}
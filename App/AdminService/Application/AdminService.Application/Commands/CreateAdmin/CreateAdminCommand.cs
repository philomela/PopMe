using MediatR;

namespace AdminService.Application.Commands.CreateAdmin
{
    public record CreateAdminCommand : IRequest<Guid>
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string LastName { get; init; }

        public string Name { get; init; }

        public string MiddleName { get; init; }

        public string Email { get; init; }
    }
}
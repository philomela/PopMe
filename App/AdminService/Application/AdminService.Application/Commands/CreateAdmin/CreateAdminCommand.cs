using MediatR;

namespace AdminService.Application.Commands.CreateAdmin
{
    public record CreateAdminCommand : IRequest<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string LastName { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }
    }
}
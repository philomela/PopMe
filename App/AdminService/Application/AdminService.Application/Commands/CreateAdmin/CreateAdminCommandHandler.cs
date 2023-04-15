using AdminService.Domain.Core;
using AdminService.Domain.Interfaces;
using MediatR;

namespace AdminService.Application.Commands.CreateAdmin;

public record CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Guid>
{
    private readonly IAdminDbContext _adminDbContext;

    public CreateAdminCommandHandler(IAdminDbContext adminDbContext) 
        => _adminDbContext = adminDbContext; 
    public async Task<Guid> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = new Admin()
        {
            Id = request.Id,
            LastName = request.LastName,
            Name = request.Name,
            MiddleName = request.MiddleName,
            Email = request.Email,
        };

        await _adminDbContext.Admins.AddAsync(admin);

        return admin.Id;
    }
}

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
        await _adminDbContext.Admins.AddAsync(new ()
        {
            Id = request.Id,
            LastName = request.LastName,
            Name = request.Name,
            MiddleName = request.MiddleName,
            Email = request.Email,
        });
        await _adminDbContext.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}

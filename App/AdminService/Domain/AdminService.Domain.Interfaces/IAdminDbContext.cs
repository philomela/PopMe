using AdminService.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace AdminService.Domain.Interfaces;

public interface IAdminDbContext
{
    public DbSet<Admin> Admins { get; set; }

    public DbSet<PairQrCodes> PairsQrCodes { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
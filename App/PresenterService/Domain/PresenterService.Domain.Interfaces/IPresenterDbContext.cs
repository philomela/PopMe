using AdminService.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace PresenterService.Domain.Interfaces;

public interface IPresenterDbContext
{
    public DbSet<Admin> Admins { get; set; }

    public DbSet<PairQrCodes> PresenterLinks { get; set; }

    public DbSet<ReceiverQrCode> ReceiverLinks { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
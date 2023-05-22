using AdminService.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace PresenterService.Domain.Interfaces;

public interface IPresenterDbContext
{
    public DbSet<PairQrCodes> QrCodes { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
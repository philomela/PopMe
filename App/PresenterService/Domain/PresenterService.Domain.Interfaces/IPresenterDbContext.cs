using Microsoft.EntityFrameworkCore;
using PresenterService.Domain.Core;

namespace PresenterService.Domain.Interfaces;

public interface IPresenterDbContext
{
    public DbSet<Presenter> Presenters { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
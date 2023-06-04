using Microsoft.EntityFrameworkCore;
using PresenterService.Domain.Core;
using PresenterService.Domain.Interfaces;
using PresenterService.Infrastructure.EntityTypeConfigurations;

namespace PresenterService.Infrastructure;

public class PresenterDbContext : DbContext, IPresenterDbContext
{
    public DbSet<Presenter> Presenters { get; set; }
    public PresenterDbContext(DbContextOptions<PresenterDbContext> options) 
        : base(options) 
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PresenterConfiguration());
        //modelBuilder.ApplyConfiguration(new MemeConfiguration());
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
using Microsoft.EntityFrameworkCore;
using ReceiverService.Domain.Core;
using ReceiverService.Domain.Interfaces;
using ReceiverService.Infrastructure.EntityTypeConfigurations;

namespace ReceiverService.Infrastructure;

public class ReceiverDbContext : DbContext, IReceiverDbContext
{
    public DbSet<Receiver> Receivers { get; set; }
    public ReceiverDbContext(DbContextOptions<ReceiverDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReceiverConfiguration());
        modelBuilder.ApplyConfiguration(new MemeConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
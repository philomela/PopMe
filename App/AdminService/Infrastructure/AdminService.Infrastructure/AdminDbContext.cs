using AdminService.Domain.Core;
using AdminService.Domain.Interfaces;
using AdminService.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AdminService.Infrastructure;

public class AdminDbContext : DbContext, IAdminDbContext
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<PairQrCodes> PairsQrCodes { get; set; }

    public AdminDbContext(DbContextOptions<AdminDbContext> options) :
        base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new PairQrCodesConfiguration());
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
       return  await base.SaveChangesAsync(cancellationToken);
    }
}
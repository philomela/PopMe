using Microsoft.EntityFrameworkCore;
using ReceiverService.Domain.Core;

namespace ReceiverService.Domain.Interfaces;

public interface IReceiverDbContext
{
    public DbSet<Receiver> Receivers { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
using IdentityService.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data
{
    public interface IAuthDbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

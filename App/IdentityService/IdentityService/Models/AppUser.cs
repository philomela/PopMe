using Microsoft.AspNetCore.Identity;

namespace IdentityService.Models;

public class AppUser : IdentityUser
{
    public Guid UniqKey { get; set; }
}

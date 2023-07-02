using Microsoft.AspNetCore.Identity;

namespace IdentityService.Models;

public class AppUser : IdentityUser
{
    public Guid UniqId { get; set; }
}

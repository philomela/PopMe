using Microsoft.AspNetCore.Identity;

namespace IdentityService.Services;

internal interface IJwtGenerator<in T> where T : IdentityUser
{
    public string GenerateJwtToken(T user);
}

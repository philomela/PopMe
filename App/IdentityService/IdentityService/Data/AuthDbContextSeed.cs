using IdentityService.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Data;

public class AuthDbContextSeed
{
    public static async Task SeedDataAsync(AuthDbContext context, UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var users = new List<AppUser>
                            {
                                new AppUser
                                    {
                                        UserName = "TestUserFirst",
                                        Email = "testuserfirst@test.com"
                                    },

                                new AppUser
                                    {
                                        UserName = "TestUserSecond",
                                        Email = "testusersecond@test.com"
                                    }
                            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "qazwsX123@");
            }
        }
    }
}

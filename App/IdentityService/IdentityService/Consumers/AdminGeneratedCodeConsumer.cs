using EventBus.Messages;
using IdentityService.Models;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.API.EventBusConsumer;

public class AdminGeneratedCodeConsumer : IConsumer<AdminGeneratedCodeEvent>
{
    private readonly UserManager<AppUser> _userManager;

    public AdminGeneratedCodeConsumer(UserManager<AppUser> userManager) => _userManager = userManager;
    public async Task Consume(ConsumeContext<AdminGeneratedCodeEvent> context)
    {
        var result = await _userManager.CreateAsync(new AppUser()
        {
            Id = context.Message.PresenterData.ToString().ToUpper(),
            UniqKey = context.Message.UniqKey,
            UserName = context.Message.PresenterData.ToString().ToUpper(),
            PasswordHash = context.Message.PresenterData.ToString().ToUpper()
        });

        Console.WriteLine($"{context.Message.Id}"); //Added loger
    }
}

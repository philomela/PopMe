using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JwtAuth;

public sealed class UserIdRequirement : IAuthorizationRequirement { }

public sealed class UserIdHandler : AuthorizationHandler<UserIdRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserIdHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   UserIdRequirement requirement)
    {
        if (context.User.Identity?.IsAuthenticated is bool IsAuthenticated && !IsAuthenticated)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var userId = context.User.FindFirstValue("Id");

        if (userId == null)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var requestedId = _httpContextAccessor?.HttpContext?.Request?.RouteValues["id"]?.ToString();

        if (userId != requestedId)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}

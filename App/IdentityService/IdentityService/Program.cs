using EventBus.Common;
using IdentityService.API.EventBusConsumer;
using IdentityService.Data;
using IdentityService.Models;
using IdentityService.Services;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddMassTransit(config =>
{

    config.AddConsumer<AdminGeneratedCodeConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.AdminCreatedIdentityQueue, c =>
        {
            c.ConfigureConsumer<AdminGeneratedCodeConsumer>(ctx);
        });
    });
});

builder.Services.AddScoped<AdminGeneratedCodeConsumer>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}

app.MapGet("/account/auth/{id}", async ([FromRoute] string id,
                                        [FromServices] UserManager<AppUser> userManager,
                                        [FromServices] IJwtGenerator<AppUser> jwtGenerator,
                                                       SignInManager<AppUser> signInManager) =>
{
    var isValid = Guid.TryParse(id, out Guid userId);
    if (!isValid) return Results.BadRequest();

    var user = await userManager.FindByIdAsync(userId.ToString());
    if (user == null)
        return Results.Unauthorized();

    var token = jwtGenerator.GenerateJwtToken(user);
    return Results.Ok(new {token});
}).WithName("Auth")
.WithOpenApi();

app.MapPost("/account/validate/{id}", async ([FromRoute] string id,
                                             [FromBody] string token) =>
{
    try
    {
        var isValid = Guid.TryParse(id, out Guid userId);
        if (!isValid) return Results.BadRequest();

        if (string.IsNullOrEmpty(token)) return Results.BadRequest();

        var tokenHandler = new JwtSecurityTokenHandler();

        var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                builder.Configuration["Secret"]
                ?? throw new Exception("Secret key was not found"))),
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = true,
            RequireExpirationTime = true
        }, out var validatedToken);
        
        var jwtToken = validatedToken as JwtSecurityToken;

        if (claimsPrincipal.Identity is ClaimsIdentity identity
        && identity.FindFirst("Id")?.Value != null
        && Guid.TryParse(identity.FindFirst("Id")?.Value, out var userClaimId))
        {
            return userClaimId == userId ? 
            Results.Ok(new { isValid = true }) : 
            Results.Unauthorized();
        }
        return Results.Unauthorized();
    }
    catch (SecurityTokenException)
    {
        return Results.Unauthorized();
    }
}).WithName("Validate")
.WithOpenApi();

app.MapGet("/", () => "Identity").WithName("NameService")
.WithOpenApi();

app.Run();

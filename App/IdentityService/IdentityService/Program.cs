using IdentityService.Data;
using IdentityService.Models;
using IdentityService.Services;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

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

app.MapGet("/account/auth/{id}", async ([FromRoute] Guid id,
                                        [FromServices] UserManager<AppUser> userManager,
                                        [FromServices] IJwtGenerator<AppUser> jwtGenerator,
                                                       SignInManager<AppUser> signInManager) =>
{
    var user = await userManager.FindByIdAsync(id.ToString());
    if (user == null)
        throw new Exception("Invalid login or password!");
    
    var token = jwtGenerator.GenerateJwtToken(user);

    return new { token };
});
app.MapGet("/", () => "Hello World!");

app.Run();

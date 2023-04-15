using AdminService.Application;
using AdminService.Infrastructure;
using EventBus.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAppication();

var app = builder.Build();


app.MapPost("/createAdmin", );

app.MapGet("/generateQrCode", async ([FromServices] IPublishEndpoint publishEndpoint) =>
{
    await publishEndpoint.Publish(new AdminGenerateCodeEvent()
    {
        Id = 1,
        Code = "Test",
    });

    return HttpStatusCode.Created;

});

app.Run();

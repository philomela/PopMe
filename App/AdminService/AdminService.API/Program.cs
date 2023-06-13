using AdminService.Application;
using AdminService.Application.Commands.CreateAdmin;
using AdminService.Application.Commands.GeneratePairQrCodes;
using AdminService.Application.Queries.GetPairQrCodes;
using AdminService.Infrastructure;
using EventBus.Messages;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.MapGet("/", () => "Admin");

app.MapPost("/createAdmin", async ([FromServices] IMediator mediator) =>
{
    await mediator.Send(new CreateAdminCommand());
});

app.MapGet("/generatePairQrCodes", async ([FromServices] IPublishEndpoint publishEndpoint, 
                                          [FromServices] IMediator mediator) =>
{
    var command = new GeneratePairQrCodesCommand();
    await mediator.Send(command);

    await publishEndpoint.Publish(new AdminGeneratedCodeEvent()
    {
        Id = command.Id,
        PresenterData = command.PresenterData,
        ReceiverData = command.ReceiverData,
        UniqKey = command.UniqKey
    });

    return await mediator.Send(new GetPairQrCodesQuery(command.Id));
});

app.Run();

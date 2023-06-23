using AdminService.Application;
using AdminService.Application.Commands.CreateAdmin;
using AdminService.Application.Commands.GeneratePairQrCodes;
using AdminService.Application.Queries.GetInfoPairsQrCodes;
using AdminService.Application.Queries.GetPairQrCodes;
using AdminService.Infrastructure;
using EventBus.Messages;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}


app.MapGet("/", () => "Admin");

app.MapPost("/createAdmin", async ([FromServices] IMediator mediator) =>
{
    await mediator.Send(new CreateAdminCommand());
})
.WithName("CreateAdmin")
.WithOpenApi();

app.MapPost("/generatePairQrCodes", async ([FromServices] IPublishEndpoint publishEndpoint, 
                                          [FromServices] IMediator mediator) =>
{
    var command = new GeneratePairQrCodesCommand();
    var result = await mediator.Send(command);

    await publishEndpoint.Publish(new AdminGeneratedCodeEvent()
    {
        Id = command.Id,
        PresenterData = command.PresenterData,
        ReceiverData = command.ReceiverData,
        UniqKey = command.UniqKey
    });
    return result;
})
.WithName("GeneratePairQrCodes")
.WithOpenApi();

app.MapGet("/getPairQrCodes/{id}", async ([FromRoute] Guid id,
                                          [FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetPairQrCodesQuery(id));
})
.WithName("GetPairQrCodes")
.WithOpenApi();

app.MapGet("/getInfoQrCodes", async ([FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetInfoPairsQrCodesQuery());
})
.WithName("GetInfoQrCodes")
.WithOpenApi();

app.Run();

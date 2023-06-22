using EventBus.Common;
using EventBus.Messages;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PresenterService.API.EventBusConsumer;
using PresenterService.Application;
using PresenterService.Application.Commands.UpdatePresenter;
using PresenterService.Application.Commands.UpdatePresenterDetail;
using PresenterService.Application.Queries.GetPresenter;
using PresenterService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//builder.UseKestrel().UseUrls("http://localhost:5001");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMassTransit(config =>
{

    config.AddConsumer<AdminGeneratedCodeConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.QrCodeDataPresenterQueue, c =>
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}

/// <summary>
/// Route Method / - get presenter name service.
/// </summary>
app.MapGet("/", () => "Presenter");

/// <summary>
/// Route GetPresenter - get presenter by Id.
/// </summary>
app.MapGet("/getPresenter/{id}", async ([FromRoute] Guid id,
                                   [FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetPresenterQuery()
    {
        Id = id,
    });
})
.WithName("GetPresenter")
.WithOpenApi();

/// <summary>
/// Route UpdatePresenter - update presenter by Id.
/// </summary>
app.MapPut("/updatePresenter/{id}", async ([FromRoute] Guid id,
                                           [FromBody] UpdatePresenterCommand command,
                                           [FromServices] IPublishEndpoint publishEndpoint,
                                           [FromServices] IMediator mediator) =>
{
    if (id != command.Id)
        return Results.BadRequest();
      
    var uniqKey = await mediator.Send(command);
    await publishEndpoint.Publish(new UpdatedPresenterEvent()
    {
        NameReceiver = command.NameReceiver,
        PhoneNumberReceiver = command.PhoneNumberReceiver,
        SurpriseDate = command.SurpriseDate,
        UniqKey = uniqKey
    }); 
    return Results.NoContent();
})
.WithName("UpdatePresenter")
.WithOpenApi();

/// <summary>
/// Route UpdatePresenterDetail - update presenter detail by Id.
/// </summary>
app.MapPut("/updatePresenterDetail/{id}", async ([FromRoute] Guid id,
                                                 [FromBody] UpdatePresenterDetailCommand command,
                                                 [FromServices] IPublishEndpoint publishEndpoint,
                                                 [FromServices] IMediator mediator) =>
{
    if (id != command.Id)
        return Results.BadRequest();

    var uniqKey = await mediator.Send(command);
    await publishEndpoint.Publish(new UpdatedPresenterDetailEvent()
    {
        TextCongratulations = command.TextCongratulations,
        VideoId = command.VideoId,
        UniqKey = uniqKey
    });
    return Results.NoContent();
})
.WithName("UpdatePresenterDetail")
.WithOpenApi();

app.Run();
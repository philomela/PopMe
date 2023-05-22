using EventBus.Common;
using EventBus.Messages;
using MassTransit;
using MassTransit.Mediator;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using PresenterService.API.EventBusConsumer;

var builder = WebApplication.CreateBuilder(args);

//builder.UseKestrel().UseUrls("http://localhost:5001");

builder.Services.AddMassTransit(config => {

    config.AddConsumer<AdminGeneratedCodeConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.QrCodeDataPresenterQueue, c => {
            c.ConfigureConsumer<AdminGeneratedCodeConsumer>(ctx);
        });
    });
});

var app = builder.Build();

app.MapGet("/", () => "Presenter");
//app.MapGet("/getPresenter", () => "Hello World!");
//app.MapGet("/createPresenter", () => "Hello World!");
app.MapGet("/updatePresenter", async([FromServices] IPublishEndpoint publishEndpoint) =>
{
    //var result = await mediator.Send(new UpdatePresenter())
    await publishEndpoint.Publish(new UpdatedPresenterEvent()
    {
        Id = Guid.NewGuid()
    });
});

app.Run();
using EventBus.Common;
using MassTransit;
using PresenterService.API.EventBusConsumer;

var builder = WebApplication.CreateBuilder(args);

//builder.UseKestrel().UseUrls("http://localhost:5001");

builder.Services.AddMassTransit(config => {

    config.AddConsumer<AdminGenerateCodeConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c => {
            c.ConfigureConsumer<AdminGenerateCodeConsumer>(ctx);
        });
    });
});

var app = builder.Build();

app.MapGet("/sendEventRabbitMq", () => "Hello World!");

app.Run();
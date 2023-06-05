using EventBus.Common;
using MassTransit;
using ReceiverService.API.EventBusConsumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(config => {

    config.AddConsumer<AdminGeneratedCodeConsumer>();
    config.AddConsumer<UpdatedPresenterConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.QrCodeDataReceiverQueue, c => {
            c.ConfigureConsumer<AdminGeneratedCodeConsumer>(ctx);
        });
        cfg.ReceiveEndpoint(EventBusConstants.UpdatePresenterReceiverQueue, c => {
            c.ConfigureConsumer<UpdatedPresenterConsumer>(ctx);
        });
    });
});


var app = builder.Build();

app.MapGet("/", () => "Receiver");

app.MapGet("/getReceiver", () => "Hello World!");

app.Run();

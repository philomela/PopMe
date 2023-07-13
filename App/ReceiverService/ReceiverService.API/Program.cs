using EventBus.Common;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReceiverService.API.EventBusConsumer;
using ReceiverService.Application;
using ReceiverService.Application.Queries.GetReceiver;
using ReceiverService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMassTransit(config => {

    config.AddConsumer<AdminGeneratedCodeConsumer>();
    config.AddConsumer<UpdatedPresenterConsumer>();
    config.AddConsumer<UpdatedPresenterDetailConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.AdminCreatedReceiverQueue, c => {
            c.ConfigureConsumer<AdminGeneratedCodeConsumer>(ctx);
        });
        cfg.ReceiveEndpoint(EventBusConstants.UpdatedPresenterQueue, c => {
            c.ConfigureConsumer<UpdatedPresenterConsumer>(ctx);
        });
        cfg.ReceiveEndpoint(EventBusConstants.UpdatedPresenterDetailQueue, c => {
            c.ConfigureConsumer<UpdatedPresenterDetailConsumer>(ctx);
        });
    });

    builder.Services.AddScoped<AdminGeneratedCodeConsumer>();
    builder.Services.AddScoped<UpdatedPresenterConsumer>();
    builder.Services.AddScoped<UpdatedPresenterDetailConsumer>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    });
});

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Receiver API V1");
        c.RoutePrefix = string.Empty;
    });
    app.UseCors("CorsPolicy");
}

app.MapGet("/", () => "Receiver");

/// <summary>
/// Route GetReceiver - get receiver by Id.
/// </summary>
app.MapGet("/getReceiver/{id}", async ([FromRoute] Guid id,
                                       [FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetReceiverQuery()
    {
        Id = id
    });
}).WithName("GetReceiver")
.WithOpenApi();

app.Run();

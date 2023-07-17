using EventBus.Common;
using EventBus.Messages;
using JwtAuth;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PresenterService.API.EventBusConsumer;
using PresenterService.Application;
using PresenterService.Application.Commands.UpdatePresenter;
using PresenterService.Application.Commands.UpdatePresenterDetail;
using PresenterService.Application.Queries.GetPresenter;
using PresenterService.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var secret = builder.Configuration["Secret"] ?? throw new Exception("Secret key was not found");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMassTransit(config =>
{

    config.AddConsumer<AdminGeneratedCodeConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.AdminCreatedPresenterQueue, c =>
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

builder.Services.AddPolicyAuthorization();

builder.Services.AddCustomAuthScheme(cfg =>
{
    cfg.RequireHttpsMetadata = true;
    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
            builder.Configuration["Secret"]
            ?? throw new Exception("Secret key was not found"))),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        RequireExpirationTime = true
    };
});

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Presenter API V1");
        c.RoutePrefix = string.Empty;
    });
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
    var queryResult = await mediator.Send(new GetPresenterQuery()
    {
        Id = id,
    });

    return queryResult is not null
    ? Results.Ok(queryResult)
    : Results.NoContent();
}).RequireAuthorization("UserIdPolicy")
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
}).RequireAuthorization("UserIdPolicy")
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
}).RequireAuthorization("UserIdPolicy")
.WithName("UpdatePresenterDetail")
.WithOpenApi();

app.Run();
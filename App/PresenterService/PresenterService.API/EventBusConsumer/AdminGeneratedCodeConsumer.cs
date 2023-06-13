using EventBus.Messages;
using MassTransit;
using MediatR;
using PresenterService.Application.Commands.CreatePresenter;

namespace PresenterService.API.EventBusConsumer;

public class AdminGeneratedCodeConsumer : IConsumer<AdminGeneratedCodeEvent>
{
    private readonly IMediator _mediator;

    public AdminGeneratedCodeConsumer(IMediator mediator) => _mediator = mediator;
    public async Task Consume(ConsumeContext<AdminGeneratedCodeEvent> context)
    {
        await _mediator.Send(new CreatePresenterCommand()
        {
            Id = context.Message.PresenterData,
            UniqKey = context.Message.UniqKey
        });

        Console.WriteLine($"{context.Message.Id}: {context.Message.PresenterData}"); //Added loger
    }
}

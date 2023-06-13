using EventBus.Messages;
using MassTransit;
using MediatR;
using ReceiverService.Application.Commands.CreateReceiver;

namespace ReceiverService.API.EventBusConsumer;

public class AdminGeneratedCodeConsumer : IConsumer<AdminGeneratedCodeEvent>
{
    private readonly IMediator _mediator;

    public AdminGeneratedCodeConsumer(IMediator mediator) => _mediator = mediator;
    
    public async Task Consume(ConsumeContext<AdminGeneratedCodeEvent> context)
    {
        await _mediator.Send(new CreateReceiverCommand()
        {
            Id = context.Message.ReceiverData,
            UniqKey = context.Message.UniqKey
        });

        Console.WriteLine($"{context.Message.Id}: {context.Message.ReceiverData}"); //Added loger
    }
}

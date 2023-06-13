using EventBus.Messages;
using MassTransit;
using MediatR;
using ReceiverService.Application.Commands.CreateReceiver;
using ReceiverService.Application.Commands.UpdateReceiver;

namespace ReceiverService.API.EventBusConsumer;

public class UpdatedPresenterConsumer : IConsumer<UpdatedPresenterEvent>
{
    private readonly IMediator _mediator;

    public UpdatedPresenterConsumer(IMediator mediator) => _mediator = mediator;
    
    public async Task Consume(ConsumeContext<UpdatedPresenterEvent> context)
    {
        await _mediator.Send(new UpdateReceiverCommand()
        {
            UniqKey = context.Message.UniqKey,
            Name = context.Message.NameReceiver,
            PhoneNumber = context.Message.PhoneNumberReceiver,
            BirthDate = context.Message.BirthDateReceiver,
        });

        Console.WriteLine($"{context.Message.UniqKey}"); //Added loger
    }
}

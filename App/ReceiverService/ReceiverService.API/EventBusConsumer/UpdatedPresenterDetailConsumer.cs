using EventBus.Messages;
using MassTransit;
using MediatR;
using ReceiverService.Application.Commands.UpdateReceiverDetail;

namespace ReceiverService.API.EventBusConsumer;

public class UpdatedPresenterDetailConsumer : IConsumer<UpdatedPresenterDetailEvent>
{
    private readonly IMediator _mediator;

    public UpdatedPresenterDetailConsumer(IMediator mediator) => _mediator = mediator;

    public async Task Consume(ConsumeContext<UpdatedPresenterDetailEvent> context)
    {
        await _mediator.Send(new UpdateReceiverDetailCommand()
        {
            UniqKey = context.Message.UniqKey,
            TextCongratulations = context.Message.TextCongratulations,
            VideoId = context.Message.VideoId,  
        });

        Console.WriteLine($"{context.Message.UniqKey}"); //Added loger
    }
}

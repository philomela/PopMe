using EventBus.Messages;
using MassTransit;

namespace PresenterService.API.EventBusConsumer;

public class AdminGenerateCodeConsumer : IConsumer<AdminGenerateCodeEvent>
{
    public async Task Consume(ConsumeContext<AdminGenerateCodeEvent> context)
    {
        Console.WriteLine($"{context.Message.Id}: {context.Message.Code}");
    }
}

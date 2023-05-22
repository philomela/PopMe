using EventBus.Messages;
using MassTransit;

namespace PresenterService.API.EventBusConsumer;

public class AdminGeneratedCodeConsumer : IConsumer<AdminGeneratedCodeEvent>
{
    public async Task Consume(ConsumeContext<AdminGeneratedCodeEvent> context)
    {
        Console.WriteLine($"{context.Message.Id}: {context.Message.PresenterData}");
    }
}

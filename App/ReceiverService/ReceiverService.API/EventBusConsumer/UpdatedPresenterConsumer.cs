﻿using EventBus.Messages;
using MassTransit;

namespace ReceiverService.API.EventBusConsumer;

public class UpdatedPresenterConsumer : IConsumer<UpdatedPresenterEvent>
{
    public async Task Consume(ConsumeContext<UpdatedPresenterEvent> context)
    {
        Console.WriteLine($"Consumer processed event presenter service {context.Message.Id}");
    }
}
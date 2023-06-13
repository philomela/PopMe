using MediatR;
using ReceiverService.Domain.Interfaces;

namespace ReceiverService.Application.Commands.CreateReceiver;

internal class CreateReceiverCommandHandler : IRequestHandler<CreateReceiverCommand, Unit>
{
    private readonly IReceiverDbContext _receiverDbContext;

    public CreateReceiverCommandHandler(IReceiverDbContext receiverdbContext)
        => _receiverDbContext = receiverdbContext;

    public async Task<Unit> Handle(CreateReceiverCommand request, CancellationToken cancellationToken)
    {
        await _receiverDbContext.Receivers.AddAsync(
            new()
            {
                Id = request.Id,
                UniqKey = request.UniqKey,
                Meme = new()
                {
                    Id = request.Id,
                }
            });

        await _receiverDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

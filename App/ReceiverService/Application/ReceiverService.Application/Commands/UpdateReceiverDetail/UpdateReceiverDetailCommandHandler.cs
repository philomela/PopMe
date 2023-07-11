using MediatR;
using Microsoft.EntityFrameworkCore;
using ReceiverService.Application.Commands.UpdateReceiver;
using ReceiverService.Domain.Interfaces;

namespace ReceiverService.Application.Commands.UpdateReceiverDetail;

internal class UpdateReceiverDetailCommandHandler : IRequestHandler<UpdateReceiverDetailCommand, Unit>
{
    private readonly IReceiverDbContext _receiverDbContext;

    public UpdateReceiverDetailCommandHandler(IReceiverDbContext receiverDbContext)
        => _receiverDbContext = receiverDbContext;
    public async Task<Unit> Handle(UpdateReceiverDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _receiverDbContext.Receivers
                                             .Include(r => r.Meme)
                                             .FirstOrDefaultAsync(r => r.UniqKey == request.UniqKey, cancellationToken);

        if (entity is null || entity.Meme is null)
        {
            throw new Exception("Не найдена сущность."); //NotFaundException
        }

        entity.Meme.TextСongratulations = request.TextCongratulations;
        entity.Meme.VideoId = request.VideoId;

        await _receiverDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

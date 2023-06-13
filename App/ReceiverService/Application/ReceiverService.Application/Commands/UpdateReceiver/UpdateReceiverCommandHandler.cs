using MediatR;
using ReceiverService.Domain.Interfaces;
using ReceiverService.Application.Commands.UpdateReceiver;
using ReceiverService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ReceiverService.Application.Commands.UpdateReceiver;

internal class UpdateReceiverCommandHandler : IRequestHandler<UpdateReceiverCommand, Unit>
{
    private readonly IReceiverDbContext _receiverDbContext;

    public UpdateReceiverCommandHandler(IReceiverDbContext receiverDbContext)
        => _receiverDbContext = receiverDbContext;
    public async Task<Unit> Handle(UpdateReceiverCommand request, CancellationToken cancellationToken)
    {
        var entity = await _receiverDbContext.Receivers.FirstOrDefaultAsync(e => e.UniqKey == request.UniqKey, cancellationToken);
        if (entity is null)
        {
            throw new Exception("Не найдена сущность."); //NotFaundException
        }

        entity.Name = request.Name;
        entity.PhoneNumber = request.PhoneNumber;
        entity.BirthDate = request.BirthDate;

        await _receiverDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

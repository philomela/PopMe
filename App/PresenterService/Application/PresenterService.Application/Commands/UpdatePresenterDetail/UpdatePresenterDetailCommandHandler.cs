using MediatR;
using Microsoft.EntityFrameworkCore;
using PresenterService.Application.Commands.UpdatePresenter;
using PresenterService.Domain.Interfaces;

namespace PresenterService.Application.Commands.UpdatePresenterDetail;

internal class UpdatePresenterDetailCommandHandler : IRequestHandler<UpdatePresenterDetailCommand, Guid>
{
    private readonly IPresenterDbContext _presenterDbContext;

    public UpdatePresenterDetailCommandHandler(IPresenterDbContext presenterDbContext)
    => _presenterDbContext = presenterDbContext;
    public async Task<Guid> Handle(UpdatePresenterDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _presenterDbContext.Presenters
                                              .Include(p => p.Meme)
                                              .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (entity is null || entity.Meme is null)
        {
            throw new Exception("Не найдена сущность."); //NotFaundException
        }

        entity.Meme.TextСongratulations = request.TextCongratulations;
        entity.Meme.VideoId = request.VideoId;

        await _presenterDbContext.SaveChangesAsync(cancellationToken);

        return entity.UniqKey;
    }
}

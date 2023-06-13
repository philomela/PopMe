using MediatR;
using PresenterService.Domain.Interfaces;

namespace PresenterService.Application.Commands.UpdatePresenter;

internal class UpdatePresenterCommandHandler : IRequestHandler<UpdatePresenterCommand, Guid>
{
    private readonly IPresenterDbContext _presenterDbContext;

    public UpdatePresenterCommandHandler(IPresenterDbContext presenterDbContext) 
        => _presenterDbContext = presenterDbContext; 
    public async Task<Guid> Handle(UpdatePresenterCommand request, CancellationToken cancellationToken)
    {
        var entity = await _presenterDbContext.Presenters.FindAsync(request.Id, cancellationToken);
        if (entity is null)
        {
            throw new Exception("Не найдена сущность."); //NotFaundException
        } 

        entity.Name = request.Name;
        entity.PhoneNumber = request.PhoneNumber;

        await _presenterDbContext.SaveChangesAsync(cancellationToken);

        return entity.UniqKey;
    }
}

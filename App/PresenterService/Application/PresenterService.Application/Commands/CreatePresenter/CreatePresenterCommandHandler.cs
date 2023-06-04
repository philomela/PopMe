using MediatR;
using PresenterService.Domain.Core;
using PresenterService.Domain.Interfaces;

namespace PresenterService.Application.Commands.CreatePresenter
{
    internal class CreatePresenterCommandHandler : IRequestHandler<CreatePresenterCommand, Unit>
    {
        private readonly IPresenterDbContext _presenterDbContext;

        public CreatePresenterCommandHandler(IPresenterDbContext presenterDbContext)
            => _presenterDbContext = presenterDbContext;

        public async Task<Unit> Handle(CreatePresenterCommand request, CancellationToken cancellationToken)
        {
            await _presenterDbContext.Presenters.AddAsync(
                new Presenter()
                {
                    Id = request.Id,
                    //Meme = new Meme()
                    //{   
                    //    Id = Guid.NewGuid(),
                    //    PresenterId = request.Id,
                    //}
                });

            await _presenterDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

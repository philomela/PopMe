using AdminService.Application.Common.Interfaces;
using AdminService.Domain.Core;
using AdminService.Domain.Interfaces;
using MediatR;

namespace AdminService.Application.Commands.GeneratePairQrCodes;

internal class GeneratePairQrCodesCommandHandler : IRequestHandler<GeneratePairQrCodesCommand, Unit>
{
    private readonly IQrCodeClient<string> _qrCodeGenerator;
    private readonly IAdminDbContext _adminDbContext;

    public GeneratePairQrCodesCommandHandler(IQrCodeClient<string> qrCodeGenerator, IAdminDbContext adminDbContext)
        => (_qrCodeGenerator, _adminDbContext) = (qrCodeGenerator, adminDbContext);
    public async Task<Unit> Handle(GeneratePairQrCodesCommand request, CancellationToken cancellationToken)
    {
        var receiverQrCodeBase64 = _qrCodeGenerator.GenerateQrCodeAsync(request.ReceiverData.ToString(), cancellationToken);
        var presenterQrCodeBase64 = _qrCodeGenerator.GenerateQrCodeAsync(request.PresenterData.ToString(), cancellationToken);

        await _adminDbContext.QrCodes.AddAsync(
            new PairQrCodes()
            {
                ReceiverDataBase64 = await receiverQrCodeBase64,
                PresenterDataBase64 = await presenterQrCodeBase64
            });

        await _adminDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

using MediatR;

namespace AdminService.Application.Queries.GetInfoPairsQrCodes;

public record GetInfoPairsQrCodesQuery : IRequest<InfoPairsQrCodesVm>
{
}

using MediatR;

namespace AdminService.Application.Queries.GetPairQrCodes;

public record GetPairQrCodesQuery : IRequest<PairQrCodesVm>
{
    public Guid Id { get; init; }

	public GetPairQrCodesQuery(Guid id) => Id = id;
}

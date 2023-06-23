using AdminService.Application.Common.Interfaces;
using AutoMapper;
using Dapper;
using MediatR;

namespace AdminService.Application.Queries.GetInfoPairsQrCodes;

internal class GetInfoPairsQrCodesQueryHandler : IRequestHandler<GetInfoPairsQrCodesQuery, InfoPairsQrCodesVm>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IMapper _mapper;
    public GetInfoPairsQrCodesQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IMapper mapper)
        => (_sqlConnectionFactory, _mapper) = (sqlConnectionFactory, mapper);
    public async Task<InfoPairsQrCodesVm> Handle(GetInfoPairsQrCodesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.GetOpenConnection();

        var infoPairsQrCodes = await connection.QuerySingleAsync<InfoPairsQrCodesDto>(@$"SELECT COUNT(Id) {nameof(InfoPairsQrCodesDto.CountPairsQrCodes)}
                                                                                               ,MAX([CreateDate]) {nameof(InfoPairsQrCodesDto.LastDateTimeCreated)}
                                                                                         FROM dbo.[PairQrCodes] WITH(nolock)");
        return _mapper.Map<InfoPairsQrCodesVm>(infoPairsQrCodes);
    }
}

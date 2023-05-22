using AdminService.Application.Common.Interfaces;
using AutoMapper;
using Dapper;
using MediatR;

namespace AdminService.Application.Queries.GetPairQrCodes;

internal class GetPairQrCodesQueryHandler : IRequestHandler<GetPairQrCodesQuery, PairQrCodesVm>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IMapper _mapper;
    public GetPairQrCodesQueryHandler(ISqlConnectionFactory sqlConnectionFactory) 
        => _sqlConnectionFactory = sqlConnectionFactory;
    public async Task<PairQrCodesVm> Handle(GetPairQrCodesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.GetOpenConnection();

        var pairQrCodes = await connection.QuerySingleAsync(@"SELECT [PresenterDataBase64]
                                                                    ,[ReceiverDataBase64] 
                                                            FROM dbo.[PairQrCodes] WHERE Id = @Id", 
                                                            new { request.Id });
        return _mapper.Map<PairQrCodesVm>(pairQrCodes);
    }
}
using AutoMapper;
using Dapper;
using MediatR;
using ReceiverService.Application.Common.Interfaces;
using ReceiverService.Domain.Core;

namespace ReceiverService.Application.Queries.GetReceiver;

internal class GetReceiverQueryHandler : IRequestHandler<GetReceiverQuery, ReceiverVm>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IMapper _mapper;

    public GetReceiverQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IMapper mapper)
        => (_sqlConnectionFactory, _mapper) = (sqlConnectionFactory, mapper);
    public async Task<ReceiverVm> Handle(GetReceiverQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.GetOpenConnection();

        var receiver = await connection.QuerySingleAsync<Receiver>(@$"SELECT [Id]
                                                                            ,[Name]
                                                                            ,[PhoneNumber]
                                                                            ,[SurpriseDate]
                                                                         FROM dbo.[Receiver]
                                                                         WHERE Id = @Id",
                                                                         new { request.Id });
        var meme = await connection.QuerySingleAsync<Meme>(@$"SELECT [TextСongratulations]
                                                                    ,[VideoId]
                                                                 FROM dbo.[Meme]
                                                                 WHERE Id = @Id",
                                                                 new { request.Id });

        receiver.Meme = meme;
        
        return _mapper.Map<ReceiverVm>(receiver);
    }
}

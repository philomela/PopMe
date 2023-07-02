using AutoMapper;
using MediatR;
using Dapper;
using PresenterService.Application.Common.Interfaces;
using PresenterService.Domain.Core;
using static Dapper.SqlMapper;

namespace PresenterService.Application.Queries.GetPresenter;

internal class GetPresenterQueryHandler : IRequestHandler<GetPresenterQuery, PresenterVm>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IMapper _mapper;

    public GetPresenterQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IMapper mapper)
        => (_sqlConnectionFactory, _mapper) = (sqlConnectionFactory, mapper);
    public async Task<PresenterVm> Handle(GetPresenterQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.GetOpenConnection();

        var presenter = await connection.QuerySingleOrDefaultAsync<Presenter>(@$"SELECT [Id]
                                                                                       ,[Name]
                                                                                       ,[PhoneNumber]
                                                                              FROM dbo.[Presenter] WHERE Id = @Id",
                                                                              new { request.Id });
        //if (presenter is null)
        //{
        //    throw new Exception("Не найдена сущность."); //NotFaundException
        //}
        return _mapper.Map<PresenterVm>(presenter);
    }
}

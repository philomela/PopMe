using System.Data;

namespace PresenterService.Application.Common.Interfaces;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    string GetConnectionString();
}

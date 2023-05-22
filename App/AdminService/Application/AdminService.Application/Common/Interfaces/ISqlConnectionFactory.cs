using System.Data;

namespace AdminService.Application.Common.Interfaces;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    string GetConnectionString();
}

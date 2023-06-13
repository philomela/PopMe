using System.Data;

namespace ReceiverService.Application.Common.Interfaces;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    string GetConnectionString();
}

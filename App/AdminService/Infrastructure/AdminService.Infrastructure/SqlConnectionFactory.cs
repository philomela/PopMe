using AdminService.Application.Common.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdminService.Infrastructure;

internal class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
{
    private readonly string _connectionString;
    private IDbConnection _connection;

    public SqlConnectionFactory(string connectionString) 
        => _connectionString= connectionString;

    public string GetConnectionString()
    {
        return _connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        return _connection;
    }

    public void Dispose()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Dispose();
        }
    }
}

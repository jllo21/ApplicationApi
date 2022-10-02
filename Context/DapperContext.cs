using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.Common;

namespace ApplicationApi.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            // Grab connection string from appsettings
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DataDb");
        }

        public IDbConnection CreateConnection() => new SqliteConnection(_connectionString);
    }
}

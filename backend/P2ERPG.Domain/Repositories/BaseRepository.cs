using BilbolStack.Boonamai.P2ERPG.Common.Extensions;
using BilbolStack.Boonamai.P2ERPG.Common.Options;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using System.Security;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private SecureString _connectionString;
        public BaseRepository(IOptions<DBSettings> dbSettings)
        {
            _connectionString = dbSettings?.Value?.DefaultConnection?.ToSecureString()!;
        }

        protected virtual async Task<IEnumerable<T>> GetList(string query, object param = null)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                return await conn.QueryAsync<T>(query, param, commandType: CommandType.StoredProcedure);
            }
        }

        protected virtual async Task<T> Get(string query, object param = null)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                return await conn.QueryFirstOrDefault(query, param, commandType: CommandType.StoredProcedure);
            }
        }

        protected virtual async Task<int> Execute(string query, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                return await conn.ExecuteAsync(query, param, commandType: commandType);
            }
        }

        protected virtual async Task<V> ExecuteScalar<V>(string query, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                return await conn.ExecuteScalarAsync<V>(query, param, commandType: commandType);
            }
        }

        protected string GetConnectionString()
        {
            return _connectionString.ExtractPassword();
        }
    }
}

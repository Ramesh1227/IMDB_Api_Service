using Dapper;
using Microsoft.Extensions.Configuration;
using MovieInformationService.Data.Database.Settings;
//using IMDBInformation.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static MovieinformationService.Domain.Common.Constants.Constants;

namespace IMDBInformation.Repository.Database.Executor
{
    public class DatabaseExecutor : IDatabaseExecutor
    {
        private readonly IDatabaseSettings _idatabasesetting;

        public DatabaseExecutor( IDatabaseSettings databaseSettings)
        {
            _idatabasesetting = databaseSettings;
        }


        public async Task<T> ExcecuteQuery<T>(Func<IDbConnection, Task<T>> operation)
        {
            using (var connection = new SqlConnection(_idatabasesetting.Connectionstring))
                return await operation(connection);
        }

        public Task ExcecuteQuery<T>(Func<IDbConnection, Task> operation)
        {

            using (var connection = new SqlConnection(_idatabasesetting.Connectionstring))
                return operation(connection);
        }

        //public Task<int> Insert<T>(string sql, object parameters = null)
        //{

        //    using (var connection = new SqlConnection(_idatabasesetting.Connectionstring))
        //        return await int;
        //}
    }
}


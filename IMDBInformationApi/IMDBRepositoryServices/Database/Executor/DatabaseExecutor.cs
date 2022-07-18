using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Repository.Database.Executor
{
    public class DataBaseExecutor : IDatabaseExecutor
    {

        private readonly IDbConnection _dbconnection;

        public DataBaseExecutor(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public void Dispose()
        {
            _dbconnection.Dispose();
        }

        public Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transcation = null, int? commandTimeOut = null, CommandType? commandType = null)
        {
            return _dbconnection.ExecuteAsync(sql, param, transcation, commandTimeOut, commandType);
        }
    }
}

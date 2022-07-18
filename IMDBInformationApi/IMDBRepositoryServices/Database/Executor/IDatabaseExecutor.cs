using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Repository.Database.Executor
{
    public interface IDatabaseExecutor : IDisposable
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transcation = null, int? commandTimeOut = null, CommandType? commandType = null);
    }
}

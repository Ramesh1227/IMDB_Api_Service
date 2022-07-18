using System.Data;

namespace IMDBInformation.Repository.Database.Executor
{
    public interface IDatabaseExecutor 
    {
        Task<T> ExcecuteQuery<T>(Func<IDbConnection, Task<T>> operation);
        Task ExcecuteQuery<T>(Func<IDbConnection, Task> operation);
       // Task<int> Insert<T>(string sql, object parameters = null);
    }
}

using MovieInformationService.Data.Database.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Repository.Database.Executor
{
    public class DataBaseExecutorFactory : IDataBaseExecutorFactory
    {
        private readonly IDatabaseSettings idatabaseSetting;

        public DataBaseExecutorFactory(IDatabaseSettings databaseSettings)
        {
            idatabaseSetting = databaseSettings;
        }
        public IDatabaseExecutor CreateExcecutor()
        {
            if (string.IsNullOrEmpty(idatabaseSetting.Connectionstring))
                throw new ArgumentException();

            SqlConnection sql = new SqlConnection(idatabaseSetting.Connectionstring);
            sql.Open();
            return new DataBaseExecutor(sql);
        }
    }
}

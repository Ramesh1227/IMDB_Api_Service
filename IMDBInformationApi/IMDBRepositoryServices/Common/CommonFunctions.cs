using IMDBInformation.Domain.Contract.Request.Common;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Repository.Common
{
    public static class CommonFunctions
    {
        public static IEnumerable<SqlDataRecord> CreateSqlDataRecord(IEnumerable<Actors> list)
        {
            var metaData = new SqlMetaData("Value", SqlDbType.Int);
            var record = new SqlDataRecord(metaData);
            foreach (var item in list)
            {
                record.SetInt32(0, item.ActorId);
                yield return record;
            }
        }
    }
}

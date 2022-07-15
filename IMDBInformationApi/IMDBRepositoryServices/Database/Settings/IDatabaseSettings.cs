using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationService.Data.Database.Settings
{
    public interface IDatabaseSettings
    {
        string Connectionstring { get; }
        int CommandTimeOut { get; }


    }
}

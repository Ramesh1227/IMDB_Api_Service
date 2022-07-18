using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Domain
{
    public static class AppSettings
    {
        public static string Environment { get; set; }

        public static string ConnectionString { get; set; }

        public static void AssignAppSettings(IConfiguration configuration)
        {
            Environment = configuration["Environment"];

            ConnectionString = configuration["ConnectionString"];

        }
    }
}

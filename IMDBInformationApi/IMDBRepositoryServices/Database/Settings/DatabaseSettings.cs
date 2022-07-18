using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationService.Data.Database.Settings
{
    public class DatabaseSettings: IDatabaseSettings
    {
        private string _connectionString { get; set; }
        private int _commandTimeout { get; set; }

        private IConfiguration _Configuration;
        public DatabaseSettings(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public string Connectionstring
        { get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = _Configuration["ConnectionString"];
                        //Environment.GetEnvironmentVariable("ConnectionString");
                    //_Configuration.GetConnectionString("DatabaseConnectingString");
                    // Environment.GetEnvironmentVariable("DatabaseConnectingString");
                }
                return _connectionString;
            }
            set {
                _connectionString = value;
            } 
        }

        public int CommandTimeOut
        {
            get
            { 
                if(_commandTimeout == 0)
                {
                    _commandTimeout = 100;
                }
                return _commandTimeout;
            }
            set
            {
                _commandTimeout = value;

            }
        }
    }
}

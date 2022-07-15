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

        public string Connectionstring
        { get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = Environment.GetEnvironmentVariable("DatabaseConnectingString");
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

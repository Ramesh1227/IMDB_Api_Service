using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Repository.SQLQueries
{
    public class SqlFiles
    {
        private static readonly string sqlpath = "IMDBInformation.Repository.SQLQueries.Read";

        public static readonly string GetMovieInformation = $"{sqlpath}.GetMovieInformation.sql";


    }
}


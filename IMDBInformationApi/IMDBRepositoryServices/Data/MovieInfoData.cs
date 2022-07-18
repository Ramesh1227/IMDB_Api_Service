using IMDBInformation.Domain;
using IMDBInformation.Domain.Repositories;
using IMDBInformation.Domain.DataEntities;
using IMDBInformation.Domain;
using Dapper;
using Dapper.Compose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDBInformation.Repository.SQLQueries;
using IMDBInformation.Repository.Database.Executor;
using IMDBInformation.Repository.MockSetup;
using MovieInformationService.Data.Database.Settings;
using System.Data.SqlClient;

namespace IMDBInformation.Repository.Repository
{
    public class MovieInfoData : IMovieInfoData
    {
        private IDatabaseExecutor _databaseExecutor { get; set; }
        private IDatabaseSettings idatabaseSettings { get; set; }
        public MovieInfoData(IDatabaseExecutor databaseExecutor, IDatabaseSettings databaseSettings)
        {
            _databaseExecutor = databaseExecutor;
            idatabaseSettings = databaseSettings;
        }

        public async Task<IEnumerable<MovieInfoDataModel>> GetAllMovieInformationData()
        {
            try
            {
                using (var connection = new SqlConnection(idatabaseSettings.Connectionstring))
                {
                    var query = Query.Load<SqlFiles>(SqlFiles.GetMovieInformation);
                    var result = await connection.QueryAsync<MovieInfoDataModel>(query);
                    return result;
                };
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<MovieInformationCreateResponse> CreateMovieInformationData(MovieInformationCreateRequest request)
        {
            var data = MockData.AddMovieInfo(request);

            return data;
        }

        public async Task<MovieInformationEditResponse> EditMovieInformationData (MovieInformationEditRequest request)
        {
            var response = MockData.EditMovieInfo(request);

            return response;
        }
    }
}

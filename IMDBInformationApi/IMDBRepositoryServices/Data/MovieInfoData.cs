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

namespace IMDBInformation.Repository.Repository
{
    public class MovieInfoData : IMovieInfoData
    {
        private IDatabaseExecutorFactory _databaseExecutorFactory { get; set; }
        public MovieInfoData(IDatabaseExecutorFactory databaseExecutorFactory)
        {
            _databaseExecutorFactory = databaseExecutorFactory;
        }

        public async Task<MovieInformationGetAllResponse> GetAllMovieInformationData()
        {
            IEnumerable<MovieInfoDataModel> movieinfo;
            var response = MockData.Movieinfo();
            //using (var connection = _databaseExecutorFactory.CreateExecutor())
            //{
            //    var query = Query.Load<SqlFiles>(SqlFiles.GetMovieInformation);
            //    movieinfo = connection.Query<IMDBInformation.Domain.DataEntities.MovieInfoDataModel>(query);
            //}
            //movieinfo = movieinfo.ToList().GroupBy();


            return response;
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

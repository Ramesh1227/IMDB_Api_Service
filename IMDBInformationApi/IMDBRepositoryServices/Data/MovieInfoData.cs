using IMDBInformation.Domain;
using IMDBInformation.Domain.Repositories;
using IMDBInformation.Domain.DataEntities;
using Dapper;
using Dapper.Compose;
using System.Data;
using IMDBInformation.Repository.SQLQueries;
using MovieInformationService.Data.Database.Settings;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using IMDBInformation.Domain.Contract.Request.Common;
using IMDBInformation.Repository.Common;
using IMDBInformation.Repository.Database.Executor;

namespace IMDBInformation.Repository.Repository
{
    public class MovieInfoData : IMovieInfoData
    {
        //private IDataBaseExecutorFactory _dataBaseExecutorFactory;
        private IDatabaseSettings idatabaseSettings { get; set; }
        public MovieInfoData( IDatabaseSettings databaseSettings) //IDataBaseExecutorFactory dataBaseExecutorFactory)
        {
            idatabaseSettings = databaseSettings;
           // _dataBaseExecutorFactory = dataBaseExecutorFactory;
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

        public async Task<int> CreateMovieInformationData(MovieInformationCreateRequest request)
        {
            try
            {

                using (var connection = new SqlConnection(idatabaseSettings.Connectionstring))
                //using (var connection = _dataBaseExecutorFactory.CreateExcecutor())
                {
                    IEnumerable<Actors> list = request.Actors.AsList();
                    var tvprecords = CommonFunctions.CreateSqlDataRecord(list).AsTableValuedParameter("dbo.UserDefinedTable");
                    var Parameter = new DynamicParameters();
                    Parameter.Add("MovieName", request.MovieName);
                    Parameter.Add("Plot", request.Plot);
                    Parameter.Add("ProducerId", request.ProducerId);
                    Parameter.Add("Actor_List", tvprecords);
                    Parameter.Add("DateOfRelease", request.DateOfRelease);
                    Parameter.Add(name: "@Movie_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    await connection.ExecuteAsync("dbo.CreateMovies", Parameter, commandType: CommandType.StoredProcedure);

                    var result = Parameter.Get<int>("@Movie_Id");
                    return (int)result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EditMovieInformationData (MovieInformationEditRequest request)
        {
            try
            {
                MovieInformationEditResponse response = new MovieInformationEditResponse();
                using (var connection = new SqlConnection(idatabaseSettings.Connectionstring))
                {
                    IEnumerable<Actors> list = request.Actors.AsEnumerable();
                    var tvprecords = CommonFunctions.CreateSqlDataRecord(list).AsTableValuedParameter("dbo.UserDefinedTable");
                    var Parameter = new DynamicParameters();

                    Parameter.Add("MovieId", request.MovieId);
                    Parameter.Add("MovieName", request.MovieName);
                    Parameter.Add("Plot", request.Plot);
                    Parameter.Add("ProducerId", request.ProducerId);
                    Parameter.Add("Actor_List", tvprecords);
                    Parameter.Add("DateOfRelease", request.DateOfRelease);
                    Parameter.Add(name:"@Movie_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    await connection.ExecuteAsync("dbo.UpdateMovieDetails", Parameter, commandType: CommandType.StoredProcedure);
                    var result = Parameter.Get<int>("@Movie_Id");
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}

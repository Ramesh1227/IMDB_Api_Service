using Microsoft.Extensions.DependencyInjection;
using IMDBInformation.Domain.Repositories;
using IMDBInformation.Domain.Services.Implementation;
using IMDBInformation.Domain.Services.Interfaces;
using MovieInformationService.Data.Database.Settings;
using IMDBInformation.Repository.Database;
using IMDBInformation.Repository.Repository;
using IMDBInformation.Repository.Database.Executor;

namespace IMDBInformation.Repository.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection DataConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IMovieInfoData, MovieInfoData>();
            services.AddScoped<IMovieInfoService, MovieInfoService>();

            services.AddScoped<IDatabaseSettings, DatabaseSettings>();
            //services.AddScoped<IDatabaseExecutor, DataBaseExecutor>();
            //services.AddScoped<IDataBaseExecutorFactory, DataBaseExecutorFactory>();

            return services;
        }
    }
}

using IMDBInformation.Domain.Repositories;
using IMDBInformation.Domain.Services.Interfaces;
using IMDBInformation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Domain.Services.Implementation
{
    public class MovieInfoService : IMovieInfoService
    {
        private readonly IMovieInfoData _movieInfoData;

        public MovieInfoService (IMovieInfoData movieInfoData)
        {
            _movieInfoData = movieInfoData;
        }

        public async Task<MovieInformationGetAllResponse> GetAllMovieInformation()
        {
            try
            {

                var result = await _movieInfoData.GetAllMovieInformationData();
                MovieInformationGetAllResponse response;
                if (result != null)
                {
                    var movieInformation = result.GroupBy(x => x.MovieId).Select(movieinfo => new MovieInformationGetAllDto()
                    {
                        MovieId = movieinfo.Key,
                        MovieName = movieinfo.First().MovieName,
                        Producer = movieinfo.First().ProducerName,
                        DateOfrelease = movieinfo.First().DateOfrelease,
                        Actors = result.Where(x => x.MovieId == movieinfo.Key).Select(x => new ActorsInfo() { ActorsName = x.ActorName }).ToList(),
                    }).ToList();
                    return response = new MovieInformationGetAllResponse { GetAllMovieInformations = movieInformation };
                }
                else
                {
                    throw new Exception();
                }

            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<MovieInformationCreateResponse> CreateMovieInformation(MovieInformationCreateRequest request)
        {
            try
            {
                MovieInformationCreateResponse response;
                var result = await _movieInfoData.CreateMovieInformationData(request);
                if (result > 0)
                {
                    response = new MovieInformationCreateResponse()
                    {
                        MovieId = result,
                        Message = "MovieInformation successfully created."
                    };

                    return response;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<MovieInformationEditResponse> EditMovieInformation(MovieInformationEditRequest request)
        {
            try
            {
                MovieInformationEditResponse response;
                var result = await _movieInfoData.EditMovieInformationData(request);
                if (result > 0)
                {
                    response = new MovieInformationEditResponse()
                    {
                        MovieId = result,
                        Message = $"MovieInformation updated successfully."
                    };

                    return response;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }
    }
}

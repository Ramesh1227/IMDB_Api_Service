using IMDBInformation.Domain;
using System.Net;

namespace IMDBInformation.Repository.MockSetup
{
    public static class MockData
    {
        public static MovieInformationGetAllResponse movieInfoDataModel = new MovieInformationGetAllResponse();

       static MockData()
        {
             movieInfoDataModel = new MovieInformationGetAllResponse()
            {
                GetAllMovieInformations = new List<MovieInformationGetAllDto>()
                    {
                        new MovieInformationGetAllDto()
                        {
                            MovieId = 2,
                            MovieName = "Don",
                            DateOfrelease = "20/12/2022",
                            Producer = "Cibi",
                            Actors = new List<ActorsInfo>()
                            {
                                new Domain.ActorsInfo()
                                {
                                    ActorsName = "Siva"
                                },
                                new Domain.ActorsInfo()
                                {
                                    ActorsName = "Vijay"
                                },
                                new Domain.ActorsInfo()
                                {
                                    ActorsName = "Bala"
                                },
                                new Domain.ActorsInfo()
                                {
                                    ActorsName = "SJ Surya"
                                },
                            }

                        },
                        new MovieInformationGetAllDto()
                        {
                            MovieId = 2,
                            MovieName = "KGF 3",
                            DateOfrelease = "20/12/2022",
                            Producer = "Prashanth Neel",
                            Actors = new List<ActorsInfo>()
                            {
                                new Domain.ActorsInfo()
                                {
                                    ActorsName = "Yash"
                                },
                                new Domain.ActorsInfo()
                                {
                                    ActorsName = "Ravi"
                                },
                                new Domain.ActorsInfo()
                                {
                                    ActorsName = "PrakashRaj"
                                },
                                new Domain.ActorsInfo()
                                {
                                    ActorsName = "Srinidhi Shetty"
                                },
                            }

                        }
                    }
            };
        }
        public static MovieInformationGetAllResponse Movieinfo()
        {
            return movieInfoDataModel;
        }

        public static MovieInformationCreateResponse AddMovieInfo(MovieInformationCreateRequest request)
        {
            MovieInformationCreateResponse response = new MovieInformationCreateResponse()
            {
                Message = "Movie Information added succcessfully",
                Status = (int) HttpStatusCode.OK,

            };

            movieInfoDataModel.GetAllMovieInformations.Add(new MovieInformationGetAllDto
            {
                MovieName = request.MovieName,
                MovieId = request.MovieId,
                DateOfrelease = request.DateOfRelease,
                Producer = request.ProducerName
            });

            return response;
        }

        public static MovieInformationEditResponse EditMovieInfo(MovieInformationEditRequest request)
        {
            MovieInformationEditResponse response = new MovieInformationEditResponse()
            {
                Message = "Movie Information updated succcessfully",
                Status = (int)HttpStatusCode.OK,

            };
            return response;
        }
    }
}

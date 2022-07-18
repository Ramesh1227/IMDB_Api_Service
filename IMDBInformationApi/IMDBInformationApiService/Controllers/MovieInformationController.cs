using IMDBInformation.Domain;
using IMDBInformation.Domain.Services.Interfaces;
using IMDBInformationApiService.CommonUtilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBInformationApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieInformationController : ControllerBase
    {
        private  readonly IMovieInfoService _movieInfoService;
        public MovieInformationController(IMovieInfoService movieInfoService)
        {
            _movieInfoService = movieInfoService;
        }

        // GET: api/<GetAllMovieInfomation>
        [HttpGet("GetAllMovieInfomation")]
        public async Task<IActionResult> Get()
        {
            try
            {

                var result = await _movieInfoService.GetAllMovieInformation();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDetails
                {
                    message = ex.Message,
                    statuscode = (int)HttpStatusCode.InternalServerError,
                });
                throw ex;
            }
        }

        // POST api/<AddMovieInformation>
        [HttpPost("AddMovieInformation")]
        public async Task<IActionResult> Post([FromBody] MovieInformationCreateRequest request)
        {
            try
            {
                var response = await _movieInfoService.CreateMovieInformation(request);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorDetails
                {
                    message = ex.Message,
                    statuscode = (int)HttpStatusCode.InternalServerError,
                });
                throw ex;
            }
        }

        // PUT api/<EditMovieInformation>/
        [HttpPut("EditMovieInformation")]
        public async Task<IActionResult> Put([FromBody] MovieInformationEditRequest request)
        {
            try
            {
                var response = await _movieInfoService.EditMovieInformation(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDetails { 
                    message = ex.Message,
                    statuscode = (int)HttpStatusCode.InternalServerError,
                });
                throw ex;
            }
        }
    }
}

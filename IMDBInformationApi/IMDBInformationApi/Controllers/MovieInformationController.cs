using IMDBInformation.Domain;
using IMDBInformation.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieInformationService.Controllers
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _movieInfoService.GetAllMovieInformation();
            return Ok(result);
        }

        // POST api/<CreateMovieInformation>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieInformationCreateRequest request)
        {
            var response = await _movieInfoService.CreateMovieInformation(request);

            return Ok(response);
        }

        // PUT api/<EditMovieInformation>/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MovieInformationEditRequest request)
        {
            var response = await _movieInfoService.EditMovieInformation(request);

            return Ok(response);
        }
    }
}

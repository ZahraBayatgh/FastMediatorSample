using Mediator;
using Microsoft.AspNetCore.Mvc;
using WebApp.NewMediator.Requests;

namespace WebApp.NewMediator.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("weather")]
        public async Task<IActionResult> GetWeatherForecast()
        {
            var weather = await _mediator.Send(new WeatherForecastRequest());
            return Ok(weather);
        }
    }
}
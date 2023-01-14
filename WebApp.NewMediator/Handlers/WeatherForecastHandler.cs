using Mediator;
using WebApp.NewMediator.Requests;

namespace WebApp.NewMediator.Handlers
{
    public class WeatherForecastHandler :
        IRequestHandler<WeatherForecastRequest, IEnumerable<WeatherForecast>>
    {
        ValueTask<IEnumerable<WeatherForecast>> IRequestHandler<WeatherForecastRequest, IEnumerable<WeatherForecast>>.Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = request.Summaries[Random.Shared.Next(request.Summaries.Length)]
            });

            return ValueTask.FromResult(result);
        }
    }
}

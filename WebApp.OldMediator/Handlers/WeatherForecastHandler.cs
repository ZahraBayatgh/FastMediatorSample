using MediatR;
using WebApp.OldMediator.Requests;

namespace WebApp.OldMediator.Handlers
{
    public class WeatherForecastHandler :
        IRequestHandler<WeatherForecastRequest, IEnumerable<WeatherForecast>>
    {
  
        public Task<IEnumerable<WeatherForecast>> Handle(
            WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = request.Summaries[Random.Shared.Next(request.Summaries.Length)]
            });

            return Task.FromResult(result);
        }
    }
}

using Mediator;

namespace WebApp.NewMediator.Requests
{
    public class WeatherForecastRequest : IRequest<IEnumerable<WeatherForecast>>
    {
        public string[] Summaries { get; set; }={
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

}
}

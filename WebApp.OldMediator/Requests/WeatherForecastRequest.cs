using MediatR;

namespace WebApp.OldMediator.Requests
{
    public class WeatherForecastRequest : IRequest<IEnumerable<WeatherForecast>>
    {
        public string[] Summaries { get; set; }={
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

}
}

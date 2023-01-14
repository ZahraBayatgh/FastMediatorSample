using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FastMediatorBenchmark
{
    [MemoryDiagnoser(false)]
    public class Bench
    {
        private readonly IMediator _mediatr;
        private readonly Mediator.IMediator _mediator;

        public Bench()
        {
            // Build old MediatR provider
            var oldServiceCollection = new ServiceCollection();
            oldServiceCollection.AddMediatR(configuration => configuration.AsTransient(), typeof(WebApp.OldMediator.WeatherForecast));
            
            var oldMediatR = oldServiceCollection.BuildServiceProvider();
            _mediatr = oldMediatR.GetRequiredService<IMediator>();

            // Build new Meditor provider
            var newServiceCollection = new ServiceCollection();
            newServiceCollection.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Transient);
           
            var newProvider = newServiceCollection.BuildServiceProvider();
            _mediator = newProvider.GetRequiredService<global::Mediator.IMediator>();
        }

        [Benchmark]
        public async Task<WebApp.OldMediator.WeatherForecast[]> Weather_OldMediator()
        {
            var request =new WebApp.OldMediator.Requests.WeatherForecastRequest();
            var result = await _mediatr.Send(request);
            return result.ToArray();
        }

        [Benchmark]
        public async Task<WebApp.NewMediator.WeatherForecast[]> Weather_NewMediator()
        {
            var request =new WebApp.NewMediator.Requests.WeatherForecastRequest();
            var result= await _mediator.Send(request);
            return result.ToArray();

        }
    }
}

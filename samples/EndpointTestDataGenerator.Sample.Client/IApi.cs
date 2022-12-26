using EndpointTestDataGenerator.Sample.WebApi;
using Refit;

namespace EndpointTestDataGenerator.Sample.Client;

public interface IApi
{
    [Get("/WeatherForecast")]
    Task<IEnumerable<WeatherForecast>> Get();
    
    [Get("/WeatherForecast/Test/{input}")]
    Task<string> GetTest(string input);
}
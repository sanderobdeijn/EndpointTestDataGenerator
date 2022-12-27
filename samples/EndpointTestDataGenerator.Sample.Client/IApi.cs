using EndpointTestDataGenerator.Sample.WebApi;
using Refit;

namespace EndpointTestDataGenerator.Sample.Client;

public interface IApi
{
    [Get("/Test")]
    Task<IEnumerable<WeatherForecast>> Get();
    
    [Get("/Test/{input}")]
    Task<string> GetTest(string input);
}
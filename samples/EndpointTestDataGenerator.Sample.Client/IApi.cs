using EndpointTestDataGenerator.Sample.WebApi;
using Refit;

namespace EndpointTestDataGenerator.Sample.Client;

public interface IApi
{
    [Get("/test")]
    Task<IEnumerable<TestDto>> Get();
    
    [Get("/test/{id}")]
    Task<TestDto> GetTest(Guid id);
    
    [Post("/test")]
    Task<TestDto> CreateTest(TestDto test);
    
    [Put("/test/{id}")]
    Task<TestDto> UpdateTest(Guid id, TestDto test);
    
    [Delete("/test/{id}")]
    Task DeleteTest(Guid id);
}
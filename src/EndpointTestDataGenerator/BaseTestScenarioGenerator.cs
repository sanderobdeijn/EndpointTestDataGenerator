using System.Reflection;
using Microsoft.AspNetCore.Mvc.Testing;
using Refit;

namespace EndpointTestDataGenerator;

public class BaseTestScenarioGenerator
{
    protected static WebApplicationFactory<T> CreateApplication<T>()
        where T : class => new();
    
    protected static IEnumerable<TestScenario> GetGeneratedTestScenarios<TA, TC>(WebApplicationFactory<TA> application)
        where TA : class
        where TC : class
    {
        var api = CreateApiClient<TA, TC>(application);

        return typeof(TC).GetMethods().Select(x => GetGeneratedTestScenario(x, api));
    }
    
    private static TC CreateApiClient<TA, TC>(WebApplicationFactory<TA> application)
        where TA : class
        where TC : class
    {
        var client = application.CreateClient();
        return RestService.For<TC>(client);
    }

    private static TestScenario GetGeneratedTestScenario(MethodInfo methodInfo, object api)
    {
        Task Act() => (Task)methodInfo.Invoke(api, Arguments.GetMethodArguments(methodInfo))!;

        return new TestScenario(methodInfo.DeclaringType!.Name, methodInfo.Name, Act);
    }
}
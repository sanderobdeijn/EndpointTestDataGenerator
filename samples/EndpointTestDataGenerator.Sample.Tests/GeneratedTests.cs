using EndpointTestDataGenerator.Sample.Client;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EndpointTestDataGenerator.Sample.Tests;

public class GeneratedTests
{
    [Theory]
    [ClassData(typeof(TestScenarioGenerator))]
    public async Task GeneratedTestWithClassData(TestScenario scenario)
    {
        await scenario.Act.Invoke();
    }
    
    [Theory]
    [MemberData(nameof(GetTestScenarios))]
    public async Task GeneratedTestWithMemberData(TestScenario scenario)
    {
        await scenario.Act.Invoke();
    }
    
    public static IEnumerable<object[]> GetTestScenarios()
    {
        var application = new WebApplicationFactory<Program>();

        foreach (var scenario in application.Include<Program, IApi>().Format())
        {
            yield return scenario;
        }
    }
}
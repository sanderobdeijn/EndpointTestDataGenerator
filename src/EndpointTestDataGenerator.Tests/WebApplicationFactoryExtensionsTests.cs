using System.Collections;
using Microsoft.AspNetCore.Mvc.Testing;
using Refit;

namespace EndpointTestDataGenerator.Tests;

public class WebApplicationFactoryExtensionsTests
{
    [Fact]
    public void IncludeShouldReturn2TestScenarios()
    {
        var application = new WebApplicationFactory<Program>();

        var result = application.Include<Program, ITestApi>();

        result.Count().Should().Be(2);
    }
    
    [Fact]
    public void IncludeShouldReturn1TestScenarios()
    {
        var application = new WebApplicationFactory<Program>();
    
        var result = application
            .Include<Program, ITestApi>()
            .Exclude(nameof(ITestApi.TestGet2))
            .ToList();
    
        result.Count().Should().Be(1);
        result.First().MethodName.Should().Be(nameof(ITestApi.TestGet1));
    }
    
    [Theory]
    [MemberData(nameof(GetTestScenarios))]
    public async Task TestScenariosShouldBeLoadedByMemberData(TestScenario scenario)
    {
        await scenario.Act.Invoke();
    }
    
    public static IEnumerable<object[]> GetTestScenarios()
    {
        var application = new WebApplicationFactory<Program>();

        foreach (var scenario in application.Include<Program, ITestApi>().Format())
        {
            yield return scenario;
        }
    }
    
    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public async Task TestScenariosShouldBeLoadedByClassData(TestScenario scenario)
    {
        await scenario.Act.Invoke();
    }
}

public interface ITestApi
{
    [Get("/Test")]
    Task<string> TestGet1();

    [Get("/Test/{input}")]
    Task<string> TestGet2(string input);
}


public class TestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var application = new WebApplicationFactory<Program>();

        foreach (var scenario in application.Include<Program, ITestApi>().Format())
        {
            yield return scenario;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
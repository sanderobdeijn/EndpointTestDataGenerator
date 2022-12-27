using System.Collections;
using EndpointTestDataGenerator.Sample.Client;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EndpointTestDataGenerator.Sample.Tests;

public class TestScenarioGenerator : IEnumerable<object[]>
{
    private static IEnumerable<object[]> GetGeneratedTestScenarios()
    {
        var application = new WebApplicationFactory<Program>();

        foreach (var scenario in application.Include<Program, IApi>().Format())
        {
            yield return scenario;
        }
    }

    public IEnumerator<object[]> GetEnumerator() => GetGeneratedTestScenarios().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

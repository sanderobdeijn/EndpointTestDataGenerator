using System.Collections;
using EndpointTestDataGenerator.Sample.Client;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EndpointTestDataGenerator.Sample.Tests;

public class TestScenarioGenerator : BaseTestScenarioGenerator, IEnumerable<object[]>
{
    private static readonly List<object[]> Data;

    static TestScenarioGenerator()
    {
        Data = GetGeneratedTestScenarios().Select(s => new object[] { s }).ToList();
    }

    private static IEnumerable<TestScenario> GetGeneratedTestScenarios()
    {
        var application = CreateApplication<Program>();

        var testScenarios = GetGeneratedTestScenarios<Program, IApi>(application);

        return testScenarios;
    }

    public IEnumerator<object[]> GetEnumerator() => Data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

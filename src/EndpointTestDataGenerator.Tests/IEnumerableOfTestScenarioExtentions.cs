namespace EndpointTestDataGenerator.Tests;

public static class IEnumerableOfTestScenarioExtentions
{
    public static IEnumerable<TestScenario> Exclude(this IEnumerable<TestScenario> scenarios,
        string nameOfMethodToExclude)
    {
        return scenarios.Where(x => x.MethodName != nameOfMethodToExclude);
    }
}
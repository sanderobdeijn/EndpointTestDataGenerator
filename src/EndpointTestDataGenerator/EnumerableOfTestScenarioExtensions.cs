namespace EndpointTestDataGenerator;

public static class EnumerableOfTestScenarioExtensions
{
    public static IEnumerable<object[]> Format(this IEnumerable<TestScenario> testScenarios)
    {
        return testScenarios.Select(s => new object[] { s }).ToList();
    }
    
    public static IEnumerable<TestScenario> Exclude(this IEnumerable<TestScenario> testScenarios, string nameOfMethodToExclude)
    {
        return testScenarios.Where(x => x.MethodName != nameOfMethodToExclude);
    }
}
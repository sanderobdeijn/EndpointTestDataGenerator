namespace EndpointTestDataGenerator.Sample.Tests;

public class GeneratedTests
{
    [Theory]
    [ClassData(typeof(TestScenarioGenerator))]
    public async Task GeneratedTest(TestScenario scenario)
    {
        await scenario.Act.Invoke();
    }
}
namespace EndpointTestDataGenerator;

public record TestScenario(string ClassName, string MethodName, Func<Task> Act, string? TestSuffix = null)
{
    public override string ToString() => TestSuffix == null ? $"{ClassName}.{MethodName}" : $"{ClassName}.{MethodName}-{TestSuffix}";
}
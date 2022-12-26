using System.Reflection;

namespace EndpointTestDataGenerator;

public static class Arguments
{
    public static object[] GetMethodArguments(MethodInfo methodInfo)
    {
        return methodInfo.GetParameters().Select(x => GetDefaultArgumentValue(x.ParameterType)).ToArray();
    }

    public static object GetDefaultArgumentValue(Type type)
    {
        return type switch
        {
            Type { Name: nameof(String) } => "Test",
            Type { Name: nameof(Int32) } => default(int),
            Type { Name: nameof(Guid) } => Guid.Empty,
            Type { Name: nameof(CancellationToken) } => CancellationToken.None,
            { } x when x.Name.StartsWith("Nullable") => null!,
            _ => null!,
        };
    }
}
using FluentAssertions;

namespace EndpointTestDataGenerator.Tests;

public class ArgumentsTests
{
    [Theory]
    [InlineData(typeof(string), "Test")]
    [InlineData(typeof(int), 0)]
    [InlineData(typeof(int?), null)]
    public void GetDefaultArgumentValueShouldReturnValidValue(Type type, object expected)
    {
        var result = Arguments.GetDefaultArgumentValue(type);

        result.Should().Be(expected);
    }
    
    [Fact]
    public void GetDefaultArgumentValueShouldReturnEmptyGuidWhenArgumentIsGuid()
    {
        var result = Arguments.GetDefaultArgumentValue(typeof(Guid));

        result.Should().Be(Guid.Empty);
    }
    
    [Fact]
    public void GetDefaultArgumentValueShouldReturnEmptyGuidWhenArgumentIsCancellelationToken()
    {
        var result = Arguments.GetDefaultArgumentValue(typeof(CancellationToken));

        result.Should().Be(CancellationToken.None);
    }
    
    [Fact]
    public void GetDefaultArgumentValueShouldReturnDefaultInstanceWhenArgumentIsCustomType()
    {
        var result = Arguments.GetDefaultArgumentValue(typeof(CustomRecord));

        result.Should().Be(default(CustomRecord));
    }

    private record CustomRecord();
}
namespace EndpointTestDataGenerator.Sample.WebApi;

public record TestDto()
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
}
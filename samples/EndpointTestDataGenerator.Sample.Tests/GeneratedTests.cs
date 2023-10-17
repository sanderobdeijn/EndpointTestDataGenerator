using System.Collections;
using System.Net;
using EndpointTestDataGenerator.Sample.Client;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Refit;

namespace EndpointTestDataGenerator.Sample.Tests;

public class NotAuthenticatedTests
{
    [Theory]
    [ClassData(typeof(NotAuthenticatedTestScenario))]
    public async Task MinimalTest_NotAuthenticated_ReturnUnauthorized(TestScenario scenario)
    {
        // Act
        var exception = await Record.ExceptionAsync(scenario.Act);
        
        // Assert
        exception.Should().BeOfType<ApiException>().Which.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
    
    private class NotAuthenticatedTestScenario : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetGeneratedTestScenarios().GetEnumerator();

        private static IEnumerable<object[]> GetGeneratedTestScenarios()
        {
            var application = CreateApplication();

            var scenarios = application.Include<Program, IApi>().ToList();

            foreach (var scenario in scenarios.Format())
            {
                yield return scenario;
            }
        }

        private static WebApplicationFactory<Program> CreateApplication() =>
            new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder => {});

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


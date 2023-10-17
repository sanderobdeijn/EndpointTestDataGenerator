using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndpointTestDataGenerator.Sample.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TestController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await Task.FromResult(
            Ok(
                Enumerable.Range(1, 5).Select(index => new TestDto
                    {
                        Id = new Guid(),
                        Name = Summaries[index]

                    })
                    .ToArray()));
    }
    
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetTest([FromRoute] Guid? id) => 
        await Task.FromResult(
            Ok(
                new TestDto
                {
                    Id = id,
                    Name = Summaries[0]
                }));

    [HttpPost]
    public async Task<IActionResult> CreateTest([FromBody] TestDto test)
    {
        var result = test with
        {
            Id = new Guid()
        };

        return await Task.FromResult(
            CreatedAtAction(
                nameof(CreateTest),
                new { id = result.Id },
                result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTest([FromRoute] Guid? id, [FromBody] TestDto test) => await Task.FromResult(Ok(test));
        
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTest([FromRoute] Guid? id) => await Task.FromResult(NoContent());
}
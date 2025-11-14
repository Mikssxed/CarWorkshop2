using System.Net;
using System.Threading.Tasks;
using CarWorkshop.mvc.Controllers;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CarWorkshop.mvc.Tests.Controllers;

[TestSubject(typeof(HomeController))]
public class HomeControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HomeControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    [Fact]
    public async Task About_ReturnsViewWithRenderModel()
    {
        // arrange

        var client = _factory.CreateClient();
        
        // act

        var response = await client.GetAsync("/Home/About");
        
        // assert

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();

        content.Should().Contain("<h1 class=\"display-4\">About Car Workshop</h1>");
    }
}
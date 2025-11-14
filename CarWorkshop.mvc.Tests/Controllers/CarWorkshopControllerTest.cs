using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.mvc.Controllers;
using FluentAssertions;
using JetBrains.Annotations;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace CarWorkshop.mvc.Tests.Controllers;

[TestSubject(typeof(CarWorkshopController))]
public class CarWorkshopControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CarWorkshopControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    [Fact]
    public async Task Index_ReturnViewWithExpectedData_ForExistingWorkshops()
    {
        // arrange

        var carWorkshops = new List<CarWorkshopDto>()
        {
            new CarWorkshopDto { Name = "Workshop A" },
            new CarWorkshopDto { Name = "Workshop B" },
            new CarWorkshopDto { Name = "Workshop C" }
        };

        var mediatorMock = new Mock<IMediator>();

        mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(carWorkshops);

        var client = _factory
            .WithWebHostBuilder(builder => builder
                .ConfigureTestServices(services => services
                    .AddScoped(_ => mediatorMock.Object)))
            .CreateClient();
        
        // act

        var response = await client.GetAsync("/CarWorkshop/Index");
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Workshop A");
        content.Should().Contain("Workshop B");
        content.Should().Contain("Workshop C");
    }
}
using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Mappings;
using FluentAssertions;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace CarWorkshop.Application.Tests.Mappings;

[TestSubject(typeof(CarWorkshopMappingProfile))]
public class CarWorkshopMappingProfileTest
{

    [Fact]
    public void MappingProfile_ShouldMapCarWorkshopDtoToCarWorkshop()
    {
        // arrange

        var userContextMock = new Mock<IUserContext>();

        userContextMock.Setup(c => c.GetCurrentUser()).Returns(new CurrentUser("1", "test@example.com", new[] { "Moderator" }));

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));
        
        var mapper = configuration.CreateMapper();

        var dto = new CarWorkshopDto
        {
            City = "Sample City",
            Street = "Sample Street",
            PostalCode = "12345",
            PhoneNumber = "1234567890",
        };
        
        // act
        
        var result = mapper.Map<Domain.Entities.CarWorkshop>(dto);
        
        // assert
        
        result.Should().NotBeNull();
        result.ContactDetails.Should().NotBeNull();
        result.ContactDetails.City.Should().Be(dto.City);
        result.ContactDetails.Street.Should().Be(dto.Street);
        result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
        result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
    }
}
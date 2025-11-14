using System.Collections.Generic;
using System.Security.Claims;
using CarWorkshop.Application.ApplicationUser;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace CarWorkshop.Application.Tests.ApplicationUser;

[TestSubject(typeof(UserContext))]
public class UserContextTest
{

    [Fact]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        // arrange
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Email, "test@example.com"),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.Role, "User")
        };
        
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));
        
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
        {
            User = user
        });
        
        var userContext = new UserContext(httpContextAccessorMock.Object);
        
        // act

        var currentUser = userContext.GetCurrentUser();
       
        // assert
       
        currentUser.Should().NotBeNull();
        currentUser!.Id.Should().Be("1");
        currentUser.Email.Should().Be("test@example.com");
        currentUser.Roles.Should().Contain(new[] { "Admin", "User" });
    }
}
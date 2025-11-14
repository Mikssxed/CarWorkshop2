using System.Collections.Generic;
using CarWorkshop.Application.ApplicationUser;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;

namespace CarWorkshop.Application.Tests.ApplicationUser;

[TestSubject(typeof(CurrentUser))]
public class CurrentUserTest
{

    [Fact]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue()
    {
        // arrange
        
        var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });
        
        // act
        
        var result = currentUser.IsInRole("Admin");
        
        // assert
        
       result.Should().BeTrue();
    }
    
    [Fact]
    public void IsInRole_WithoutMatchingRole_ShouldReturnFalse()
    {
        // arrange
        
        var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });
        
        // act
        
        var result = currentUser.IsInRole("Manager");
        
        // assert
        
        result.Should().BeFalse();
    }
    
    [Fact]
    public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
    {
        // arrange
        
        var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });
        
        // act
        
        var result = currentUser.IsInRole("admin");
        
        // assert
        
        result.Should().BeFalse();
    }
}
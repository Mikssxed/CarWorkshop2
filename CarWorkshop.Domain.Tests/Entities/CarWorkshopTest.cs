using System;
using CarWorkshop.Domain.Entities;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;

namespace CarWorkshop.Domain.Tests.Entities;

[TestSubject(typeof(Domain.Entities.CarWorkshop))]
public class CarWorkshopTest
{

    [Fact]
    public void EncodeName_ShouldSetEncodedName()
    {
        // arrange
        var carWorkshop = new Domain.Entities.CarWorkshop();
        carWorkshop.Name = "My Car Workshop";
        
        // act
        carWorkshop.EncodeName();
        
        // assert
        carWorkshop.EncodedName.Should().Be("my-car-workshop");
    }
    
    [Fact]
    public void EncodeName_ShouldThrowException_WhenNameIsNull()
    {
        // arrange
        var carWorkshop = new Domain.Entities.CarWorkshop();
        
        // act
        Action action = () => carWorkshop.EncodeName();
        
        // assert
        action.Invoking(a => a.Invoke()).Should().Throw<NullReferenceException>();
    }
}
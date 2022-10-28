using NutcacheTest.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
using NutcacheTest.Services;
using NutcacheTest.Entities.Entity;
using NutcacheTest.UnitTests.Fixtures;

namespace NutcacheTest.UnitTests.Systems.Controllers;

public class TestUsersController
{

    private Mock<IUsersService> GetMockUsersService(bool hasUser){
        var mockUsersService = new Mock<IUsersService>();

        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(hasUser ? UsersFixtures.GetTestUsers() : UsersFixtures.GetEmptyTestUsers());

        return mockUsersService;
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUsersServiceExactlyOnce() {
        // Arrange
        var mockUsersService = GetMockUsersService(true);
        var sut = new UsersController(mockUsersService.Object);        
        
        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        mockUsersService
            .Verify(
                service => service.GetAllUsers(),
                Times.Once()
            );
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfUsers() {
        // Arrange
        var mockUsersService = GetMockUsersService(true);

        var sut = new UsersController(mockUsersService.Object);        
        
        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task Get_OnNoUsersFound_Return404() {
        // Arrange
        var mockUsersService = GetMockUsersService(false);

        var sut = new UsersController(mockUsersService.Object);        
        
        // Act
        var result = (NotFoundResult)await sut.Get();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        result.StatusCode.Should().Be(404);
    }

    
}
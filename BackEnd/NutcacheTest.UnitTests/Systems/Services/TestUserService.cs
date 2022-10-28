using Moq;
using FluentAssertions;
using NutcacheTest.Services;
using NutcacheTest.UnitTests.Fixtures;
using NutcacheTest.Repository.Interfaces;

namespace NutcacheTest.UnitTests.Systems.Services;

public class TestUserService
{
    [Fact]
    public async Task GetAllUsers_WhenCalled_InvokesDataBase()
    {
        var mockUsersService = new Mock<IUserRepository>();

        mockUsersService
            .Setup(service => service.Get())
            .ReturnsAsync(UsersFixtures.GetTestUsers());

        // Arrange
        var sut = new UsersService(mockUsersService.Object);

        // Act 
        await sut.GetAllUsers();

        // Assert
        // Verify HTTP request is made!
        mockUsersService
            .Verify(
                service => service.Get(),
                Times.Once()
            );
    }

    [Fact]
    public async Task GetAllUsers_WhenCalled_ReturnListOfUsersOfExpectedSize()
    {
        var mockUsersService = new Mock<IUserRepository>();

        mockUsersService
            .Setup(service => service.Get())
            .ReturnsAsync(UsersFixtures.GetTestUsers());

        // Arrange
        var sut = new UsersService(mockUsersService.Object);

        // Act 
        var result = await sut.GetAllUsers();

        // Assert
        result.Count.Should().Be(UsersFixtures.GetTestUsers().Count);
    }

    [Fact]
    public async Task GetAllUsers_WhenNotFound_ReturnEmptyListOfUsers()
    {
        var mockUsersService = new Mock<IUserRepository>();

        mockUsersService
            .Setup(service => service.Get())
            .ReturnsAsync(UsersFixtures.GetEmptyTestUsers());

        // Arrange
        var sut = new UsersService(mockUsersService.Object);

        // Act 
        var result = await sut.GetAllUsers();

        // Assert
        result.Count.Should().Be(0);
    }
}
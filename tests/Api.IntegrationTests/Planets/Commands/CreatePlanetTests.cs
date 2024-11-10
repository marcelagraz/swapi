using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Application.Planets.Commands.CreatePlanet;

namespace SwApi.Api.IntegrationTests.Planets.Commands;

public class CreatePlanetTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreNull()
    {
        // Arrange
        var command = new CreatePlanetCommand
        {
            Name = null,
            Gravity = null,
            Climate = null
        };

        // Act
        var response = await TestFixture.CreatePlanetAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(3);
    }

    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreEmptyOrNotGreaterThanZero()
    {
        // Arrange
        var command = new CreatePlanetCommand
        {
            Name = string.Empty,
            Gravity = string.Empty,
            Climate = string.Empty
        };

        // Act
        var response = await TestFixture.CreatePlanetAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(3);
    }

    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var command = new CreatePlanetCommand
        {
            Name = "Name",
            Gravity = "Gravity",
            Climate = "Climate"
        };

        // Act
        var response = await TestFixture.CreatePlanetAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

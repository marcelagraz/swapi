using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Application.Planets.Commands.UpdatePlanet;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Planets.Commands;

public class UpdatePlanetTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreNull()
    {
        // Arrange
        var command = new UpdatePlanetCommand
        {
            Id = null,
            Name = null,
            Gravity = null,
            Climate = null,
            ConcurrencyStamp = null
        };

        // Act
        var response = await TestFixture.UpdatePlanetAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(5);
    }

    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreEmptyOrNotGreaterThanZero()
    {
        // Arrange
        var command = new UpdatePlanetCommand
        {
            Id = Guid.Empty,
            Name = string.Empty,
            Gravity = string.Empty,
            Climate = string.Empty,
            ConcurrencyStamp = string.Empty
        };

        // Act
        var response = await TestFixture.UpdatePlanetAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(5);
    }

    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var utcNow = DateTime.UtcNow.ToString("o");

        var planet = new Planet
        {
            Name = "Name",
            Gravity = "Gravity",
            Climate = "Climate",
            Created = utcNow,
            Edited = utcNow
        };

        DbContext.Planets.Add(planet);
        await DbContext.SaveChangesAsync();

        var command = new UpdatePlanetCommand
        {
            Id = planet.Id,
            Name = "Name2",
            Gravity = "Gravity2",
            Climate = "Climate2",
            ConcurrencyStamp = planet.ConcurrencyStamp
        };

        // Act
        var response = await TestFixture.UpdatePlanetAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

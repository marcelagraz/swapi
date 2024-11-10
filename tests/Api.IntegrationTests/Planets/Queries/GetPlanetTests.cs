using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Planets.Commands;

public class GetPlanetTests(TestFixture testFixture) : BaseTests(testFixture)
{
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

        DbContext.Add(planet);
        await DbContext.SaveChangesAsync();

        // Act
        var response = await TestFixture.GetPlanetAsync(planet.Id);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

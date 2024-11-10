using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Planets.Commands;

public class GetAllPlanetTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var utcNow = DateTime.UtcNow.ToString("o");

        var planet1 = new Planet
        {
            Name = "Name",
            Gravity = "Gravity",
            Climate = "Climate",
            Created = utcNow,
            Edited = utcNow
        };

        var planet2 = new Planet
        {
            Name = "Name",
            Gravity = "Gravity",
            Climate = "Climate",
            Created = utcNow,
            Edited = utcNow
        };

        var planet3 = new Planet
        {
            Name = "Name",
            Gravity = "Gravity",
            Climate = "Climate",
            Created = utcNow,
            Edited = utcNow
        };

        DbContext.AddRange(planet1, planet2, planet3);
        await DbContext.SaveChangesAsync();

        // Act
        var response = await TestFixture.GetAllPlanetAsync();

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.Data.Should().HaveCount(3);
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

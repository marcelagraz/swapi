using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Peoples.Commands;

public class GetPeopleTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var planet = new Planet
        {
            Name = "Name",
            Gravity = "Gravity",
            Climate = "Climate"
        };

        DbContext.Planets.Add(planet);
        await DbContext.SaveChangesAsync();

        var utcNow = DateTime.UtcNow.ToString("o");

        var people = new People
        {
            Name = "Name",
            BirthYear = "BirthYear",
            Gender = "Gender",
            HomeworldId = planet.Id,
            Created = utcNow,
            Edited = utcNow
        };

        DbContext.Add(people);
        await DbContext.SaveChangesAsync();

        // Act
        var response = await TestFixture.GetPeopleAsync(people.Id);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

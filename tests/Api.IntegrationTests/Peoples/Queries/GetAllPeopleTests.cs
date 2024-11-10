using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Peoples.Commands;

public class GetAllPeopleTests(TestFixture testFixture) : BaseTests(testFixture)
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

        var people1 = new People
        {
            Name = "Name1",
            BirthYear = "BirthYear1",
            Gender = "Gender1",
            HomeworldId = planet.Id,
            Created = utcNow,
            Edited = utcNow
        };

        var people2 = new People
        {
            Name = "Name2",
            BirthYear = "BirthYear2",
            Gender = "Gender2",
            HomeworldId = planet.Id,
            Created = utcNow,
            Edited = utcNow
        };

        var people3 = new People
        {
            Name = "Name3",
            BirthYear = "BirthYear3",
            Gender = "Gender3",
            HomeworldId = planet.Id,
            Created = utcNow,
            Edited = utcNow
        };

        DbContext.AddRange(people1, people2, people3);
        await DbContext.SaveChangesAsync();

        // Act
        var response = await TestFixture.GetAllPeopleAsync();

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.Data.Should().HaveCount(3);
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

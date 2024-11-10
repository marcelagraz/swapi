using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Application.Peoples.Commands.CreatePeople;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Peoples.Commands;

public class CreatePeopleTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreNull()
    {
        // Arrange
        var command = new CreatePeopleCommand
        {
            Name = null,
            BirthYear = null,
            Gender = null,
            HomeworldId = null
        };

        // Act
        var response = await TestFixture.CreatePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(4);
    }

    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreEmptyOrDontExistInDb()
    {
        // Arrange
        var command = new CreatePeopleCommand
        {
            Name = string.Empty,
            BirthYear = string.Empty,
            Gender = string.Empty,
            HomeworldId = Guid.NewGuid()
        };

        // Act
        var response = await TestFixture.CreatePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(4);
    }

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

        var command = new CreatePeopleCommand
        {
            Name = "Name",
            BirthYear = "BirthYear",
            Gender = "Gender",
            HomeworldId = planet.Id
        };

        // Act
        var response = await TestFixture.CreatePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Application.Films.Commands.DeleteFilm;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Films.Commands;

public class DeletePlanetTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreNull()
    {
        // Arrange
        var command = new DeleteFilmCommand
        {
            Id = null,
            ConcurrencyStamp = null
        };

        // Act
        var response = await TestFixture.DeleteFilmAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(2);
    }

    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreEmptyOrNotGreaterThanZero()
    {
        // Arrange
        var command = new DeleteFilmCommand
        {
            Id = Guid.Empty,
            ConcurrencyStamp = string.Empty
        };

        // Act
        var response = await TestFixture.DeleteFilmAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(2);
    }

    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var film = new Film
        {
            Title = "Title",
            Episode = 1,
            Director = "Director",
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };

        DbContext.Films.Add(film);
        await DbContext.SaveChangesAsync();

        var command = new DeleteFilmCommand
        {
            Id = film.Id,
            ConcurrencyStamp = film.ConcurrencyStamp
        };

        // Act
        var response = await TestFixture.DeleteFilmAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

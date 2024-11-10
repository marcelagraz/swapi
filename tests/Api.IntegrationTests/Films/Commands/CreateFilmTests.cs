using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Application.Films.Commands.CreateFilm;

namespace SwApi.Api.IntegrationTests.Films.Commands;

public class CreateFilmTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreNull()
    {
        // Arrange
        var command = new CreateFilmCommand
        {
            Title = null,
            Episode = null,
            Director = null,
            ReleaseDate = null
        };

        // Act
        var response = await TestFixture.CreateFilmAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(4);
    }

    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreEmptyOrNotGreaterThanZero()
    {
        // Arrange
        var command = new CreateFilmCommand
        {
            Title = string.Empty,
            Episode = -1,
            Director = string.Empty,
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };

        // Act
        var response = await TestFixture.CreateFilmAsync(command);

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
        var command = new CreateFilmCommand
        {
            Title = "Title",
            Episode = 1,
            Director = "Director",
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };

        // Act
        var response = await TestFixture.CreateFilmAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SwApi.Domain.Entities;

namespace SwApi.Infrastructure.Persistence;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<SwApiDbContextInitializer>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class SwApiDbContextInitializer(
    ILogger<SwApiDbContextInitializer> logger,
    SwApiDbContext context,
    TimeProvider timeProvider)
{
    private readonly ILogger<SwApiDbContextInitializer> _logger = logger;
    private readonly SwApiDbContext _context = context;
    private readonly TimeProvider _timeProvider = timeProvider;

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Planets.Any() &&
            !_context.Peoples.Any() &&
            !_context.Films.Any())
        {
            var dateNow = _timeProvider.GetUtcNow().UtcDateTime.ToString("o");

            #region Planets

            var tatooine = new Planet
            {
                Name = "Tatooine",
                Gravity = "1 standard",
                Climate = "arid",
                Created = dateNow,
                Edited = dateNow
            };

            var alderaan = new Planet
            {
                Name = "Alderaan",
                Gravity = "1 standard",
                Climate = "temperate",
                Created = dateNow,
                Edited = dateNow
            };

            var yavinIv = new Planet
            {
                Name = "Yavin IV",
                Gravity = "1 standard",
                Climate = "temperate, tropical",
                Created = dateNow,
                Edited = dateNow
            };

            _context.Planets.AddRange(tatooine, alderaan, yavinIv);

            #endregion Planets

            #region Peoples

            var lukeSkywalker = new People
            {
                Name = "Luke Skywalker",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = tatooine,
                Created = dateNow,
                Edited = dateNow
            };

            var leiaOrgana = new People
            {
                Name = "Leia Organa",
                BirthYear = "19BBY",
                Gender = "female",
                Homeworld = alderaan,
                Created = dateNow,
                Edited = dateNow
            };

            var darthVader = new People
            {
                Name = "Darth Vader",
                BirthYear = "41.9BBY",
                Gender = "male",
                Homeworld = tatooine,
                Created = dateNow,
                Edited = dateNow
            };

            _context.Peoples.AddRange(lukeSkywalker, leiaOrgana, darthVader);

            #endregion Peoples

            #region Films

            var aNewHope = new Film
            {
                Title = "A New Hope",
                Episode = 4,
                Director = "George Lucas",
                ReleaseDate = new DateOnly(1977, 5, 25),
                Characters = [lukeSkywalker, leiaOrgana, darthVader],
                Created = dateNow,
                Edited = dateNow
            };

            var theEmpireStrikesBack = new Film
            {
                Title = "The Empire Strikes Back",
                Episode = 5,
                Director = "Irvin Kershner",
                ReleaseDate = new DateOnly(1980, 5, 21),
                Characters = [lukeSkywalker, leiaOrgana, darthVader],
                Created = dateNow,
                Edited = dateNow
            };

            var returnOfTheJedi = new Film
            {
                Title = "Return of the Jedi",
                Episode = 6,
                Director = "Richard Marquand",
                ReleaseDate = new DateOnly(1983, 5, 25),
                Characters = [lukeSkywalker, leiaOrgana, darthVader],
                Created = dateNow,
                Edited = dateNow
            };

            _context.Films.AddRange(aNewHope, theEmpireStrikesBack, returnOfTheJedi);

            #endregion Films

            await _context.SaveChangesAsync();
        }
    }
}
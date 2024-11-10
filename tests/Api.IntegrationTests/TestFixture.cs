using Ardalis.GuardClauses;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwApi.Api.Common.Responses;
using SwApi.Application.Films.Commands.CreateFilm;
using SwApi.Application.Films.Commands.DeleteFilm;
using SwApi.Application.Films.Commands.UpdateFilm;
using SwApi.Application.Peoples.Commands.CreatePeople;
using SwApi.Application.Peoples.Commands.DeletePeople;
using SwApi.Application.Peoples.Commands.UpdatePeople;
using SwApi.Application.Planets.Commands.CreatePlanet;
using SwApi.Application.Planets.Commands.DeletePlanet;
using SwApi.Application.Planets.Commands.UpdatePlanet;
using SwApi.Domain.Entities;
using System.Net.Http.Json;
using System.Text.Json;

namespace SwApi.Api.IntegrationTests;

public partial class TestFixture : IAsyncLifetime
{
    private const string BaseApiUrl = "/api";

    private SqlServerTestDb _database = null!;
    private CustomWebApplicationFactory _factory = null!;
    private JsonSerializerOptions _options = null!;
    public IServiceScopeFactory ScopeFactory = null!;

    public async Task InitializeAsync()
    {
        await ResetStateAsync();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        _database = new SqlServerTestDb(configuration);
        await _database.InitialiseAsync();

        _factory = new CustomWebApplicationFactory(_database.GetConnection());
        ScopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();

        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task ResetStateAsync()
    {
        if (_database is not null)
            await _database.ResetAsync();
    }

    public Task<BaseResponse<Film>?> GetFilmAsync(Guid id)
    {
        return HttpGetAsync<BaseResponse<Film>?>($"{BaseApiUrl}/films/{id}");
    }

    public Task<BaseResponse<List<Film>>?> GetAllFilmAsync(int pageNumber = 1, int pageSize = 10)
    {
        return HttpGetAsync<BaseResponse<List<Film>>?>(
            $"{BaseApiUrl}/films",
            new Dictionary<string, string?>
            { 
                { "pageNumber", pageNumber.ToString() },
                { "pageSize", pageSize.ToString() }
            });
    }

    public Task<BaseResponse<Film>?> CreateFilmAsync(CreateFilmCommand command)
    {
        return HttpPostAsync<CreateFilmCommand, BaseResponse<Film>?>($"{BaseApiUrl}/films", command);
    }

    public Task<BaseResponse<Film>?> UpdateFilmAsync(UpdateFilmCommand command)
    {
        return HttpPutAsync<UpdateFilmCommand, BaseResponse<Film>?>($"{BaseApiUrl}/films", command);
    }

    public Task<BaseResponse<object>?> DeleteFilmAsync(DeleteFilmCommand command)
    {
        return HttpDeleteAsync<DeleteFilmCommand, BaseResponse<object>?>($"{BaseApiUrl}/films", command);
    }

    public Task<BaseResponse<People>?> GetPeopleAsync(Guid id)
    {
        return HttpGetAsync<BaseResponse<People>?>($"{BaseApiUrl}/peoples/{id}");
    }

    public Task<BaseResponse<List<People>>?> GetAllPeopleAsync(int pageNumber = 1, int pageSize = 10)
    {
        return HttpGetAsync<BaseResponse<List<People>>?>(
            $"{BaseApiUrl}/peoples",
            new Dictionary<string, string?>
            {
                { "pageNumber", pageNumber.ToString() },
                { "pageSize", pageSize.ToString() }
            });
    }

    public Task<BaseResponse<People>?> CreatePeopleAsync(CreatePeopleCommand command)
    {
        return HttpPostAsync<CreatePeopleCommand, BaseResponse<People>?>($"{BaseApiUrl}/peoples", command);
    }

    public Task<BaseResponse<People>?> UpdatePeopleAsync(UpdatePeopleCommand command)
    {
        return HttpPutAsync<UpdatePeopleCommand, BaseResponse<People>?>($"{BaseApiUrl}/peoples", command);
    }

    public Task<BaseResponse<object>?> DeletePeopleAsync(DeletePeopleCommand command)
    {
        return HttpDeleteAsync<DeletePeopleCommand, BaseResponse<object>?>($"{BaseApiUrl}/peoples", command);
    }

    public Task<BaseResponse<Planet>?> GetPlanetAsync(Guid id)
    {
        return HttpGetAsync<BaseResponse<Planet>?>($"{BaseApiUrl}/planets/{id}");
    }

    public Task<BaseResponse<List<Planet>>?> GetAllPlanetAsync(int pageNumber = 1, int pageSize = 10)
    {
        return HttpGetAsync<BaseResponse<List<Planet>>?>(
            $"{BaseApiUrl}/planets",
            new Dictionary<string, string?>
            {
                { "pageNumber", pageNumber.ToString() },
                { "pageSize", pageSize.ToString() }
            });
    }

    public Task<BaseResponse<Planet>?> CreatePlanetAsync(CreatePlanetCommand command)
    {
        return HttpPostAsync<CreatePlanetCommand, BaseResponse<Planet>?>($"{BaseApiUrl}/planets", command);
    }

    public Task<BaseResponse<Planet>?> UpdatePlanetAsync(UpdatePlanetCommand command)
    {
        return HttpPutAsync<UpdatePlanetCommand, BaseResponse<Planet>?>($"{BaseApiUrl}/planets", command);
    }

    public Task<BaseResponse<object>?> DeletePlanetAsync(DeletePlanetCommand command)
    {
        return HttpDeleteAsync<DeletePlanetCommand, BaseResponse<object>?>($"{BaseApiUrl}/planets", command);
    }

    private async Task<TResponse?> HttpGetAsync<TResponse>(string url, IDictionary<string, string?>? queryString = null)
    {
        HttpClient client = _factory.CreateClient();

        url = UpdateUrlWithQueryString(url, queryString);

        var httpResponseMessage = await client.GetAsync(url);

        var response = await ParseResponse<TResponse>(httpResponseMessage);

        return response;
    }

    private async Task<TResponse?> HttpPostAsync<TRequest, TResponse>(
        string url,
        TRequest request,
        IDictionary<string, string?>? queryString = null)
    {
        HttpClient client = _factory.CreateClient();

        url = UpdateUrlWithQueryString(url, queryString);

        var httpResponseMessage = await client.PostAsJsonAsync(url, request);

        var response = await ParseResponse<TResponse>(httpResponseMessage);

        return response;
    }

    private async Task<TResponse?> HttpPutAsync<TRequest, TResponse>(
        string url,
        TRequest request,
        IDictionary<string, string?>? queryString = null)
    {
        HttpClient client = _factory.CreateClient();

        url = UpdateUrlWithQueryString(url, queryString);

        var httpResponseMessage = await client.PutAsJsonAsync(url, request);

        var response = await ParseResponse<TResponse>(httpResponseMessage);

        return response;
    }

    private async Task<TResponse?> HttpDeleteAsync<TRequest, TResponse>(
        string url,
        TRequest request,
        IDictionary<string, string?>? queryString = null)
    {
        HttpClient client = _factory.CreateClient();

        url = UpdateUrlWithQueryString(url, queryString);

        var httpRequestMessage = new HttpRequestMessage
        {
            Content = JsonContent.Create(request),
            Method = HttpMethod.Delete,
            RequestUri = new Uri(url, UriKind.Relative)
        };

        var httpResponseMessage = await client.SendAsync(httpRequestMessage);

        var response = await ParseResponse<TResponse>(httpResponseMessage);

        return response;
    }

    private async Task<TResponse?> ParseResponse<TResponse>(HttpResponseMessage responseMessage)
    {
        Guard.Against.Null(responseMessage);

        TResponse? result = await responseMessage.Content.ReadFromJsonAsync<TResponse>(_options);
        Guard.Against.Null(result);
        return result;
    }

    private string UpdateUrlWithQueryString(string url, IDictionary<string, string?>? queryString)
    {
        if (queryString != null)
        {
            url = QueryHelpers.AddQueryString(url, queryString);
        }

        return url;
    }

    public async Task DisposeAsync()
    {
        await _database.DisposeAsync();
        await _factory.DisposeAsync();
    }
}

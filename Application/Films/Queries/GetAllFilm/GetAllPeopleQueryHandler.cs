﻿using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.GetAllFilm;

public class GetAllFilmQueryHandler(
    IFilmRepository filmRepository) :
    IRequestHandler<GetAllFilmQuery, List<Film>>
{
    private readonly IFilmRepository filmRepository = filmRepository;

    public async Task<List<Film>> Handle(GetAllFilmQuery query, CancellationToken cancellationToken)
    {
        var films = await filmRepository.FindAllAsync(query.PageNumber, query.PageSize, cancellationToken);

        return films;
    }
}

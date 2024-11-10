using SwApi.Application.Common.Repositories;
using SwApi.Application.Common.Validators;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.DeletePeople;

public class DeleteFilmCommandValidator(IPeopleRepository peopleRepository) :
    DeleteCommandValidator<People, IPeopleRepository, DeletePeopleCommand>(peopleRepository)
{
}

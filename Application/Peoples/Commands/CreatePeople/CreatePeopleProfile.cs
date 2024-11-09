using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.CreatePeople;

public class CreatePeopleProfile : Profile
{
    public CreatePeopleProfile()
    {
        CreateMap<CreatePeopleCommand, People>();
    }
}

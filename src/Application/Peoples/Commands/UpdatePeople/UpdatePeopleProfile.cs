using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.UpdatePeople;

public class UpdatePeopleProfile : Profile
{
    public UpdatePeopleProfile()
    {
        CreateMap<UpdatePeopleCommand, People>();
    }
}

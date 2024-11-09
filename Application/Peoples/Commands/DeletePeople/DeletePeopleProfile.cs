using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.DeletePeople;

public class DeletePeopleProfile : Profile
{
    public DeletePeopleProfile()
    {
        CreateMap<DeletePeopleCommand, People>();
    }
}

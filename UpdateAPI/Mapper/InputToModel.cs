using AutoMapper;
using update.Input;
using Infrastructure.Model;

namespace update.Mapper;

public class InputToModel : Profile
{
    public InputToModel()
    {
        CreateMap<CommunityData, Community>();
        CreateMap<ActivityData, Activity>();
        CreateMap<ParticipationData, Participation>();
        CreateMap<UniversityData, University>();
        CreateMap<UserData, User>();
    }
}
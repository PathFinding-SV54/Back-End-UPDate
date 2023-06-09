using AutoMapper;
using update.Input;
using Infrastructure.Model;

namespace update.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<CommunityData, Community>();
        CreateMap<ActivityData, Activity>();
        CreateMap<Participation, ParticipationData>();
        CreateMap<Location, LocationData>();
        CreateMap<Role, RoleData>();
    }
}
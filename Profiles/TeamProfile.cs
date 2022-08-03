using AutoMapper;

namespace SoccerWebAPI.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Entities.Coach, ExternalModels.CoachDTO>();
            CreateMap<ExternalModels.CoachDTO, Entities.Coach>();

            CreateMap<Entities.Team, ExternalModels.TeamDTO>();
            CreateMap<ExternalModels.TeamDTO, Entities.Team>();
        }
    }
}
using SoccerWebAPI.Entities;

namespace SoccerWebAPI.Services.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Team GetTeamDetails(Guid teamId);
    }
}
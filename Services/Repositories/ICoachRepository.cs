using SoccerWebAPI.Entities;

namespace SoccerWebAPI.Services.Repositories
{
    public interface ICoachRepository : IRepository<Coach>
    {
        Coach GetCoachDetails(Guid coachDetails);
    }
}
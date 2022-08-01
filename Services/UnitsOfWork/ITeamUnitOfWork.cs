using SoccerWebAPI.Services.Repositories;

namespace SoccerWebAPI.Services.UnitsOfWork
{
    public interface ITeamUnitOfWork : IDisposable
    {
        ITeamRepository Teams { get; }

        ICoachRepository Coaches { get; }

        int Complete();
    }
}
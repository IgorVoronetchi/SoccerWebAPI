using SoccerWebAPI.Contexts;
using SoccerWebAPI.Services.Repositories;

namespace SoccerWebAPI.Services.UnitsOfWork
{
    public class TeamUnitOfWork : ITeamUnitOfWork
    {
        private readonly TeamsContext _context;
        public TeamUnitOfWork(TeamsContext context, ITeamRepository teams,
            ICoachRepository coaches)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Teams = teams ?? throw new ArgumentNullException(nameof(teams));
            Coaches = coaches ?? throw new ArgumentNullException(nameof(coaches));
        }
        public ITeamRepository Teams { get; }
        public ICoachRepository Coaches { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
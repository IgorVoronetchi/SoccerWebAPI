using Microsoft.EntityFrameworkCore;
using SoccerWebAPI.Contexts;
using SoccerWebAPI.Entities;

namespace SoccerWebAPI.Services.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly TeamsContext _context;
        public TeamRepository(TeamsContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Team GetTeamDetails(Guid teamId)
        {
            return _context.Teams
                .Where(t => t.Id == teamId && (t.Deleted == false || t.Deleted == null))
                .Include(t => t.Coach)
                .Include(t => t.BestPlayer)
                .FirstOrDefault();
        }
    }
}
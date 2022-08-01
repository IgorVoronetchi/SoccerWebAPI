using Microsoft.EntityFrameworkCore;
using SoccerWebAPI.Contexts;
using SoccerWebAPI.Entities;

namespace SoccerWebAPI.Services.Repositories
{
    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        private readonly TeamsContext _context;

        public CoachRepository(TeamsContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        // Metoda ce returneaza datele despre antrenorilor
        public Coach GetCoachDetails(Guid coachId)
        {
            return _context.Coaches
                .Where(c => c.Id == coachId && (c.Deleted == false || c.Deleted == null))
                .Include(c => c.FirstName)
                .Include(c => c.LastName)
                .Include(c => c.Wage)
                .FirstOrDefault();
        }

    }
}
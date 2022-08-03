using SoccerWebAPI.Contexts;
using SoccerWebAPI.Entities;

namespace SoccerWebAPI.Services.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly TeamsContext _context;

        public UserRepository(TeamsContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users
                .Where(u => u.IsAdmin && (u.Deleted == false || u.Deleted == null))
                .ToList();
        }
    }
}
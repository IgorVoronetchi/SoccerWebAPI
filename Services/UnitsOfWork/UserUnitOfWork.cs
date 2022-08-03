using SoccerWebAPI.Contexts;
using SoccerWebAPI.Services.Repositories;

namespace SoccerWebAPI.Services.UnitsOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly TeamsContext _context;
        public UserUnitOfWork(TeamsContext context, IUserRepository users)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }
        public IUserRepository Users { get; }
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
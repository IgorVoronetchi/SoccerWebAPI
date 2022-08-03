using SoccerWebAPI.Entities;

namespace SoccerWebAPI.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
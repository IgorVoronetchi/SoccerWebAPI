using SoccerWebAPI.Services.Repositories;

namespace SoccerWebAPI.Services.UnitsOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}
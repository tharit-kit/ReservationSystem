using ReservationSystem.Helpers.DataAccess;

namespace ReservationSystem.Middlewares.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DataContext Context { get; }
        public Task SaveChangesAsync();
    }
}

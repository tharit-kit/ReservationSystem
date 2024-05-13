using ReservationSystem.Helpers.DataAccess;

namespace ReservationSystem.Middlewares.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly DataContext _context;
        private bool _disposed =  false;

        public UnitOfWork(DataContext context) {
            _context = context;
        }
        public DataContext Context => _context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}

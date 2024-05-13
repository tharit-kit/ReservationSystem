using ReservationSystem.Helpers.DataAccess;

namespace ReservationSystem.Services.User
{
    public class GetUserByEmailService
    {
        private readonly DataContext _context;

        public GetUserByEmailService(DataContext context) { 
            _context = context;
        }

    }
}

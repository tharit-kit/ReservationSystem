namespace ReservationSystem.API.Models.Bases
{
    public abstract class RequestPageBase
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}

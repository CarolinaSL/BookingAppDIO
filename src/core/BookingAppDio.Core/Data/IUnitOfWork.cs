namespace BookingAppDio.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
using TravelBookingFrance.DAL.Entities;

namespace TravelBookingFrance.DAL.Repositories.IRepositories
{
    public interface ITravelRepository : IGenericRepository<Travel>
    {
        Task<IEnumerable<Travel>> GetAllTravelByCustomerIdAsync(int id);

        Task<Travel> GetTravelByIdAsync(int TravelId);
    }
}

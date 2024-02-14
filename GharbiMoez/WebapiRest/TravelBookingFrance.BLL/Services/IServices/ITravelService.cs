using TravelBookingFrance.DAL.Entities;

namespace TravelFrance.Services.IServices
{
    public interface ITravelService
    {
        Task<IEnumerable<Travel>> GetAllTravelByCustomerIdService(int id);
        Task<Travel> GetTravelByIdService(int TravelId);
    }
}

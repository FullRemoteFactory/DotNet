using TravelBookingFrance.DAL.Entities;
using TravelBookingFrance.DAL.Repositories.IRepositories;
using TravelFrance.Services.IServices;

namespace TravelBookingFrance.BLL.Services
{
    public class TravelService : ITravelService
    {

        private readonly ITravelRepository _travelRepository;
        public TravelService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }
        public async Task<IEnumerable<Travel>> GetAllTravelByCustomerIdService(int id)
        {
            return await _travelRepository.GetAllTravelByCustomerIdAsync(id);
        }

        public async Task<Travel> GetTravelByIdService(int TravelId)
        {
            return await _travelRepository.GetTravelByIdAsync(TravelId);
        }
    }
}

using TravelBookingFrance.DAL.Entities;

namespace TravelFrance.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductByTravelIdService(int id);
    }
}

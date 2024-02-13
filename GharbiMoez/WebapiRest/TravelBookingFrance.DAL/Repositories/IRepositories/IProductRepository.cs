using TravelBookingFrance.DAL.Entities;

namespace TravelBookingFrance.DAL.Repositories.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductByTravelIdAsync(int id);
    }
}

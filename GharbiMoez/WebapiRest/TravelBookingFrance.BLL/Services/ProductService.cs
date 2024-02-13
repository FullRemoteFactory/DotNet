using TravelBookingFrance.DAL.Entities;
using TravelBookingFrance.DAL.Repositories.IRepositories;
using TravelFrance.Services.IServices;

namespace TravelBookingFrance.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetAllProductByTravelIdService(int id)
        {
            return await _productRepository.GetAllProductByTravelIdAsync(id);
        }
    }
}

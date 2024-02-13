using Microsoft.EntityFrameworkCore;
using TravelBookingFrance.DAL.DataContext;
using TravelBookingFrance.DAL.Entities;
using TravelBookingFrance.DAL.Repositories.IRepositories;

namespace TravelBookingFrance.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        #region Fields
        private DbSet<Product> Produits;
        #endregion

        #region Constructors
        public ProductRepository(DataAppContext dbContext) : base(dbContext)
        {
            Produits = dbContext.Set<Product>();
        }


        #endregion

        #region Handle Functions
        public async Task<IEnumerable<Product>> GetAllProductByTravelIdAsync(int id)
        {
            IEnumerable<Product> query = await Produits.Where(x => x.TravelProducts.Any(x => x.TravelId == id)).Include(x => x.Photos).ToListAsync();

            return query;


        }

        #endregion
    }
}

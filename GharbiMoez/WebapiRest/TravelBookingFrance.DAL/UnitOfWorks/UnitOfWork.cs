using TravelBookingFrance.DAL.DataContext;
using TravelBookingFrance.DAL.Repositories;
using TravelBookingFrance.DAL.Repositories.IRepositories;

namespace TravelBookingFrance.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataAppContext _context;

        public IProductRepository Products { get; private set; }
        public ITravelRepository Travels { get; private set; }


        public UnitOfWork(DataAppContext context)
        {
            _context = context;

            Products = new ProductRepository(context);
            Travels = new TravelRepository(context);

        }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}

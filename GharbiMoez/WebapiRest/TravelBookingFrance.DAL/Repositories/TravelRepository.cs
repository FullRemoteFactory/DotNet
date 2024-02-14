using Microsoft.EntityFrameworkCore;
using TravelBookingFrance.DAL.DataContext;
using TravelBookingFrance.DAL.Entities;
using TravelBookingFrance.DAL.Repositories.IRepositories;

namespace TravelBookingFrance.DAL.Repositories
{

    public class TravelRepository : GenericRepository<Travel>, ITravelRepository
    {
        #region Fields
        private DbSet<Travel> Dossiers;
        private readonly DataAppContext _appContext;
        #endregion

        #region Constructors
        public TravelRepository(DataAppContext dbContext) : base(dbContext)
        {
            _appContext = dbContext;
            Dossiers = dbContext.Travels;
        }


        #endregion

        #region Handle Functions
        public async Task<IEnumerable<Travel>> GetAllTravelByCustomerIdAsync(int id)
        {

            /*var query = await _appContext.Travels
             .Where(x => x.CustomerId == id)
             .ToListAsync();

            return query;*/
            IEnumerable<Travel> query = await _appContext.Travels.Where(x => x.CustomerId == id).Include(x => x.Flight).Include(x => x.TripType).Include(x => x.TActivities).ThenInclude(x => x.Activite).Include(x => x.TravelProducts).ThenInclude(x => x.Product).ThenInclude(x => x.Photos).AsNoTracking().ToListAsync();
            return query;

        }

        public async Task<Travel> GetTravelByIdAsync(int TravelId)
        {
            Travel query = await _appContext.Travels.Where(x => x.TravelId == TravelId).Include(x => x.Flight).Include(x => x.TripType).Include(x => x.TActivities).ThenInclude(x => x.Activite).Include(x => x.TravelProducts).ThenInclude(x => x.Product).ThenInclude(x => x.Photos).AsNoTracking().FirstOrDefaultAsync();
            return query;
        }
        #endregion
    }
}

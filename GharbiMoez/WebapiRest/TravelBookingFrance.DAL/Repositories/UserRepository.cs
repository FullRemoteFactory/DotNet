using aspnetcore.ntier.DAL.Repositories.IRepositories;
using TravelBookingFrance.DAL.DataContext;
using TravelBookingFrance.DAL.Entities;

namespace TravelBookingFrance.DAL.Repositories;

public class UserRepository : GenericRepository<Customer>, IUserRepository
{
    private readonly DataAppContext _DataAppContext;
    public UserRepository(DataAppContext DataAppContext) : base(DataAppContext)
    {
        _DataAppContext = DataAppContext;
    }

    public async Task<Customer> UpdateUserAsync(Customer user)
    {
        _ = _DataAppContext.Update(user);

        // Ignore password property update for user
        _DataAppContext.Entry(user).Property(x => x.Password).IsModified = false;

        await _DataAppContext.SaveChangesAsync();
        return user;
    }
}

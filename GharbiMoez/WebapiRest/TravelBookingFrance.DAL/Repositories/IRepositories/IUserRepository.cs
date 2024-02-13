using TravelBookingFrance.DAL.Entities;
using TravelBookingFrance.DAL.Repositories.IRepositories;

namespace aspnetcore.ntier.DAL.Repositories.IRepositories;

public interface IUserRepository : IGenericRepository<Customer>
{
    Task<Customer> UpdateUserAsync(Customer user);
}

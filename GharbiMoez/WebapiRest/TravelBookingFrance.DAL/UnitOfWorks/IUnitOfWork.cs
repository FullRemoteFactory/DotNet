using TravelBookingFrance.DAL.Repositories.IRepositories;

namespace TravelBookingFrance.DAL.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ITravelRepository Travels { get; }

        Task<int> Complete();
    }
}

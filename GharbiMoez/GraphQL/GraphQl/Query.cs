namespace TravelBookingGraphQl.GraphQl
{
    public class Query
    {
        private readonly Resolver _resolver;

        public Query(Resolver resolver)
        {
            _resolver = resolver;
        }
        public async Task<LoginResponse> Login(string username, string password)
        {
            return await _resolver.Login(username, password);
        }

        public async Task<IEnumerable<Product>> GetAllProductsByTravelId(int travelId)
        {
            return await _resolver.GetAllProductsByTravelId(travelId);
        }

        public async Task<IEnumerable<Travel>> GetAllTravelByCustomerId(int customerId)
        {
            return await _resolver.GetAllTravelByCustomerId(customerId);
        }
        public async Task<UserInfo> GetUserInformationById(int UserId)
        {
            return await _resolver.GetUserInformationById(UserId);
        }
    }
}

using Newtonsoft.Json;

namespace TravelBookingGraphQl.GraphQl
{
    public class Resolver
    {
        private readonly HttpClient _httpClient;
        /*public string Baseurl = "";*/
        public Resolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> Login(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5277/api/v1/Auth/login", new { username, password });
            // var response = await _httpClient.PostAsJsonAsync("http://host.docker.internal:5277/api/v1/Auth/login", new { username, password });
            response.EnsureSuccessStatusCode();
            var loginResponse = await response.Content.ReadAsAsync<LoginResponse>();
            return loginResponse;
        }

        public async Task<IEnumerable<Product>> GetAllProductsByTravelId(int travelId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5277/api/Product/GetAllProductByTravelId?TravelId={travelId}");
            //var response = await _httpClient.GetAsync($"http://host.docker.internal:800/api/Product/GetAllProductByTravelId?TravelId={travelId}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ApiResponse<Product>>(responseBody);


            if (responseObject != null && responseObject.Data != null)
            {
                var travels = responseObject.Data;
                return travels;
            }
            else
            {

                return null;
            }
        }
        public async Task<UserInfo> GetUserInformationById(int UserId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5277/api/v1/User/getuser?userId={UserId}");
            // var response = await _httpClient.GetAsync($"http://host.docker.internal:800/api/v1/User/getuser?userId={UserId}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<UserInfo>(responseBody);


            if (responseObject != null)
            {
                var travels = responseObject;
                return travels;
            }
            else
            {


                return null;
            }
        }
        public async Task<IEnumerable<Travel>> GetAllTravelByCustomerId(int customerId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5277/api/Travel/GetAllTravelByCustomerId?CustomerId={customerId}");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ApiResponse<Travel>>(responseBody);


            if (responseObject != null && responseObject.Data != null)
            {
                var travels = responseObject.Data;
                return travels;
            }
            else
            {


                return null;
            }
        }
    }
}
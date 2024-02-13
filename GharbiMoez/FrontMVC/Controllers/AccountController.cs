using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc;
using TravelBookingFrance.FrontMVC.Models;

namespace TravelBookingFrance.FrontMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly GraphQLHttpClient _client;
        public AccountController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        // Méthode pour récupérer les informations de profil de l'utilisateur
        private async Task<UserInfo> GetUserProfile(int UserId)
        {
            var _client1 = new GraphQLHttpClient("http://localhost:5016/graphql", new NewtonsoftJsonSerializer());
            var query2 = @"
query ($UserId: Int!) {
    userInformationById(userId: 1) {
        username,
        email,
        busPhone,
        prov,
        postal,
        country,
        city
    }
}";

            var variables = new { UserId = 1 };
            var response = await _client1.SendQueryAsync<dynamic>(query2, variables);

            var userProfileData = response.Data.userInformationById;

            var userProfile = new UserInfo
            {
                Username = userProfileData.username,
                Email = userProfileData.email,
                BusPhone = userProfileData.busPhone,
                Prov = userProfileData.prov,
                Postal = userProfileData.postal,
                Country = userProfileData.country,
                City = userProfileData.city
            };

            return userProfile;
        }

        // Méthode Login qui appelle GetUserProfile avec le UserId
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var _client2 = new GraphQLHttpClient("http://localhost:5016/graphql", new NewtonsoftJsonSerializer());

            var query = @"
    query ($username: String!, $password: String!) {
        login(username: $username, password: $password) {
            surname,
            userId,
            isAuthenticated
        }
    }";

            var variables = new { username, password };
            var response = await _client2.SendQueryAsync<dynamic>(query, variables);

            var userInfo = new LoginResponse
            {
                UserId = response.Data.login.userId,
                Username = username,
                Surname = response.Data.login.surname,
                IsAuthenticated = response.Data.login.isAuthenticated
            };

            if (userInfo.IsAuthenticated)
            {
                int id = userInfo.UserId;
                var userProfile = await GetUserProfile(id);

                return View("Profile", userProfile);
            }

            return View("Profile");
        }
        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}

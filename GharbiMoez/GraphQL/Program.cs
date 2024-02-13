using HotChocolate.AspNetCore;
using TravelBookingGraphQl.GraphQl;

namespace TravelBookingGraphQl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient<Resolver>();

            builder.Services.AddGraphQLServer()
                    .AddQueryType<Query>()
                    .AddType<LoginResponse>() // Ajoutez cette ligne
                    .AddType<ActivityDTO>()
                    .AddType<Product>()
                    .AddType<Travel>()
                    .AddType<UserInfo>()
                    .AddResolver<Resolver>()
                    ;
            var app = builder.Build();

            /*    // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {


                }*/

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseRouting();

            app.MapGraphQL();

            // Activation de GraphQL Playground
            app.UsePlayground();
            app.Run();
        }
    }
}

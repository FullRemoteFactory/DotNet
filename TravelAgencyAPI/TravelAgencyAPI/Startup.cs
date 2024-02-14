using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;

namespace TravelAgencyAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Cette méthode configure les services utilisés par l'application.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddGraphQLServer()
                    .AddQueryType<GraphQL.QueryType>()
                    .AddType<GraphQL.ClientType>()  // Ajoutez d'autres types GraphQL si nécessaire
                    .AddType<GraphQL.DossierType>();  // Ajoutez d'autres types GraphQL si nécessaire
        }

        // Cette méthode configure l'application et les middlewares.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

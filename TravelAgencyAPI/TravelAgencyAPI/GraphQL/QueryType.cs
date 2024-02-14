using HotChocolate.Types;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.GraphQL
{
    public class QueryType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("client")
                .Argument("id", a => a.Type<NonNullType<IntType>>())
                .Type<ClientType>()
                .Resolve(context =>
                {
                    // Appelez votre API REST pour récupérer le client par ID
                    int clientId = context.ArgumentValue<int>("id");
                    // Exemple de logique pour récupérer le client
                    return new Client { Id = clientId, FirstName = "John", LastName = "Doe", Address = "123 Main St", DateOfBirth = new System.DateTime(1990, 1, 1) };
                });

            // Définissez d'autres champs et résolveurs pour les dossiers et les produits
        }
    }

    public class ClientType : ObjectType<Client>
    {
        protected override void Configure(IObjectTypeDescriptor<Client> descriptor)
        {
            descriptor.Field(c => c.Id);
            descriptor.Field(c => c.FirstName);
            descriptor.Field(c => c.LastName);
            descriptor.Field(c => c.Address);
            descriptor.Field(c => c.DateOfBirth);
        }
    }

    // Définissez d'autres types pour les dossiers et les produits de manière similaire
}

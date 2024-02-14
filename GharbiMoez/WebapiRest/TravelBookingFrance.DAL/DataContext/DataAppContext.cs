using Microsoft.EntityFrameworkCore;
using TravelBookingFrance.DAL.Entities;

namespace TravelBookingFrance.DAL.DataContext
{
    public class DataAppContext : DbContext
    {
        public DataAppContext(DbContextOptions<DataAppContext> options) : base(options) { }

        public DbSet<Customer> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<TActivity> TActivities { get; set; }

        public DbSet<Activite> Activities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                 new Customer
                 {
                     UserId = 1,
                     Username = "johndoe",
                     Password = "123",
                     Name = "John",
                     Country = "France",
                     BusPhone = "5588774123",
                     Address = "Astra.BellaVita",
                     Surname = "Doe",
                     City = "Monaco",
                     Prov = "Paris",
                     Postal = "1234444",
                     HomePhone = "998123445855",
                     Email = "johndoe@gmail.com",
                 },
                 new Customer
                 {
                     UserId = 5,
                     Username = "Alex Martin",
                     Password = "123",
                     Name = "Alex",
                     Country = "France",
                     BusPhone = "5588774123",
                     Address = "Astra.BellaVita",
                     Surname = "Martin",
                     City = "Alexandria",
                     Prov = "Egypte",
                     Postal = "554123",
                     HomePhone = "8555474123",
                     Email = "Alex@gmail.com",
                 },
                  new Customer
                  {
                      UserId = 2,
                      Username = "Rachelle duboit",
                      Password = "123",
                      Country = "France",
                      BusPhone = "5588774123",
                      Address = "Astra.BellaVita",
                      Name = "Rachelle",
                      Surname = "duboit",
                      City = "Alexandria",
                      Prov = "Egypte",
                      Postal = "885885123",
                      HomePhone = "5585474123",

                      Email = "Rachelle.duboit@gmail.com",
                  },
                   new Customer
                   {
                       UserId = 3,
                       Username = "Franc Foureaux",
                       Password = "123",
                       Name = "Franc",
                       Country = "France",
                       BusPhone = "5588774123",
                       Address = "Astra.BellaVita",
                       Surname = "Foureaux",
                       City = "Alexandria",
                       Prov = "Egypte",
                       Postal = "885885123",
                       HomePhone = "5585474123",


                       Email = "Franc.Foureaux@gmail.com",
                   },
                    new Customer
                    {
                        UserId = 4,
                        Username = "marcell million",
                        Password = "123",
                        Name = "marcell",
                        Country = "France",
                        BusPhone = "5588774123",
                        Address = "Astra.BellaVita",
                        Surname = "million",
                        City = "123",
                        Prov = "",
                        Postal = "123",
                        HomePhone = "123",
                        Email = "marcell.million@gmail.com",
                    }
             );
            modelBuilder.Entity<Travel>().HasData(
                new Travel
                {
                    TravelId = 1,
                    UrlTravelImage = "destination-5.jpg",
                    TravelDate = "2024-01-10T00:00:00",
                    TravelName = "Marrakech_sejour",
                    Destination = "Maghreb",
                    DepartureDate = "2024-02-15T00:00:00",
                    DepartureAirport = "Paris aeroport",
                    CustomerId = 1,
                    TripTypeId = 1,
                    FlightId = 1,

                },
                 new Travel
                 {
                     TravelId = 2,
                     UrlTravelImage = "destination-4.jpg",
                     TravelDate = "2024-01-10T00:00:00",
                     TravelName = "Tunis_Séjour",
                     Destination = "Tunis",
                     DepartureDate = "2024-02-15T00:00:00",
                     DepartureAirport = "Paris aeroport",
                     CustomerId = 1,
                     TripTypeId = 1,
                     FlightId = 2,

                 },
                  new Travel
                  {
                      TravelId = 3,
                      UrlTravelImage = "destination-3.jpg",
                      TravelDate = "2024-02-10T00:00:00",
                      TravelName = "Barcelone_Sejour",
                      Destination = "Espagne",
                      DepartureDate = "2024-02-15T00:00:00",
                      DepartureAirport = "Paris aeroport",
                      CustomerId = 3,
                      TripTypeId = 1,
                      FlightId = 3,

                  },
                   new Travel
                   {
                       TravelId = 4,
                       UrlTravelImage = "destination-2.jpg",
                       TravelDate = "2024-02-10T00:00:00",
                       TravelName = "Cairo_Sejour",
                       Destination = "Egypte",
                       DepartureDate = "2024-02-15T00:00:00",
                       DepartureAirport = "Paris aeroport",
                       CustomerId = 1,
                       TripTypeId = 1,
                       FlightId = 4,

                   },
                    new Travel
                    {
                        TravelId = 5,
                        UrlTravelImage = "destination-1.jpg",
                        TravelDate = "2024-02-10T00:00:00",
                        TravelName = "Manhatan_Sejour",
                        Destination = "Manhatan",
                        DepartureDate = "2024-02-15T00:00:00",
                        DepartureAirport = "Paris aeroport",
                        CustomerId = 1,
                        TripTypeId = 1,
                        FlightId = 1,

                    }


            );
            modelBuilder.Entity<TripType>().HasData(
               new TripType
               {
                   TtId = 1,
                   Ttname = "Trip Business",
                   TtDescription = "Description of the trip Business",

               },
               new TripType
               {
                   TtId = 2,
                   Ttname = "Trip Family",
                   TtDescription = "Description of the trip Family",

               }


           );
            modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                ProdId = 1,
                ProdName = "Golden Tulip",
                ProdDescription = "Hotel Description",
                Address = "Hotel1 Address",
                Stars = 5,
                IsPetFriendly = true,
            },
              new Hotel
              {
                  ProdId = 2,
                  ProdName = "Movenpick",
                  ProdDescription = "Hotel Description",
                  Address = "Hotel2 Address",
                  Stars = 5,
                  IsPetFriendly = true,
              }


         );
            modelBuilder.Entity<Car>().HasData(
           new Car
           {
               ProdId = 3,
               ProdName = "BMW",
               ProdDescription = "Car Description",
               Brand = "Brand Name",
               Model = "Model Name",
               Year = 2022,
               PassengerCapacity = 5,
           },
                  new Car
                  {
                      ProdId = 4,
                      ProdName = "Range Rover",
                      ProdDescription = "Car Description",
                      Brand = "Brand Name",
                      Model = "Model Name",
                      Year = 2022,
                      PassengerCapacity = 5,
                  }

        );
            /*     modelBuilder.Entity<Product>().HasData(
                   new Hotel
                   {
                       ProdId = 1,
                       ProdName = "Golden Tulip",
                       ProdDescription = "Hotel Description",
                       Address = "Hotel1 Address",
                       Stars = 5,
                       IsPetFriendly = true,
                   },
                  new Hotel
                  {
                      ProdId = 2,
                      ProdName = "Movenpick",
                      ProdDescription = "Hotel Description",
                      Address = "Hotel2 Address",
                      Stars = 5,
                      IsPetFriendly = true,
                  },
                  new Car
                  {
                      ProdId = 2,
                      ProdName = "BMW",
                      ProdDescription = "Car Description",
                      Brand = "Brand Name",
                      Model = "Model Name",
                      Year = 2022,
                      PassengerCapacity = 5,
                  },
                  new Car
                  {
                      ProdId = 2,
                      ProdName = "Range Rover",
                      ProdDescription = "Car Description",
                      Brand = "Brand Name",
                      Model = "Model Name",
                      Year = 2022,
                      PassengerCapacity = 5,
                  }

               );*/
            modelBuilder.Entity<Flight>().HasData(
          new Flight
          {
              FlightId = 1,
              FlightNumber = "ABC123",
              CompanyName = "TUNISAIR",
              DateOfDepart = new DateTime(),
              DateOfArrival = new DateTime(),
              SeatNumber = "12A",
          },
          new Flight
          {
              FlightId = 2,
              FlightNumber = "ABC123",
              CompanyName = "AIRFRANCE",
              DateOfDepart = new DateTime(),
              DateOfArrival = new DateTime(),
              SeatNumber = "12A",
          },
          new Flight
          {
              FlightId = 3,
              FlightNumber = "ABC123",
              CompanyName = "TUNISAIR",
              DateOfDepart = new DateTime(),
              DateOfArrival = new DateTime(),
              SeatNumber = "12A",
          },
          new Flight
          {
              FlightId = 4,
              FlightNumber = "ABC123",
              CompanyName = "TUNISAIR",
              DateOfDepart = new DateTime(),
              DateOfArrival = new DateTime(),
              SeatNumber = "12A",
          },
          new Flight
          {
              FlightId = 5,
              FlightNumber = "ABC123",
              CompanyName = "AIRFRANCE",
              DateOfDepart = new DateTime(),
              DateOfArrival = new DateTime(),
              SeatNumber = "12A",
          }


      );

            modelBuilder.Entity<TravelProduct>().HasData(
    new TravelProduct
    {
        TravelProductId = 1,
        TravelId = 1,
        ProductId = 1,

    },
    new TravelProduct
    {
        TravelProductId = 2,
        TravelId = 1,
        ProductId = 3,

    },
    new TravelProduct
    {
        TravelProductId = 3,
        TravelId = 1,
        ProductId = 2,

    }


);
            modelBuilder.Entity<Photo>().HasData(
    new Photo
    {
        PhotoId = 1,

        ProductId = 1,
        Url = "car1.jpeg"

    },
    new Photo
    {
        PhotoId = 2,

        ProductId = 1,
        Url = "car2.jpeg"

    },
    new Photo
    {
        PhotoId = 3,

        ProductId = 1,
        Url = "car3.jpeg"

    },
    new Photo
    {
        PhotoId = 4,

        ProductId = 1,
        Url = "car4.jpeg"

    }





);
            modelBuilder.Entity<Activite>().HasData(
              new Activite
              {
                  ActivityId = 1,
                  Nom = "activite 1",
                  Lieu = "activite 1",
                  Durée = 3,
                  Prix = 500,
                  UrlImageAct = "activite 1"

              },
              new Activite
              {
                  ActivityId = 2,
                  Nom = "activite 1",
                  Lieu = "activite 1",
                  Durée = 3,
                  Prix = 500,
                  UrlImageAct = "activite 1"

              },
              new Activite
              {
                  ActivityId = 3,
                  Nom = "activite 1",
                  Lieu = "activite 1",
                  Durée = 3,
                  Prix = 500,
                  UrlImageAct = "activite 1"

              },
               new Activite
               {
                   ActivityId = 4,
                   Nom = "activite 1",
                   Lieu = "activite 1",
                   Durée = 3,
                   Prix = 500,
                   UrlImageAct = "activite 1"

               },
                new Activite
                {
                    ActivityId = 5,
                    Nom = "activite 1",
                    Lieu = "activite 1",
                    Durée = 3,
                    Prix = 500,
                    UrlImageAct = "activite 1"

                }


          );
            modelBuilder.Entity<TActivity>().HasData(
    new TActivity
    {
        TravelActivityId = 1,
        TravelId = 1,
        ActivityId = 1,

    },
    new TActivity
    {
        TravelActivityId = 2,
        TravelId = 1,
        ActivityId = 2,

    },
    new TActivity
    {
        TravelActivityId = 3,
        TravelId = 1,
        ActivityId = 3,

    }


);

        }
    }
}
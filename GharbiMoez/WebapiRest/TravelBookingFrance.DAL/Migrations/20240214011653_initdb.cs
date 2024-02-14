using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelBookingFrance.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Lieu = table.Column<string>(type: "TEXT", nullable: false),
                    Durée = table.Column<int>(type: "INTEGER", nullable: false),
                    Prix = table.Column<decimal>(type: "TEXT", nullable: false),
                    UrlImageAct = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdName = table.Column<string>(type: "TEXT", nullable: false),
                    ProdDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: true),
                    PassengerCapacity = table.Column<int>(type: "INTEGER", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Stars = table.Column<int>(type: "INTEGER", nullable: true),
                    IsPetFriendly = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.ProdId);
                });

            migrationBuilder.CreateTable(
                name: "TripType",
                columns: table => new
                {
                    TtId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ttname = table.Column<string>(type: "TEXT", nullable: false),
                    TtDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripType", x => x.TtId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Prov = table.Column<string>(type: "TEXT", nullable: true),
                    Postal = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    HomePhone = table.Column<string>(type: "TEXT", nullable: true),
                    BusPhone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Vol",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlightNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfDepart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfArrival = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SeatNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vol", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Produit_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produit",
                        principalColumn: "ProdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DossierVoyage",
                columns: table => new
                {
                    TravelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TravelDate = table.Column<string>(type: "TEXT", nullable: true),
                    TravelName = table.Column<string>(type: "TEXT", nullable: false),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    DepartureDate = table.Column<string>(type: "TEXT", nullable: true),
                    DepartureAirport = table.Column<string>(type: "TEXT", nullable: false),
                    UrlTravelImage = table.Column<string>(type: "TEXT", nullable: false),
                    Prix = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    TripTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlightId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierVoyage", x => x.TravelId);
                    table.ForeignKey(
                        name: "FK_DossierVoyage_TripType_TripTypeId",
                        column: x => x.TripTypeId,
                        principalTable: "TripType",
                        principalColumn: "TtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DossierVoyage_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_DossierVoyage_Vol_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Vol",
                        principalColumn: "FlightId");
                });

            migrationBuilder.CreateTable(
                name: "TActivities",
                columns: table => new
                {
                    TravelActivityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TravelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TActivities", x => x.TravelActivityId);
                    table.ForeignKey(
                        name: "FK_TActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TActivities_DossierVoyage_TravelId",
                        column: x => x.TravelId,
                        principalTable: "DossierVoyage",
                        principalColumn: "TravelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelProduct",
                columns: table => new
                {
                    TravelProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TravelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelProduct", x => x.TravelProductId);
                    table.ForeignKey(
                        name: "FK_TravelProduct_DossierVoyage_TravelId",
                        column: x => x.TravelId,
                        principalTable: "DossierVoyage",
                        principalColumn: "TravelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelProduct_Produit_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produit",
                        principalColumn: "ProdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Durée", "Lieu", "Nom", "Prix", "UrlImageAct" },
                values: new object[,]
                {
                    { 1, 3, "activite 1", "activite 1", 500m, "activite 1" },
                    { 2, 3, "activite 1", "activite 1", 500m, "activite 1" },
                    { 3, 3, "activite 1", "activite 1", 500m, "activite 1" },
                    { 4, 3, "activite 1", "activite 1", 500m, "activite 1" },
                    { 5, 3, "activite 1", "activite 1", 500m, "activite 1" }
                });

            migrationBuilder.InsertData(
                table: "Produit",
                columns: new[] { "ProdId", "Address", "Discriminator", "IsPetFriendly", "ProdDescription", "ProdName", "Stars" },
                values: new object[,]
                {
                    { 1, "Hotel1 Address", "Hotel", true, "Hotel Description", "Golden Tulip", 5 },
                    { 2, "Hotel2 Address", "Hotel", true, "Hotel Description", "Movenpick", 5 }
                });

            migrationBuilder.InsertData(
                table: "Produit",
                columns: new[] { "ProdId", "Brand", "Discriminator", "Model", "PassengerCapacity", "ProdDescription", "ProdName", "Year" },
                values: new object[,]
                {
                    { 3, "Brand Name", "Car", "Model Name", 5, "Car Description", "BMW", 2022 },
                    { 4, "Brand Name", "Car", "Model Name", 5, "Car Description", "Range Rover", 2022 }
                });

            migrationBuilder.InsertData(
                table: "TripType",
                columns: new[] { "TtId", "TtDescription", "Ttname" },
                values: new object[,]
                {
                    { 1, "Description of the trip Business", "Trip Business" },
                    { 2, "Description of the trip Family", "Trip Family" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "BusPhone", "City", "Country", "Email", "HomePhone", "Name", "Password", "Postal", "Prov", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, "Astra.BellaVita", "5588774123", "Monaco", "France", "johndoe@gmail.com", "998123445855", "John", "123", "1234444", "Paris", "Doe", "johndoe" },
                    { 2, "Astra.BellaVita", "5588774123", "Alexandria", "France", "Rachelle.duboit@gmail.com", "5585474123", "Rachelle", "123", "885885123", "Egypte", "duboit", "Rachelle duboit" },
                    { 3, "Astra.BellaVita", "5588774123", "Alexandria", "France", "Franc.Foureaux@gmail.com", "5585474123", "Franc", "123", "885885123", "Egypte", "Foureaux", "Franc Foureaux" },
                    { 4, "Astra.BellaVita", "5588774123", "123", "France", "marcell.million@gmail.com", "123", "marcell", "123", "123", "", "million", "marcell million" },
                    { 5, "Astra.BellaVita", "5588774123", "Alexandria", "France", "Alex@gmail.com", "8555474123", "Alex", "123", "554123", "Egypte", "Martin", "Alex Martin" }
                });

            migrationBuilder.InsertData(
                table: "Vol",
                columns: new[] { "FlightId", "CompanyName", "DateOfArrival", "DateOfDepart", "FlightNumber", "SeatNumber" },
                values: new object[,]
                {
                    { 1, "TUNISAIR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC123", "12A" },
                    { 2, "AIRFRANCE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC123", "12A" },
                    { 3, "TUNISAIR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC123", "12A" },
                    { 4, "TUNISAIR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC123", "12A" },
                    { 5, "AIRFRANCE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC123", "12A" }
                });

            migrationBuilder.InsertData(
                table: "DossierVoyage",
                columns: new[] { "TravelId", "CustomerId", "DepartureAirport", "DepartureDate", "Destination", "FlightId", "Prix", "TravelDate", "TravelName", "TripTypeId", "UrlTravelImage" },
                values: new object[,]
                {
                    { 1, 1, "Paris aeroport", "2024-02-15T00:00:00", "Maghreb", 1, 0, "2024-01-10T00:00:00", "Marrakech_sejour", 1, "destination-5.jpg" },
                    { 2, 1, "Paris aeroport", "2024-02-15T00:00:00", "Tunis", 2, 0, "2024-01-10T00:00:00", "Tunis_Séjour", 1, "destination-4.jpg" },
                    { 3, 3, "Paris aeroport", "2024-02-15T00:00:00", "Espagne", 3, 0, "2024-02-10T00:00:00", "Barcelone_Sejour", 1, "destination-3.jpg" },
                    { 4, 1, "Paris aeroport", "2024-02-15T00:00:00", "Egypte", 4, 0, "2024-02-10T00:00:00", "Cairo_Sejour", 1, "destination-2.jpg" },
                    { 5, 1, "Paris aeroport", "2024-02-15T00:00:00", "Manhatan", 1, 0, "2024-02-10T00:00:00", "Manhatan_Sejour", 1, "destination-1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PhotoId", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "car1.jpeg" },
                    { 2, 1, "car2.jpeg" },
                    { 3, 1, "car3.jpeg" },
                    { 4, 1, "car4.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "TActivities",
                columns: new[] { "TravelActivityId", "ActivityId", "TravelId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "TravelProduct",
                columns: new[] { "TravelProductId", "ProductId", "TravelId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DossierVoyage_CustomerId",
                table: "DossierVoyage",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierVoyage_FlightId",
                table: "DossierVoyage",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierVoyage_TripTypeId",
                table: "DossierVoyage",
                column: "TripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TActivities_ActivityId",
                table: "TActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TActivities_TravelId",
                table: "TActivities",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelProduct_ProductId",
                table: "TravelProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelProduct_TravelId",
                table: "TravelProduct",
                column: "TravelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "TActivities");

            migrationBuilder.DropTable(
                name: "TravelProduct");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "DossierVoyage");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "TripType");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vol");
        }
    }
}

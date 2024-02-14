// Dossier.cs
using System;

namespace TravelAgencyAPI.Models
{
    public class Dossier
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Duration { get; set; }
        public string FlightNumber { get; set; }
        public string Location { get; set; }
    }
}

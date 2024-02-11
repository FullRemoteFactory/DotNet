namespace VoyageBack.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string Airline { get; set; } // company 
        public string Seat { get; set; } // siège
        public string Classification { get; set; }
        public string FoodType { get; set; }
        public string MaxBagages { get; set; } //klg bagages
       
        public int TravelId { get; set; }
    }
}

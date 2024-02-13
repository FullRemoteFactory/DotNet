namespace TravelBookingFrance.DTO.DTOs
{
    public class UserAndRelatedInformation
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Token { get; set; }
        public virtual IEnumerable<GetTravelListByCustomerIdDTO> TravelListForCostomer { get; set; }
        //travel
        /* public int TravelId { get; set; }
         public string? TravelDate { get; set; }
         public string TravelName { get; set; }
         public string Destination { get; set; }
         public string? DepartureDate { get; set; }
         public string DepartureAirport { get; set; }


         //product
         public virtual ICollection<ProductDTO>? Products { get; set; }

         //TripeType
         public string Ttname { get; set; }

         //Flight
         public string FlightNumber { get; set; }
         public string CompanyName { get; set; }
         public DateTime DateOfDepart { get; set; }
         public DateTime DateOfArrival { get; set; }
         public string SeatNumber { get; set; }*/
    }
}

namespace VoyageBack.Dtos
{
    public class StayDto
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TravelId { get; set; }
    }
}

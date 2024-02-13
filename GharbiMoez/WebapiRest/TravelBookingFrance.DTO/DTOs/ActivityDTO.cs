namespace TravelBookingFrance.DTO.DTOs
{
    public class ActivityDTO
    {
        public int ActivityId { get; set; }
        public string Nom { get; set; }
        public string Lieu { get; set; }
        public int Durée { get; set; }
        public decimal Prix { get; set; }
        public string UrlImageAct { get; set; }
    }
}

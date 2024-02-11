namespace VoyageBack.Dtos
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int StarRating { get; set; }
        public string Description { get; set; }
        public int TravelId { get; set; }
        public string FotoFilePath { get; set; }
        public string FotoName { get; set; }
        public IFormFile File { get; set; }
    }
}

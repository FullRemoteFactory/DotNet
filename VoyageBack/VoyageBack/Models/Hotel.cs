using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VoyageBack.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int StarRating { get; set; } // Or any other rating system you prefer
        public string Description { get; set; }
        public string FotoName { get; set; }
        public string FotoFilePath { get; set; }
        // Foreign key for the related travel
        public int TravelId { get; set; }
        public Travel Travel { get; set; } // Navigation property
    }
}

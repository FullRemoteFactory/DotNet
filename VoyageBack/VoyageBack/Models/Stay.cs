using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VoyageBack.Models
{
    public class Stay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        

        // Foreign key for the related travel
        public int TravelId { get; set; }
        public Travel Travel { get; set; } // Navigation property
    }
}

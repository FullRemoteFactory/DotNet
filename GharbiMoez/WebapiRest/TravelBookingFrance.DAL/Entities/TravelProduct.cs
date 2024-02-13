using System.ComponentModel.DataAnnotations;

namespace TravelBookingFrance.DAL.Entities
{
    public class TravelProduct
    {
        [Key]
        public int TravelProductId { get; set; }

        public int TravelId { get; set; }
        public Travel Travel { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}

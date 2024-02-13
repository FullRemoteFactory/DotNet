using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingFrance.DAL.Entities
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string Url { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }


}

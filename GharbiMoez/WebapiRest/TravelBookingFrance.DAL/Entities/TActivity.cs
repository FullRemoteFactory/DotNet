using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingFrance.DAL.Entities
{
    public class TActivity
    {
        [Key]
        public int TravelActivityId { get; set; }

        [ForeignKey("Travel")]
        public int TravelId { get; set; }
        public Travel? Travel { get; set; }

        [ForeignKey("Activite")]
        public int ActivityId { get; set; }
        public Activite? Activite { get; set; }
    }
}

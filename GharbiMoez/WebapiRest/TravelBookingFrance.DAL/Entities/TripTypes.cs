using System.ComponentModel.DataAnnotations;

namespace TravelBookingFrance.DAL.Entities
{
    public class TripType
    {
        public TripType()
        {

        }
        [Key]
        public int TtId { get; set; }
        public string Ttname { get; set; }
        public string TtDescription { get; set; }


        public virtual ICollection<Travel> Travels { get; set; }
    }

}

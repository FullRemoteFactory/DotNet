using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingFrance.DAL.Entities
{
    [Table("DossierVoyage")]
    public class Travel
    {
        public Travel()
        {

        }
        [Key]
        public int TravelId { get; set; }
        public string? TravelDate { get; set; }
        public string TravelName { get; set; }
        public string Destination { get; set; }
        public string? DepartureDate { get; set; }
        public string DepartureAirport { get; set; }
        public string UrlTravelImage { get; set; }

        public int Prix { get; set; }
        public int? CustomerId { get; set; }
        public int TripTypeId { get; set; }
        public int? FlightId { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual TripType TripType { get; set; }
        public ICollection<TActivity>? TActivities { get; set; }
        public virtual ICollection<TravelProduct> TravelProducts { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TravelBookingFrance.DAL.Entities
{
    public class Activite
    {
        [Key]
        public int ActivityId { get; set; }
        public string Nom { get; set; }
        public string Lieu { get; set; }
        public int Durée { get; set; }
        public decimal Prix { get; set; }
        public string UrlImageAct { get; set; }
        // Propriétés de navigation pour les relations many-to-many
        public ICollection<TActivity>? TravelActivities { get; set; }
    }
}

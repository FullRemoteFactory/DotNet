using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingFrance.DAL.Entities
{
    [Table("Produit")]
    public class Product
    {
        public Product()
        {
        }
        [Key]
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public virtual ICollection<Photo>? Photos { get; set; }
        public virtual ICollection<TravelProduct> TravelProducts { get; set; }
    }
}

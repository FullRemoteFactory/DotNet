using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingFrance.DAL.Entities;

public class Customer
{
    [Key]
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Address { get; set; }
    [DisplayName("City")]
    public string? City { get; set; }
    [DisplayName("Province")]
    public string? Prov { get; set; }
    [DisplayName("Zip Code")]
    public string? Postal { get; set; }
    [DisplayName("Country")]
    public string? Country { get; set; }
    [DisplayName("Home Phone")]
    public string? HomePhone { get; set; }
    [DisplayName("Business Phone")]

    public string? BusPhone { get; set; }

    [DisplayName("Email")]
    public string? Email { get; set; }
    public virtual ICollection<Travel>? Travels { get; set; }
}

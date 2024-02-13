namespace TravelBookingFrance.DAL.Entities
{
    public class Hotel : Product
    {
        public Hotel()
        {
        }
        public string Address { get; set; }
        public int Stars { get; set; }
        public bool IsPetFriendly { get; set; }
    }
}

namespace TravelBookingFrance.DAL.Entities
{
    public class Car : Product
    {
        public Car()
        {
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int PassengerCapacity { get; set; }

    }
}

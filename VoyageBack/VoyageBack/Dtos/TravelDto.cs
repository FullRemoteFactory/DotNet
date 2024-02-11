using System;
using System.Collections.Generic;

namespace VoyageBack.Dtos
{
    public class TravelDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int DurationInDays { get; set; }
        public string FlightNumber { get; set; }
        public string Location { get; set; }
        public string UserId { get; set; }

   
   
    }
}

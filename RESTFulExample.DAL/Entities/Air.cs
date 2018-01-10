using System;

namespace RESTFulExample.DAL.Entities
{
    public class Air: BaseEntity
    {
        public string Provider { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        //Employee
        public int? TravellerId { get; set; }
        public Employee Traveller { get; set; }
    }
}

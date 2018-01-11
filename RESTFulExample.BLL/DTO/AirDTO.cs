using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFulExample.BLL.DTO
{
    public class AirDTO
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        //Employee
        public int? TravellerId { get; set; }
        public EmployeeDTO Traveller { get; set; }
    }
}

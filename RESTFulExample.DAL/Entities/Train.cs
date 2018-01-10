using System;
using System.Collections.Generic;
using System.Text;

namespace RESTFulExample.DAL.Entities
{
    public class Train : BaseEntity
    {
        public string Provider { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }

        //Employee
        public int? TravellerId { get; set; }
        public Employee Traveller { get; set; }
    }
}

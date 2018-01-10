using System;
using System.Collections.Generic;
using System.Text;

namespace RESTFulExample.DAL.Entities
{
    public class Hotel :BaseEntity
    {
        public string Provider { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string Name { get; set; }

        //Employee
        public int? TravellerId { get; set; }
        public Employee Traveller { get; set; }
    }
}

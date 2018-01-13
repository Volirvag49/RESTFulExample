using System;
using System.Collections.Generic;
using System.Text;

namespace RESTFulExample.BLL.DTO
{
    public class HotelDTO
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string Name { get; set; }

        //Employee
        public int? TravellerId { get; set; }

    }
}

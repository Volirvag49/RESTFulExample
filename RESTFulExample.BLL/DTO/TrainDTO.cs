using RESTFulExample.DAL.Entities;
using System;

namespace RESTFulExample.BLL.DTO
{
    public class TrainDTO
    {
        public string Id { get; set; }
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

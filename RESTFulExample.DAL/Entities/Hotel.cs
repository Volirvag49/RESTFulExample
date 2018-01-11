using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFulExample.DAL.Entities
{
    public class Hotel :BaseEntity
    {
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Id { get; set; }
        [Required]
        public string Provider { get; set; }
        [Required]
        public DateTime Checkin { get; set; }
        [Required]
        public DateTime Checkout { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }

        //Employee
        public int? TravellerId { get; set; }
        public Employee Traveller { get; set; }
    }
}

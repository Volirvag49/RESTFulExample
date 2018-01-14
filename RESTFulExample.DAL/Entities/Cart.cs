using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFulExample.DAL.Entities
{
    public class Cart : BaseEntity
    {

        [Required]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

}

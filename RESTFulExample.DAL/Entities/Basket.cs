using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFulExample.DAL.Entities
{
    public class Basket : BaseEntity
    {
        [Required]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string AirId { get; set; }
        public Air Air { get; set; }

        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string TrainId { get; set; }
        public Train Train { get; set; }

        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;

namespace RESTFulExample.DAL.Entities
{
    public class Order : BaseEntity
    {

        [Required]
        public int? CartId { get; set; }
        public Cart Cart { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string ServiceId { get; set; }

        [Required]
        public ServiceTipe ServiceTipe { get; set; }
    }

    public enum ServiceTipe : byte
    {
        Empty = 0,
        Air = 1,
        Train = 2,
        Hotel = 3
    }
}

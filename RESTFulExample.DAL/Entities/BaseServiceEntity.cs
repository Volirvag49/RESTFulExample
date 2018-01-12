using System.ComponentModel.DataAnnotations;

namespace RESTFulExample.DAL.Entities
{
    public abstract class BaseServiceEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Id { get; set; }
    }
}

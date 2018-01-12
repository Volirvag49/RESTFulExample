using System.ComponentModel.DataAnnotations;

namespace RESTFulExample.DAL.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public int? Id { get; set; }
    }
}

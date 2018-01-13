using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFulExample.DAL.Entities
{
    public class Employee :BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string LastName { get; set; }

    }
}

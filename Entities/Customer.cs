using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Customer : EntityBase
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}

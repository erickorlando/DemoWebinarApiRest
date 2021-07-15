using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Direction : EntityBase
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Location { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        public bool Default { get; set; }
    }
}
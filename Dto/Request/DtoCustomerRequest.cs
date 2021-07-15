using System;
using System.ComponentModel.DataAnnotations;

namespace Dto.Request
{
    public class DtoCustomerRequest
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public DtoCustomerRequest()
        {
            BirthDate = DateTime.Today.AddYears(-20);
        }
    }
}
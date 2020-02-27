using System;
using System.ComponentModel.DataAnnotations;

namespace MRGGT.Resources
{
    public class CustomerResource
    {
        public int ID { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Address { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace MRGGT.Resources
{
    public class BrandACustomerResource : CustomerResource
    {
        [Required]
        public String PersonalNumber { get; set; }
    }
}

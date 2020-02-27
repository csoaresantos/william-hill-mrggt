using System;
using System.ComponentModel.DataAnnotations;

namespace MRGGT.Resources
{
    public class BrandBCustomerResource : CustomerResource
    {
        [Required]
        public String FavoriteFootballTeam { get; set; }
    }
}

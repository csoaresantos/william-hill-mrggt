using System;
namespace MRGGT.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String PersonalNumber { get; set; }
        public String FavoriteFootballTeam { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } 

    }
}

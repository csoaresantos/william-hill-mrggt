using System;
using System.Collections.Generic;

namespace MRGGT.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public IList<Customer> Customers { get; set; } = new List<Customer>();
    }
}

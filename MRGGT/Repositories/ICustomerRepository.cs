using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRGGT.Models;

namespace MRGGT.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> List();
        Task Save(Customer customer);
    }
}

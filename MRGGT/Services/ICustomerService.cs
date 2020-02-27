using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRGGT.Models;

namespace MRGGT.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> List();
        Task<SaveCustomerResponse> Save(Customer customer);
    }
}

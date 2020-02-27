using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRGGT.Models;
using MRGGT.Repositories;

namespace MRGGT.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> List()
        {
            return await _customerRepository.List();
        }

        public async Task<SaveCustomerResponse> Save(Customer customer)
        {
            try
            {
                await _customerRepository.Save(customer);
                await _unitOfWork.CompleteAction();
                return new SaveCustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new SaveCustomerResponse($"Error occurred wheb saving customer: {ex.Message}");
            }
        }
    }
}

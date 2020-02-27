using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MRGGT.Extensions;
using MRGGT.Models;
using MRGGT.Resources;
using MRGGT.Services;

namespace MRGGT.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customeService, IMapper mapper)
        {
            _customerService = customeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _customerService.List();
           // var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
            return customers;
        }

        [HttpPost]
        [Route("/api/customer/acustomer")]
        public async Task<IActionResult> Post([FromBody]BrandACustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cus = new Customer
            {
                FirstName = resource.FirstName,
                LastName = resource.LastName,
                Address = resource.Address,
                PersonalNumber = resource.PersonalNumber
            };

            var result = await _customerService.Save(cus);

            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);
            return Ok(customerResource);
        }

        [HttpPost]
        [Route("/api/customer/bcustomer")]
        public async Task<IActionResult> Post([FromBody]BrandBCustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customer = _mapper.Map<BrandBCustomerResource, Customer>(resource);
            var result = await _customerService.Save(customer);

            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);
            return Ok(customerResource);
        }
    }
}

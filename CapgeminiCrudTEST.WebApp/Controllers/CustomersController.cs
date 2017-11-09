using AutoMapper;
using CrudTT.Core.Dtos;
using CrudTT.Core.Models;
using CrudTT.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrudTT.WebApp.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);

            if (customer == null)
                return NotFound();

            var customerDto = _mapper.Map<Customer, CustomerDto>(customer);

            return Ok(customerDto);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();

            var customerDtos = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);

            return Ok(customerDtos);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            await _customerRepository.CreateCustomerAsync(customer);

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = await _customerRepository.GetCustomerAsync(id);

            if (customerInDb == null)
                return NotFound();



            var customer = _mapper.Map(customerDto, customerInDb);

            await _customerRepository.UpdateCustomerAsync(customer);

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            var customerInDb = await _customerRepository.GetCustomerAsync(id);

            if (customerInDb == null)
                return NotFound();

            await _customerRepository.DeleteCustomerAsync(id);

            return Ok();
        }
    }
}

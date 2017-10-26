﻿using AutoMapper;
using CapgeminiCrudTEST.Core.Dtos;
using CapgeminiCrudTEST.Core.Models;
using CapgeminiCrudTEST.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CapgeminiCrudTEST.WebApp.Controllers
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
            var customerInDb = await _customerRepository.GetCustomerAsync(id);

            if (customerInDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

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

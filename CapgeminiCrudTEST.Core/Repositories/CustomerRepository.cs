using CapgeminiCrudTEST.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapgeminiCrudTEST.Core.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        public Task<Customer> GetCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}

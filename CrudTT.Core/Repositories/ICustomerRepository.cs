using CrudTT.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudTT.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAsync(int id);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        Task CreateCustomerAsync(Customer customer);

        Task<Customer> UpdateCustomerAsync(Customer customer);

        Task DeleteCustomerAsync(int id);


    }
}

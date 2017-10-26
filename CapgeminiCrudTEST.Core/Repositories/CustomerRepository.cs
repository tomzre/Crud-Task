using CapgeminiCrudTEST.Core.Concrete;
using CapgeminiCrudTEST.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CapgeminiCrudTEST.Core.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerAsync(int id)
            => await _context.Customers.Include(c => c.Address).SingleOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
            => await _context.Customers.Include(c => c.Address).ToListAsync();

        public async Task CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var customerInDb = await GetCustomerAsync(customer.Id);

            if (customerInDb != null)
            {
                customerInDb.Name = customer.Name;
                customerInDb.Surname = customer.Surname;
                customerInDb.PhoneNumber = customer.PhoneNumber;

                await _context.SaveChangesAsync();
            }

            return customerInDb;

        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customerInDb = await GetCustomerAsync(id);

            if (customerInDb != null)
            {
                _context.Customers.Remove(customerInDb);
                await _context.SaveChangesAsync();
            }

        }

    }
}

using CapgeminiCrudTEST.Core.Models;
using System.Data.Entity;

namespace CapgeminiCrudTEST.Core.Concrete
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
    }
}

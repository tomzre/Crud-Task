using CrudTT.Core.Models;
using System.Data.Entity;

namespace CrudTT.Core.Concrete
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
    }
}

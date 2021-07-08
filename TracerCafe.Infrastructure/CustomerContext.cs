using Microsoft.EntityFrameworkCore;
using TracerCafe.Domain.Models;

namespace TracerCafe.Infrastructure
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
    }
}

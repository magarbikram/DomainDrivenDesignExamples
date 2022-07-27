using Microsoft.EntityFrameworkCore;

namespace InvoiceDeliquencyExample.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
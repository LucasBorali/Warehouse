using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Input> InputLogs { get; set; }
        public DbSet<Output> OutputLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=warehouse.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais do modelo podem ser feitas aqui
        }
    }
}

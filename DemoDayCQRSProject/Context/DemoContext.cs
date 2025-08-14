using DemoDayCQRSProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.Context
{
    public class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Tufan;initial catalog=DemoCQRSdb;integrated Security=true;trust server certificate=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

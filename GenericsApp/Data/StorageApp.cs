using GenericsApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericsApp.Data
{
    public class StorageApp : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Organization> Organizations => Set<Organization>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageApp");
        }
    }
}

using LaMiaPizzeriaEfPost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LaMiaPizzeriaEfPost.Database
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=LaMiaPizzeriaDb;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

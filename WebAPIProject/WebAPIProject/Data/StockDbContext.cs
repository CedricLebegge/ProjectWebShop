using Microsoft.EntityFrameworkCore;
using WebAPIProject.Models;

namespace WebAPIProject.Data
{
    public class StockDbContext : DbContext
    {
        public DbSet<StockItem> Stock { get; set; }

        public StockDbContext() : base(new DbContextOptionsBuilder<StockDbContext>()
       .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebShopDB;Integrated Security=True;")
       .Options)
        {
            // configureer database provider en andere opties hier
        }
    }
}

using BookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
         
        public DbSet<Category>? Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category { CatId=1, CatName="Drama", DispalyOrder="1"},
                new Category { CatId = 2, CatName = "Action", DispalyOrder = "2" },
                new Category { CatId = 3, CatName = "Sci-fi", DispalyOrder = "3" }
                );
        }
    }
}

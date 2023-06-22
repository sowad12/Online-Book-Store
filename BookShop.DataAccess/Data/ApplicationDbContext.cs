using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "helu", DisplayOrder = 1 },
                new Category { Id = 2, Name = "helu", DisplayOrder = 1 },
                new Category { Id = 3, Name = "helu", DisplayOrder = 1 },
                new Category { Id = 4, Name = "helu", DisplayOrder = 1 },
                new Category { Id = 5, Name = "helu", DisplayOrder = 1 },
                new Category { Id = 6, Name = "helu", DisplayOrder = 1 }
            );
        }
        //protected override void onModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().HasData(
        //        new Category { Id = 1,Name="helu",DisplayOrder=1},
        //        new Category { Id = 1,Name="helu",DisplayOrder=1},
        //        new Category { Id = 1,Name="helu",DisplayOrder=1},
        //        new Category { Id = 1,Name="helu",DisplayOrder=1},
        //        new Category { Id = 1,Name="helu",DisplayOrder=1},
        //        new Category { Id = 1,Name="helu",DisplayOrder=1}
        //    );

        //}
    }
}

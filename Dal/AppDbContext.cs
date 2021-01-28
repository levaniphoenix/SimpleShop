using DAL.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace DAL
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
           
        }
        public DbSet<Product> Products { set; get; }
        public DbSet<ShoppingCart> ShoppingCarts { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Gravity Falls: Journal 3",
                    Price = 10.20,
                    Description= "Journal 3 brims with every page ever seen on the show plus all-new pages with monsters and secrets, notes from Dipper and Mabel, and the Author's full story.",
                },
                new Product
                {
                    Id = 2,
                    Name = "2020 Christmas Ornament",
                    Price = 4,
                    Description = "2020 themed christmas ornament.",
                }
            );


            modelBuilder.Entity<ShoppingCart>()
                .HasOne(e => e.Products)
                .WithMany(e => e.shoppingCart)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

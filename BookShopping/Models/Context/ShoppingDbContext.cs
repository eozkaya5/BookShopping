
using BookShopping.Models.ShoppingModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.Context
{
    public class ShoppingDbContext: DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
   
}

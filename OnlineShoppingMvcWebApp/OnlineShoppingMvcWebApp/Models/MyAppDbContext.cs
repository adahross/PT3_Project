using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class MyAppDbContext : DbContext
    {
        public DbSet<Book> Book{ get; set; }
        public DbSet<RegisteredUser> RegisteredUser { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address  { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
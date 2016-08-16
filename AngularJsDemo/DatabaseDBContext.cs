using AngularJsDemo.Models;
using System.Data.Entity;

namespace AngularJsDemo
{
    public class DatabaseDBContext : DbContext
    {
        public DatabaseDBContext() : base("MyDatabase")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
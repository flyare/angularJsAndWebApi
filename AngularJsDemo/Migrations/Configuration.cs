namespace AngularJsDemo.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularJsDemo.DatabaseDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngularJsDemo.DatabaseDBContext context)
        {
            CreateDemoData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void CreateDemoData(DatabaseDBContext context)
        {
            var list = new List<Product>()
            {
                new Product() { Name = "LG G3 Cat6", Category = "Smart Phone" },
                new Product() { Name = "LG G4 US", Category = "Smart Phone" },
                new Product() { Name = "LG G4 STK", Category = "Smart Phone" },
                new Product() { Name = "Xiaomi Node 3", Category = "Smart Phone" },
                new Product() { Name = "TV LG 4K", Category = "Smart TV" },
                new Product() { Name = "Samsung US", Category = "Smart TV" },
                new Product() { Name = "Samsung 50 kingcom", Category = "Smart TV" },
                new Product() { Name = "Xiaomi TV Pro", Category = "Smart TV" }
            };

            context.Products.AddRange(list);
            context.SaveChanges();
        }
    }
}
